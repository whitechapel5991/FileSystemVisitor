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

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitFile(this);
        }

        //public void BuildFileSystemTree()
        //{
        //    //return string.Format($"File: {Path}");
        //}

        public override bool IsFolder()
        {
            return false;
        }
    }
}
