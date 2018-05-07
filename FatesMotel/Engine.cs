using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    internal class Engine
    {
        private int vEngineID;
        private int vCoolantLevel;
        public enum State
        {
            FREE,
            ONCALL,
            STATIONED
        };
        private State vCurrentState;
        private Location vCurrentLocation;
        private bool vFreeToMove;
        //for unit testing
        internal bool vCoolantTest;


        public Engine(Location location, int engineID)
        {
            vEngineID = engineID;
            vCoolantLevel = 600;
            vCurrentLocation = location;
            SetState();
            vFreeToMove = false;
        }

        private void SetState()
        {
            if (vCurrentLocation.GetType() == typeof(Room))
            {
                Room vCurrentRoom = (Room)vCurrentLocation;
                if (vCurrentRoom.GetState() == Room.State.BURNEDOUT || (vCurrentRoom.GetState() == Room.State.SAFE && vCurrentRoom.Extinguished()))
                {
                    vCurrentState = State.FREE;
                }
                else { vCurrentState = State.ONCALL; }
            }
            else if (vCurrentLocation.GetType() == typeof(Station))
            {
                vCurrentState = State.STATIONED;
            }
        }

        private void GetState()
        {
            if (vCurrentState == State.ONCALL)
            {
                Console.WriteLine("Engine is on call at " + vCurrentLocation.GetName());
                Room vCurrentRoom = (Room)vCurrentLocation;
                Console.WriteLine(vCurrentLocation.GetName() + " is currently " + vCurrentRoom.GetState());

            }
            else
            {
                Console.WriteLine("Engine is currently " + vCurrentState);
            }
        }

        public void Move(Location vDestination)
        {
            vCurrentLocation = vDestination;
            vFreeToMove = true;
            SetState();
            Console.WriteLine("Engine at " + vCurrentLocation.GetName());
        }

        private void GetCoolant()
        {
            Console.WriteLine("Engine coolant level is " + vCoolantLevel + " litres");
        }

        private void GetCurrentLocation()
        {
            Console.WriteLine("Engine is currently" + vCoolantLevel + " litres");
        }

        private void Extinguish()
        {
            Room vCurrentRoom = (Room)vCurrentLocation;

            if (vCoolantLevel >= 40)
            {
                vCoolantLevel -= 40;

                vCurrentRoom.Cool(40);
            }
            else
            {
                vCurrentRoom.Cool(vCoolantLevel);
                vCoolantLevel = 0;
                Console.WriteLine("Engine empty");
                Console.Write("Command: ");
            }

        }

        public void Refill()
        {

            if (vCurrentState == State.STATIONED)
            {
 
                // if coolant less than full
                // add x coolant
                if (vCoolantLevel >= 600)
                {

                    Console.WriteLine("Engine already full");
                    Console.Write("Command: ");
                    vCoolantTest = true;

                }
                //if coolant greater than full
                //set to full
                else if (vCoolantLevel < 600)
                {
                    vCoolantLevel = 600;
                    Console.WriteLine("Engine refilled");
                    Console.Write("Command: ");
                    vCoolantTest = true;
                }

            }
            else
            {
                Console.WriteLine("Engine not at station");
                Console.Write("Command: ");
                vCoolantTest = false;
            }
        }



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
            if (vCurrentState == State.ONCALL)

            {
                Extinguish();
            }

            //if STATE is FREE do nothing?
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


