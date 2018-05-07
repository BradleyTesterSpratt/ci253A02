using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class HandlingInput
    {
        private Parser parser = new Parser(); //Allows the use of the paser in this class by making it a new parser
        private Game vGame; //Allows the use game in the class

        public HandlingInput(Game game)
        {
            vGame = game;
        }

        public void Play()
        {
            Boolean finished = false; //starts playing the game
            while (!vGame.vGameOver)
            {
                Console.Write("Command: ");
                Command command = parser.GetCommand();
                finished = ProcessCommand(command);
            }
        }

        private Boolean ProcessCommand(Command c) //processes the command words typed by the user 
        {
            if (c.IsUnknown)
            { return false; }

            if (c.CommandWord == "engine") //gets the engine as a command word
            {
                if (c.SecondWord == "report") //then takes the word report as a second word
                {
                    vGame.EngineReport();
                    return true; // will return it as ture if typed correctly
                }
                else if (c.SecondWord == "goto") //takes in the phrase of goto adn this allows the use of room IDs
                {
                    foreach (Location room in vGame.GetRooms())
                    {
                        if (c.FourthWord == room.GetID().ToString()) //gets the room ID and then converts it into a string
                        {
                            vGame.MoveEngine(room);
                            return true; //if true moves the engine to the correct room
                        }
                    }
                }
                else if (c.SecondWord=="recall") //allows the use of racall
                {
                    vGame.MoveEngine(vGame.GetRooms().ElementAt(0));
                }
                else if (c.SecondWord=="refill") //allows the use of refill
                {
                    vGame.EngineRefill();
                }
                else { return false; } //this will then refill the engine 
            }
            else if(c.CommandWord == "room")
            {
                if (c.SecondWord == "list") //gets room infomation
                {
                    vGame.RoomReport(); // shows the report on the room
                    return true;
                }
                else if (c.SecondWord == "report")
                {
                    vGame.GameReport(); //gets a report on the actual game 
                    return true;
                }
                else { return false; }
            }
            else if (c.CommandWord == "clear"){
                Console.Clear(); //This will then clear the text feild so it will then be showing a blank page
                return true;
            }
            else if (c.CommandWord == "quit"){ //if the command word of quit has been typed it will 
                vGame.vGameOver = true; //set the game as game over 
                Console.Clear(); //and then clear the screen to show the game has finished
                vGame.End();
                return true;
            }
            return false; 
        }
    }
}