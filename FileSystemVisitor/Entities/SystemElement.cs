using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Entities
{
    public abstract class SystemElement
    {
        protected string Path { get; set; }
        
        public SystemElement(string path)
        {
            this.Path = path;
        }

        public abstract void BuildFileSystemTree();

        public virtual IEnumerable<string> GetAllFoldersAndFiles()
        {
            throw new NotImplementedException();
        }

        protected virtual void Add(SystemElement element)
        {
            throw new NotImplementedException();
        }

        protected virtual void Remove(SystemElement element)
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
    }
}
