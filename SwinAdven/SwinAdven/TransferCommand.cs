using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class TransferCommand : Command
    {

        public TransferCommand() : base(new List<string> {"take", "pickup", "put", "drop"} ) { }
        public override string Execute(Player p, List<string> text)
        {
            if (text.Count > 1)
            {
                if (text.Count == 2 && (text[0].ToLower() == "take" || text[0].ToLower() == "pickup"))
                {
                    string containId = p.Location.FirstId;

                    IHaveInventory container = FetchContainer(p, containId);

                    if (container == null)
                    {
                        return "I cant find the " + text[1];

                    }
                    else if (p.Location.AreYou(text[1]))
                    {
                        return "You cant take the " + text[1];
                    }
                    else
                    {
                        return TakeAndKeep(container, p, text[1]);
                    }
                }
                if (text.Count == 4 && (text[0].ToLower() == "take" || text[0].ToLower() == "pickup") && text[2].ToLower() == "from")
                {
                    IHaveInventory container = FetchContainer(p, text[3]);

                    if (container == null)
                    {
                        return "I cant find the " + text[3];

                    }
                    else
                    {
                        return TakeAndKeep(container, p, text[1]);
                    }

                }
                if (text.Count == 2 && (text[0].ToLower() == "put" || text[0].ToLower() == "drop"))
                {
                    string containId = p.Location.FirstId;

                    IHaveInventory container = FetchContainer(p, containId);

                    if (container == null)
                    {
                        return "I cant find the " + text[1];

                    }
                    else if (p.Location.AreYou(text[1]))
                    {
                        return "You cant take the " + text[1];
                    }
                    else
                    {
                        return Dispense(container, p, text[1]);
                    }
                }
                if (text.Count == 4 && (text[0].ToLower() == "put" || text[0].ToLower() == "drop") && text[2].ToLower() == "in")
                {
                    IHaveInventory container = FetchContainer(p, text[3]);

                    if (container == null)
                    {
                        return "I cant find the " + text[3];

                    }
                    else
                    {
                        return Dispense(container, p, text[1]);
                    }

                }
                else
                {
                    return "Take From where?";
                }
            }
            else
            {
                return "What do you want to take?";
            }



        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;

        }

        private string Dispense(IHaveInventory container, Player p, string thingId)
        {
            GameObject i = p.Locate(thingId);

            if (i != null)
            {
                Item droppedItem = p.Inventory.Take(thingId);
                container.Inventory.Put(droppedItem);
                
                return string.Format("  You have placed the {0} in the {1}", thingId, container.Name);
            }
            else
            {
                return string.Format("  I cant find {0}", thingId);
            }
        }

        private string TakeAndKeep(IHaveInventory container, Player p,  string thingId)
        {
            
            GameObject i = container.Locate(thingId);
            
            if (i != null)
            {
                Item takenItem = container.Inventory.Take(thingId);
                p.Inventory.Put(takenItem);
                return string.Format("  You have taken the {0} from the {1}", thingId, container.Name);
            }
            else 
            {
                return string.Format("  I cant find {0} in the {1}", thingId, container.Name);
            }

        }


    }
}
