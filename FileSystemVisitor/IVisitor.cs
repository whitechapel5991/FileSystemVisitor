using FileSystemVisitor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor
{
    public interface IVisitor
    {
        void VisitFolder(Folder folder);
        void VisitFile(File file);

    }
}
