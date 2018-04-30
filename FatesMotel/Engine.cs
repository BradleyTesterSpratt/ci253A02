﻿using System;
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

        public void Move()
        {
            VCurrentRoom.getType();
            EngineState = Engine.ONCALL;


        }

        private void Extinguish()
        {
            //check coolant level
            //if room can cool down 
            //cool by (set) tick
            //reduce extinguish level
            //room temp down 1 state?

            else
            {
                Engine.StateEmpty
                Console.WriteLine("Engine empty");
                
            }


        }

        private void Refill()
        {
            if (vCurrentLocation == Station)
            {
                vCoolantLevel = full vCoolantLevel;
                Console.WriteLine("Engine refilled");
            }

            else
            {
                Console.WriteLine("Engine not in station");
            }
        }

        }

        private void Report()
        {

        }

        public void OnTick()
        {
            SetState();
            //if state, Extinguished or Refill
        }
    }
}
