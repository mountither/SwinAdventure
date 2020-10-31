using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class LookCommand : Command
    {
      
        public LookCommand() : base(new List<string> { "look", "me", "inventory", "inv"}) { }

        //the player is sent here, with the array converted 'look comand'. assess whether its 3 (sent to lookatin directly) or 5 elements
        public override string Execute(Player p, List<string> text)
        {
            string invalidStr = "";

            if (text.Count == 3 || text.Count == 5)
            {
                if (text[0].ToLower() != "look")
                {
                    invalidStr = "Error in look input";
                }

                if (text[1].ToLower() != "at")
                {
                    invalidStr = "What do you want to look at?";

                }

                if (text.Count == 5 && text[3].ToLower() != "in")
                {
                    invalidStr = "What do you want to look in?";
                }

                if (text.Count == 3 && text[0].ToLower() == "look" && text[1].ToLower() == "at")
                {

                    return LookAtIn(text[2], p as IHaveInventory);

                }

                if (text.Count == 5 && text[0].ToLower() == "look" && text[1].ToLower() == "at" && text[3].ToLower() == "in")
                {
                    IHaveInventory container = FetchContainer(p, text[4]);

                    if (container == null)

                        return "I can't find the " + text[4];
                    else

                        return LookAtIn(text[2], container);

                }

            }
            else if (text.Count == 1 && text[0].ToLower() == "look")
            {
                return p.Location.FullDescription;
            }
            else if (p.AreYou(text[0].ToLower())) 
            {
                return LookAtIn(text[0], p as IHaveInventory);
            }
            else
            {
                invalidStr = "I don't know how to look for that";
            }


            return invalidStr;

        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
            
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            
            GameObject item = container.Locate(thingId);

            if (container.Name != "bag" && item == null)
            {
                return "I can't find the " + thingId;
            }
            else if(container.Name == "bag" && item == null)
            {
                return "I can't find the " + thingId + " in the bag";
            }
            else
            {
                return item.FullDescription;

            }

        }
    }
}
