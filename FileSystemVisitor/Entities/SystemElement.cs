using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Entities
{
    abstract class SystemElement
    {
        protected string Path { get; set; }

        public SystemElement(string path)
        {
            this.Path = path;
        }

        public abstract string Operation();

        public virtual void Add(SystemElement element)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(SystemElement element)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsFolder()
        {
            return true;
        }
    }
}
