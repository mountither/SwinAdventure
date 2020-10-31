using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
   
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base (new List<string> { "me", "inventory", "inv"}, name, desc) 
        {
            _inventory = new Inventory();
            _location = new Location(new List<string> { ""}, "", "");
           
        }

        //locates a GameObject around player. inc. Player, Item that a player has in the inventory. 
        //if the id is inventory, return this(?). if item call Inventory.Fetch(with string id). Fetch does the rest from here. 
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
            else if(_location.Locate(id) != null)
            {
                return _location.Locate(id);
            }

            return null;
           
        }

        public override string FullDescription
        {
            get
            {
                return string.Format("You are {0} the {1} \n You are carrying: \n{2}", Name, base.FullDescription,  _inventory.ItemList);
                
            }
        }



        public Inventory Inventory
        { 
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}
