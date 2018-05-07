using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Parser
    {
        public Command GetCommand() //gets the use of the command to know how many words are needed
        {
            string inputLine = "> "; // allows input from the user
            inputLine = Console.ReadLine();
            inputLine.ToLower();
            String[] values = inputLine.Split(' ', '\n');
            if (CommandWords.IsCommand(values[0])) 
                if (values.Count() == 1) //counts how many words have been typed
                    return new Command { CommandWord = values[0], SecondWord = null }; //shows the second word as null as it wont be needed
            else if (values.Count() == 2) //counts how many words have been typed
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = null }; //will only take into account two words and not the third
            else if (values.Count() == 3) //counts how many words have been typed
                return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = values[2], FourthWord = null }; //takes three words and will leave the fourth as null
            else if (values.Count() == 4) //counts how many words have been typed
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = values[2], FourthWord = values[3]}; //will allow the player to use four words
            return new Command(); 

        }
    }
}
