using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdven
{
    public class CommandProcessor
    {
        private readonly List<Command> _commands;

        public CommandProcessor() 
        {

            _commands = new List<Command>(); 
            _commands.Add(new QuitCommand());
            _commands.Add(new TransferCommand());
            _commands.Add(new MoveCommand());
            _commands.Add(new LookCommand());
           

        }

        public string ExecuteRelevantCommand(Player p, List<string> cmdList)
        {
            string str = "";

            string lowerCmd = cmdList[0].ToLower();

            foreach (Command c in _commands)
            {

                if (c.AreYou(lowerCmd))
                {
                    str = c.Execute(p, cmdList);
                }
                
            }

            return str;

        }
       
       
    }
}
