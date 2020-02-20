using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Entities
{
    public class File : SystemElement
    {
        public File(string path) : base(path)
        {

        }

        public override void BuildFileSystemTree()
        {
            //return string.Format($"File: {Path}");
        }

        public override bool IsFolder()
        {
            return false;
        }
    }
}
