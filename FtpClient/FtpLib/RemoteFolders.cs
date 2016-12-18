using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRemoting
{
    public class RemoteFolders
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private RemoteFolders _parent;
        public RemoteFolders Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }

        private List<RemoteFolders> _children;

        public List<RemoteFolders> Children
        {
            get { return _children; }
            private set { _children = value; }
        }

        public RemoteFolders(string name, RemoteFolders parent)
        {
            Name = name;
            Parent = parent;
            Children = new List<RemoteFolders>();
        }

        public RemoteFolders GetRootGroup()
        {
            RemoteFolders root = this;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            return root;
        }

        public List<RemoteFolders> GetSubGroups()
        {
            List<RemoteFolders> groups = new List<RemoteFolders>();

            groups.Add(this);
            if (Children != null)
            {
                foreach (RemoteFolders child in Children)
                {
                    groups.AddRange(child.GetSubGroups());
                }
            }
            return groups;
        }
    }
}
