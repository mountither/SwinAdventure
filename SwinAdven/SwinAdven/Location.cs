using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(List<string> ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
            
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }

            return null;
        }


        public bool HasPath(string id)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return true;
                }
            }

            return false;

        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
            
        }

        public Path FetchPath(string id)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }

            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return string.Format("Your are in the {0} \n {1} \n In this room you can see: \n{2}", Name, base.FullDescription, _inventory.ItemList);

            }

        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }


    }
}
