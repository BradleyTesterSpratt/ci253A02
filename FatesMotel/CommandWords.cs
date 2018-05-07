using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class CommandWords
    {

        private static String[] validCommands = { "quit", "help", "room", "list", "report", "clear", "engine", "recall", "refill", "go"}; //sets the command words to be used by the player as strings
        public String[] ValidCommands { get { return validCommands; } } //gets to see if it is a valid word or not

        public static Boolean IsCommand(String command)//takes in the string of the command words
        {
            if (validCommands.Contains(command))
                return true; // does it contain a command or not 
            return false;
        }

    }
}
