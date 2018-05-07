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
        private Game vGame;

        public HandlingInput(Game game)
        {
            vGame = game;
        }

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
            { return false; }
            if (c.CommandWord == "engine")
            {
                if (c.SecondWord == "go")
                {
                    foreach (Location room in vGame.GetRooms().GetRooms())
                    {
                        if (c.ThirdWord == room.GetID().ToString())
                        {
                            vGame.MoveEngine(room);
                            return true;
                        }
                        return false;
                    }
                }
            }
            return false;
        }
    }
}