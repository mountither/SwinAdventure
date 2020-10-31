using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class Item : GameObject
    {
        public Item(List<string> idents, string name, string desc): base(idents, name, desc)
        {
            
        }
    }
}
