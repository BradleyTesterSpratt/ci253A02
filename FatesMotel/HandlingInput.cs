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
            while (!vGame.vGameOver)
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
                if (c.SecondWord == "report")
                {
                    vGame.EngineReport();
                    return true;
                }
                else if (c.SecondWord == "goto")
                {
                    foreach (Location room in vGame.GetRooms())
                    {
                        if (c.FourthWord == room.GetID().ToString())
                        {
                            vGame.MoveEngine(room);
                            return true;
                        }
                    }
                }
                else if (c.SecondWord=="recall")
                {
                    vGame.MoveEngine(vGame.GetRooms().ElementAt(0));
                }
                else if (c.SecondWord=="refill")
                {
                    vGame.EngineRefill();
                }
                else { return false; }
            }
            else if(c.CommandWord == "room")
            {
                if (c.SecondWord == "roomlist")
                {
                    vGame.RoomReport();
                    return true;
                }
                else if (c.SecondWord == "roomreport")
                {
                    vGame.GameReport();
                    return true;
                }
                else { return false; }
            }
            return false; 
        }
    }
}