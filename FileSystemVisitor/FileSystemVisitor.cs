using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FileSystemVisitor
{
    public class FileSystemVisitor
    {
        const string START_SEARCHING = "Start searching...";
        const string FINISH_SEARCHING = "End searching...";
        const string FIND_DIRECTORY_MESSAGE_WITHOUT_FILTER = "Directories finded:";
        const string FIND_fILE_MESSAGE_WITHOUT_FILTER = "Files finded:";
        const string FIND_DIRECTORY_MESSAGE_WITH_FILTER = "Directories filtered:";
        const string FIND_fILE_MESSAGE_WITH_FILTER = "Files filtered:";

        public event EventHandler<ProgressArgs> Start;
        public event EventHandler<ProgressArgs> Finish;
        public event EventHandler<ProgressArgs> FileFinished;
        public event EventHandler<ProgressArgs> DirectoryFinished;
        public event EventHandler<ProgressArgs> FilteredFileFinished;
        public event EventHandler<ProgressArgs> FilteredDirectoryFinished;

        protected bool IsSearching { get; set; } = true;
        protected bool ExcludeFiles { get; set; } = false;
        protected bool ExcludeFolders { get; set; } = false;

        readonly Func<string> filterDelegate;

        

        public FileSystemVisitor()
        {

        }
        public FileSystemVisitor(Func<string> filter)
        {
            this.filterDelegate = filter;
        }

        public void Stop()
        {
            this.IsSearching = false;
        }

        public void ExcludeFilesFromSearch()
        {
            this.ExcludeFiles = true;
        }

        public void ExcludeFoldersFromSearch()
        {
            this.ExcludeFolders = true;
        }

        public IEnumerable<string> Find(string path)
        {
            var result = GetEnumerator(path);

            return result;
        }

        public IEnumerable<string> FindWithFilter(string path)
        {
            var result = GetEnumerator(path, true);

            return result;
        }

        public IEnumerable<string> GetEnumerator(string path, bool isFilter = false)
        {
            if (Directory.Exists(path))
            {
                OnStart(new ProgressArgs { Message = START_SEARCHING, IsSearching = IsSearching });


                    foreach (var elem in GetFolder(path, isFilter))
                    {
                        yield return elem;
                    }


                    foreach (var elem in GetFiles(path, isFilter))
                    {
                        yield return elem;
                    }
                

                OnFinish(new ProgressArgs { Message = FINISH_SEARCHING, IsSearching = IsSearching });
            }
            else
            {
                throw new DirectoryNotFoundException("Root directory not found!");
            }
        }

        private IEnumerable<string> GetFolder(string path, bool isFilter = false)
        {
            if (!ExcludeFolders)
            {
                var pathOfFolders = isFilter ?
                    Directory.GetDirectories(path, filterDelegate.Invoke(), SearchOption.AllDirectories) :
                    Directory.GetDirectories(path, "*", SearchOption.AllDirectories);


                if (isFilter)
                    OnFilteredDirectoryFinished(new ProgressArgs { Message = FIND_DIRECTORY_MESSAGE_WITH_FILTER, IsSearching = IsSearching });
                else
                    OnDirectoryFinished(new ProgressArgs { Message = FIND_DIRECTORY_MESSAGE_WITHOUT_FILTER, IsSearching = IsSearching });


                foreach (var folderPath in pathOfFolders)
                {
                    if (IsSearching == true)
                    {
                        yield return folderPath;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private IEnumerable<string> GetFiles(string path, bool isFilter = false)
        {
            if (!ExcludeFiles)
            {
                var pathOfFiles = isFilter ?
                   Directory.GetFiles(path, filterDelegate.Invoke(), SearchOption.AllDirectories) :
                   Directory.GetFiles(path, "*", SearchOption.AllDirectories);


                if (isFilter)
                    OnFilteredFileFinished(new ProgressArgs { Message = FIND_fILE_MESSAGE_WITH_FILTER, IsSearching = IsSearching });
                else
                    OnFileFinished(new ProgressArgs { Message = FIND_fILE_MESSAGE_WITHOUT_FILTER, IsSearching = IsSearching });


                foreach (var filePath in pathOfFiles)
                {
                    if (IsSearching == true)
                    {
                        yield return filePath;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        #region Events method
        protected void OnStart(ProgressArgs args)
        {
            var tmp = Start;
            if (tmp != null && args.IsSearching != false)
                Start(this, args);
        }

        protected void OnFinish(ProgressArgs args)
        {
            var tmp = Finish;
            if (tmp != null && args.IsSearching != false)
                Finish(this, args);

            this.IsSearching = true;
            this.ExcludeFiles = false;
            this.ExcludeFolders = false;
        }

        protected void OnFileFinished(ProgressArgs args)
        {
            var tmp = FileFinished;
            if (tmp != null && args.IsSearching != false && args.ExcludeFiles != true)
                FileFinished(this, args);
        }

        protected void OnDirectoryFinished(ProgressArgs args)
        {
            var tmp = DirectoryFinished;
            if (tmp != null && args.IsSearching != false && args.ExcludeFolders != true)
                DirectoryFinished(this, args);
        }

        protected void OnFilteredFileFinished(ProgressArgs args)
        {
            var tmp = FilteredFileFinished;
            if (tmp != null && args.IsSearching != false && args.ExcludeFiles != true)
                FilteredFileFinished(this, args);
        }

        protected void OnFilteredDirectoryFinished(ProgressArgs args)
        {
            var tmp = FilteredDirectoryFinished;
            if (tmp != null && args.IsSearching != false && args.ExcludeFolders != true)
                FilteredDirectoryFinished(this, args);
        }
        #endregion
    }

    public class ProgressArgs
    {
        public string Message { get; set; }

        public bool IsSearching { get; set; } = true;

        public bool ExcludeFiles { get; set; } = false;

        public bool ExcludeFolders { get; set; } = false;
    } 
}
