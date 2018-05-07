using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class HandlingInput
    {
        private Parser parser = new Parser();

        public void Play()
        {
            Boolean finished = false;
            while (!finished)
            {
                Console.Write("Command: ");
                Command command = parser.GetCommand();
                finished = ProcessCommand(command);
            }
        }

        private Boolean ProcessCommand(Command c)
        {
            if (c.IsUnknown)
                return true;
            return false;
        }
    }
}