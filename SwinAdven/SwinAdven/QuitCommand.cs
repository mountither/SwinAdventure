using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new List<string> { "quit" }) { }

        public override string Execute(Player p, List<string> text)
        {
            string str;
            if (text[0] == "quit" && text.Count == 1)
            {
                str = "Quitting";
            }
            else str = "What do you want to do?";

            return str;
        }

    }
}
