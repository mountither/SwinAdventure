using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class Inventory
    {   
        
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            if(Fetch(id) != null)
            {
                return true;
            }

            return false;

        }

        //add item into _item list
        public void Put(Item itm)
        {
            _items.Add(itm);
            
        }

        //remove specific (id) item from _item list
        public Item Take(string id)
        {
               Item item = Fetch(id);
               _items.Remove(item);
            
               return item;
        }

        //locates item via id and returns it
        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
                
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string _itmList = "";
                foreach (Item i in _items) 
                {
                    _itmList +=  "   " + i.ShortDescription + "\n";
                }
                return _itmList;
            }
        }

    }

    

}
