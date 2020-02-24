using FileSystemVisitor.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitor
{
    public class FileSystemVisitor : IVisitor
    {
        Func<string> filterDelegate;
        public event EventHandler<ProgressArgs> Progress;

        public FileSystemVisitor()
        {

        }
        public FileSystemVisitor(Func<string> filter)
        {
            this.filterDelegate = filter;
        }

        private IEnumerable<string> GetEnumerator(string path)
        {
            if (Directory.Exists(path))
            {
                var pathOfFolders = filterDelegate != null ?
                    Directory.GetDirectories(path, filterDelegate.Invoke()) :
                    Directory.GetDirectories(path);

                foreach (var folderPath in pathOfFolders)
                {
                    foreach (var deepFolder in this.GetEnumerator(folderPath))
                    {
                        yield return deepFolder;
                    }

                    yield return folderPath;
                }

                var pathOfFiles = filterDelegate != null ?
                    Directory.GetFiles(path, filterDelegate.Invoke(), SearchOption.AllDirectories) :
                    Directory.GetFiles(path);

                foreach (var filePath in pathOfFiles)
                {
                    yield return filePath;
                }
            }
            else
            {
                throw new DirectoryNotFoundException("Root directory not found!");
            }
        }

        //public IEnumerable<SystemElement> GetAllFoldersAndFiles(Folder folder)
        //{
        //    OnProgress(new ProgressArgs { Message = "File finded..." });
        //    foreach (SystemElement element in folder.Children)
        //    {
        //        if (element.IsFolder())
        //        {
        //            foreach (var item in this.GetAllFoldersAndFiles((Folder)element))
        //            {
        //                yield return item;
        //            }
        //        }

        //        yield return element;
        //    }
        //}

        public IEnumerable<string> Find(string path)
        {
            OnProgress(new ProgressArgs { Message = "Start finding by path..." });


            foreach (var item in GetEnumerator(path))
            {
                yield return item;
            }
            OnProgress(new ProgressArgs { Message = "Operation End..." });
           
        }

        //private void BuildFileSystemTree(Folder rootFolder)
        //{
        //    if (Directory.Exists(rootFolder.Path))
        //    {
        //        var pathOfFolders = filterDelegate != null ?
        //            Directory.GetDirectories(rootFolder.Path, filterDelegate.Invoke()) :
        //            Directory.GetDirectories(rootFolder.Path);

        //        foreach (var folderPath in pathOfFolders)
        //        {
        //            var newFolder = new Folder(folderPath);
        //            rootFolder.Add(newFolder);
        //            BuildFileSystemTree(newFolder);
        //        }

        //        var pathOfFiles = filterDelegate != null ?
        //            Directory.GetFiles(rootFolder.Path, filterDelegate.Invoke(), SearchOption.AllDirectories) :
        //            Directory.GetFiles(rootFolder.Path);

        //        foreach (var filePath in pathOfFiles)
        //        {
        //            var newFile = new Entities.File(filePath);
        //            rootFolder.Add(newFile);
        //        } 
        //    }
        //    else
        //    {
        //        throw new DirectoryNotFoundException("Root directory not found!");
        //    }
        //}

        protected void OnProgress(ProgressArgs args)
        {
            var tmp = Progress;
            if (tmp != null)
                Progress(this, args);
        }

        public void VisitFolder(Folder folder)
        {
            throw new NotImplementedException();
        }

        public void VisitFile(Entities.File file)
        {
            throw new NotImplementedException();
        }

 
    }

    public class ProgressArgs
    {
        public string Message { get; set; }
    } 
}
