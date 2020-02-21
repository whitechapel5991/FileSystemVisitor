using FileSystemVisitor.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitor
{
    public class FileSystemVisitor : IVisitor
    {
        Func<string> filterDelegate;

        public FileSystemVisitor()
        {
        }

        public FileSystemVisitor(Func<string> filter)
        {
            this.filterDelegate = filter;
        }

        public IEnumerable<SystemElement> GetAllFoldersAndFiles(Folder folder)
        {
            foreach (SystemElement element in folder.Children)
            {
                if (element.IsFolder())
                {
                    foreach (var item in this.GetAllFoldersAndFiles((Folder)element))
                    {
                        yield return item;
                    }
                }

                yield return element;
            }
        }

        public void BuildFileSystemTree(Folder rootFolder)
        {
            if (Directory.Exists(rootFolder.Path))
            {
                var pathOfFolders = Directory.GetDirectories(rootFolder.Path, filterDelegate?.Invoke());
                foreach (var folderPath in pathOfFolders)
                {
                    var newFolder = new Folder(folderPath);
                    rootFolder.Add(newFolder);
                    BuildFileSystemTree(newFolder);
                }

                var pathOfFiles = Directory.GetFiles(rootFolder.Path, filterDelegate?.Invoke());
                foreach (var filePath in pathOfFiles)
                {
                    var newFile = new Entities.File(filePath);
                    rootFolder.Add(newFile);
                }
            }
            else
            {
                throw new DirectoryNotFoundException("Root directory not found!");
            }
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
}
