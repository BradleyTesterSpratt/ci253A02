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
            vCurrentState === Engine.State();
        }

        public void Move(Location vDestination)
        {
            vCurrentLocation.GetType();
            SetState();
        }

        private void Extinguish()
        {
                
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
            if (vCurrentLocation == Location.Station)
            {
                // if coolant less than full
                // add x coolant
                if (vCoolantLevel < 600)
                {
                    vCoolantLevel = 600;
                    Console.WriteLine("Engine refilled");
                }
                //if coolant greater than full
                //set to full
                else if (vCoolantLevel > 600)
                {
                    vCoolantLevel = 600;
                }
            }
           
            
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
        //if state is ONCALL
        if (vCurrentState == State.ONCALL)

        {
            Extinguish();
        }
        //if state is STATIONED refill
        else if (vCurrentState == State.Stationed)
        {
            vCoolantLevel = Refill(max);
        }
        //if STATE is FREE do nothing?
        else if (vCurrenState == State.FREE)
        {
            Console.WriteLine("Engine is free to move")
        }

    }
}


