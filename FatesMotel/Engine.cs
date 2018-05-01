using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Engine
    {
        private int vEngineID;
        private int vCoolantLevel;
        private enum State
        {
            FREE,
            ONCALL,
            STATIONED
        };
        private State vCurrentState;
        private Location vCurrentLocation;

        public object VCurrentLocation { get; private set; }

        public Engine(Location location, int engineID)
        {
            vEngineID = engineID;
            vCoolantLevel = 600;
            vCurrentLocation = location;
            SetState();
        }

        private void SetState()
        {
            if (vCurrentLocation.GetType() == typeof(Room))
            {
                Room vCurrentRoom = (Room)vCurrentLocation;
                if (vCurrentRoom.GetState() == Room.State.BURNEDOUT || vCurrentRoom.GetState() == Room.State.SAFE)
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

        public void GetState()
        {

        }

        public void Move(Location vDestination)
        {
            VCurrentLocation.GetType();
            SetState();
        }

        private void Extinguish()
        {

            /*check coolant level
            /if room can cool down 
            /cool by (set) tick
            /reduce extinguish level
            /room temp down 1 state?
            */
            if (vCoolantLevel >= 40)
            {
                vCoolantLevel -= 40;


                 else if (vCoolantLevel <= 39)
                 {
                Console.WriteLine("Engine empty");
                 }
           

            }


        }

        private void Refill()
        {
            //if (vCurrentLocation == Station)

            // if coolant less than full
            // add x coolant

            //if coolant greater than full
            //set to full
            Console.WriteLine("Engine refilled");


            

            else
            {
                Console.WriteLine("Engine not in station");
            }
        }

    }

    public void Report()
    {
        GetCoolant();
        Room currentRoom = (Room)vCurrentLocation;
        currentRoom.getState();
    }

    public void OnTick()
    {
         SetState();

        if (vCurrentState == State.ONCALL)

        {
            Extinguish();
        }

        //if state is ONCALL
        //if state is STATIONED refill
        //if STATE is FREE do nothing?
    }
}


