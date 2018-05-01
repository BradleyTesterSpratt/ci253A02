using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class CommandWords
    {

        private static String[] validCommands = { "quit", "help", "room", "list", "report", "clear", "engine", "recall", "refill", "go"};
        public String[] ValidCommands { get { return validCommands; } }

        public static Boolean isCommand(String command)
        {
            if (validCommands.Contains(command))
                return true;
            return false;
        }

    }
}
