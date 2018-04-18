﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Parser
    {
        public Command getCommand()
        {
            string inputLine = "";
            inputLine = Console.ReadLine();
            String[] values = inputLine.Split(' ', '\n');
            if (CommandWords.isCommand(values[0]))
                if (values.Count() == 1)
                    return new Command { CommandWord = values[0], SecondWord = null };
                else if (values.Count() == 2)
                    return new Command { CommandWord = values[0], SecondWord = values[1] };
            return new Command(); ;

        }
    }
}
