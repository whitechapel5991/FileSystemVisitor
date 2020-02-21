using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Entities
{
    public abstract class SystemElement : ISystemElement
    {
        public string Path { get; set; }
        
        public SystemElement(string path)
        {
            this.Path = path;
        }

        //public abstract void BuildFileSystemTree();

        //public virtual IEnumerable<SystemElement> GetAllFoldersAndFiles()
        //{
        //    throw new NotImplementedException();
        //}

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

        public override string ToString()
        {
            int position = Path.LastIndexOf('\\');
            return Path.Remove(0, position+1);
        }

        public abstract void Accept(IVisitor visitor);
    }
}
