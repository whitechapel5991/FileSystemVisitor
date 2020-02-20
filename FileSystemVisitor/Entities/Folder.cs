using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitor.Entities
{
    public class Folder : SystemElement
    {
        public List<SystemElement> children = new List<SystemElement>();

        public Folder(string path) : base(path)
        {

        }

        protected override void Add(SystemElement element)
        {
            this.children.Add(element);
        }

        protected override void Remove(SystemElement element)
        {
            this.children.Remove(element);
        }

        public override void BuildFileSystemTree()
        {
            if (Directory.Exists(Path))
            {
                var pathOfFolders = Directory.GetDirectories(Path);
                foreach(var folderPath in pathOfFolders)
                {
                    var newFolder = new Folder(folderPath);
                    Add(newFolder);
                    newFolder.BuildFileSystemTree();
                }

                var pathOfFiles = Directory.GetFiles(Path);
                foreach (var filePath in pathOfFiles)
                {
                    var newFile = new File(filePath);
                    Add(newFile);
                }
            }
            else
            {
                throw new DirectoryNotFoundException("Root directory not found!");
            }

            //int i = 0;
            //string result = $"Folder: {Path}";

            //foreach (SystemElement component in this.children)
            //{
            //    result += "/n   " + component.BuildFileSystemTree();
            //    if (i != this.children.Count - 1)
            //    {
            //        result += "/n";
            //    }
            //    i++;
            //}

            //return result + "/n complite...";
        }

        public override IEnumerable<string> GetAllFoldersAndFiles()
        {
            foreach (SystemElement component in this.children)
            {
                if (component.IsFolder())
                {
                    component.GetAllFoldersAndFiles();
                }

                yield return component.ToString();
            }
        }
    }
}
