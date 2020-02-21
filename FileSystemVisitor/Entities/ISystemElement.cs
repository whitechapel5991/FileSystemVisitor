using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Entities
{
    interface ISystemElement
    {
        void Accept(IVisitor visitor);
    }
}
