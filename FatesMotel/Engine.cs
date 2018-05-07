using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    internal class Engine
    {
        //create variables for engine and coolant
        //Enigines multiple STATE created
        private int vEngineID;
        private int vCoolantLevel;
        public enum State
        {
            FREE,
            ONCALL,
            STATIONED
        };
        //vCurrentState to call on STATE enums
        private State vCurrentState;
        //engine vCurrentLocation set
        private Location vCurrentLocation;
        //Engine can move between Locations - Room & Station
        private bool vFreeToMove;
        //for unit testing
        internal bool vCoolantTest;


        public Engine(Location location, int engineID)
        {
            /*
             * create engine ID, set coolant max level
             * set engine location
             * Engine requires command to move
            */
            vEngineID = engineID;
            vCoolantLevel = 600;
            vCurrentLocation = location;
            SetState();
            vFreeToMove = false;
        }

        private void SetState()
        {
            //if engine is at a room
            if (vCurrentLocation.GetType() == typeof(Room))
            {
                //check engine is at a room
                Room vCurrentRoom = (Room)vCurrentLocation;
                //if the room is safe or burned out, the engine can't extinguish, so is FREE
                if (vCurrentRoom.GetState() == Room.State.BURNEDOUT || (vCurrentRoom.GetState() == Room.State.SAFE && vCurrentRoom.Extinguished()))
                {
                    vCurrentState = State.FREE;
                }
                //else if the room STATE can be cooled the engine is ONCALL
                else { vCurrentState = State.ONCALL; }
            }
            //else if the engine is at Location STATION
            else if (vCurrentLocation.GetType() == typeof(Station))
            {
                vCurrentState = State.STATIONED;
            }
        }

        private void GetState()
        {
            if (vCurrentState == State.ONCALL)
            {
                //current state is ONCALL, display String and the engine current location
                Console.WriteLine("Engine is on call at " + vCurrentLocation.GetName());
                Room vCurrentRoom = (Room)vCurrentLocation;
                //room state is retrieved and printed
                Console.WriteLine(vCurrentLocation.GetName() + " is currently " + vCurrentRoom.GetState());

            }
            else
                //if egine is not ONCALL, print STATE
            {
                Console.WriteLine("Engine is currently " + vCurrentState);
            }
        }

        public void Move(Location vDestination)
        {
            //engine destination is currentlocaiton
            //allowing move bool to be true
            //set state according to its location
            //print string and location name
            vCurrentLocation = vDestination;
            vFreeToMove = true;
            SetState();
            Console.WriteLine("Engine at " + vCurrentLocation.GetName());
        }
        //Gets engine coolantLevel and prints to console
        private void GetCoolant()
        {
            Console.WriteLine("Engine coolant level is " + vCoolantLevel + " litres");
        }
        //Gets engine currentLoaction and prints to console
        private void GetCurrentLocation()
        {
            Console.WriteLine("Engine is currently" + vCoolantLevel + " litres");
        }

        private void Extinguish()
        {
            //find the room id of vCurrentLocation
            Room vCurrentRoom = (Room)vCurrentLocation;
            //check coolant level can decrease by 1 tick
            if (vCoolantLevel >= 40)
            {
                //coolant level reduced by 40 per tick/extinguish
                vCoolantLevel -= 40;
                //room cools by 40
                vCurrentRoom.Cool(40);
            }
            else
            {
                //if room can cool but vCoolantLevel is empty
                vCurrentRoom.Cool(vCoolantLevel);
                vCoolantLevel = 0;
                Console.WriteLine("Engine empty");
                Console.Write("Command: ");
            }

        }
        //method to allow vCoolantLevel to refill to max (600)
        public void Refill()
        {
            //Engine STATE checked to allow refill
            if (vCurrentState == State.STATIONED)
            {
<<<<<<< Updated upstream
 
                // if coolant less than full
                // add x coolant
=======
                // if coolant greater or equal 
                // engine is full
>>>>>>> Stashed changes
                if (vCoolantLevel >= 600)
                {

                    Console.WriteLine("Engine already full");
                    Console.Write("Command: ");
                    vCoolantTest = true;

                }
                //if coolant less than full
                //set to full
                else if (vCoolantLevel < 600)
                {
                    vCoolantLevel = 600;
                    Console.WriteLine("Engine refilled");
                    Console.Write("Command: ");
                    vCoolantTest = true;
                }

            }
            //if vCurrentLocation is not Station
            //Engine cannot refill
            else
            {
                Console.WriteLine("Engine not at station");
                Console.Write("Command: ");
                vCoolantTest = false;
            }
        }


        /*
         * Report produces the vCoolantLevel
         * Engine vCurrentState
         */
        public void Report()
        {
            Console.WriteLine("Engine Report: ");
            GetCoolant();
            GetState();
        }

        public void OnTick()
        {
            SetState();
            //if state is ONCALL
            //Engine can extinguish
            if (vCurrentState == State.ONCALL)

            {
                Extinguish();
            }

            //if STATE is FREE 
            //Free to move
            else if (vCurrentState == State.FREE)
            {
                if (vFreeToMove)
                {
                    Console.WriteLine("Engine is free to move");
                    Console.Write("Command: ");
                    vFreeToMove = false;
                }
            }

        }
        //method accessable for unit testing
        internal bool CoolantTest()
        {
            return vCoolantTest;
        }
    }
}


