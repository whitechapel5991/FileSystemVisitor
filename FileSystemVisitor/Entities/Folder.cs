using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitor.Entities
{
    public class Folder : SystemElement
    {
        public List<SystemElement> Children = new List<SystemElement>();

        public Folder(string path) : base(path)
        {

        }

        public override void Add(SystemElement element)
        {
            this.Children.Add(element);
        }

        public override void Remove(SystemElement element)
        {
            this.Children.Remove(element);
        }

        //public void BuildFileSystemTree()
        //{
        //    if (Directory.Exists(Path))
        //    {
        //        var pathOfFolders = Directory.GetDirectories(Path);
        //        foreach(var folderPath in pathOfFolders)
        //        {
        //            var newFolder = new Folder(folderPath);
        //            Add(newFolder);
        //            newFolder.BuildFileSystemTree();
        //        }

        //        var pathOfFiles = Directory.GetFiles(Path);
        //        foreach (var filePath in pathOfFiles)
        //        {
        //            var newFile = new File(filePath);
        //            Add(newFile);
        //        }
        //    }
        //    else
        //    {
        //        throw new DirectoryNotFoundException("Root directory not found!");
        //    }
        //}

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitFolder(this);
        }

        //public override IEnumerable<SystemElement> GetAllFoldersAndFiles()
        //{
        //    foreach (SystemElement component in this.children)
        //    {
        //        if (component.IsFolder())
        //        {
        //            foreach (var item in component.GetAllFoldersAndFiles())
        //            {
        //                yield return item;
        //            }
        //        }

        //        yield return component;
        //    }
        //}
    }
}
