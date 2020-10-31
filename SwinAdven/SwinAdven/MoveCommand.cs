using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new List<string> { "move", "head", "go" }) { }

        public override string Execute(Player p, List<string> text)
        {
            string invalidStr;

            if (text.Count == 2)
            {
                if (p.Location.HasPath(text[1]))
                {
                    Path path = p.Location.FetchPath(text[1]);
                    path.Move(p);
                    return path.FullDescription;
                }
                else
                {
                    invalidStr = "Cannot find Path";
                }
            }
            else
            {
                invalidStr = "Please specify direction";
            }

            return invalidStr;
        }
    }
}
