using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class Path : GameObject
    {
        public Path(List<string> ids, string name, string desc) : base(ids, name , desc) { }

        public void Move(Player p)
        {
             p.Location = Location;
        }

        public Location Location { get; set; }

        public override string FullDescription
        {
            get
            { 
                return string.Format("You head {0}\n You {1}\n You have arrived in a {2}", Name, base.FullDescription, Location.Name);
            }
           
        }
    }
}
