using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class Bag : Item, IHaveInventory
    {
        Inventory _inventory;

        public Bag(List<string> ids, string name, string desc): base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }

        }

        public override string FullDescription
        {
            get
            {
                return string.Format("In the {0} you can see: \n{1}", Name, _inventory.ItemList);
                
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
