using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Entities
{
    internal class Folder : SystemElement
    {
        protected List<SystemElement> children = new List<SystemElement>();

        public Folder(string path) : base(path)
        {

        }

        public override void Add(SystemElement element)
        {
            this.children.Add(element);
        }

        public override void Remove(SystemElement element)
        {
            this.children.Remove(element);
        }

        public override string Operation()
        {
            int i = 0;
            string result = $"Folder: {Path}";

            foreach (SystemElement component in this.children)
            {
                result += "/n   " + component.Operation();
                if (i != this.children.Count - 1)
                {
                    result += "/n";
                }
                i++;
            }

            return result + "/n complite...";
        }
    }
}
