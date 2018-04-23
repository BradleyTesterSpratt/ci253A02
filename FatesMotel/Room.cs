using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Room : Location

    {

        private int vTemperature;
        private HashSet<Room> vNeighbors;
        enum State
        {
            SAFE,
            DANGER,
            SMOULDER,
            FIRE,
            BURNEDOUT
        };
        private Boolean vHeatUp;
        private State vCurrentState;

    
        public Room(int RoomID)
        {
            vLocationID = RoomID;
            vTemperature = 1;
            vNeighbors = new HashSet<Room>();
            vLocationName = vLocationID.ToString();
            vHeatUp = false;
        }

        public void SetNeighbors(Room neighbor)
        {
            if (neighbor.vLocationID == vLocationID-100 ||
                neighbor.vLocationID == vLocationID + 100 ||
                neighbor.vLocationID == vLocationID - 1 ||
                neighbor.vLocationID == vLocationID + 1)
            {
                vNeighbors.Add(neighbor);
            }
        }

        /* method only really suitable to check that 
         * motel is populating correctly
         * no other practical uses
         */
        public void PrintNeighbors()
        {
            Console.Write("Room "+ vLocationID + " is neighbored by ");
            for (int n=0; n<=vNeighbors.Count;n++)
            {
                if (n==(vNeighbors.Count-2))
                {
                    Console.Write("Room " + vNeighbors.ElementAt<Room>(n).vLocationID);
                }
                else if (n < (vNeighbors.Count - 1))
                {
                    Console.Write("Room " + vNeighbors.ElementAt<Room>(n).vLocationID + ", ");
                }
                else if (n == (vNeighbors.Count - 1))
                {
                    Console.Write(" and Room " +  vNeighbors.ElementAt<Room>(n).vLocationID + ".");
                }
            }
            Console.WriteLine();
        }

        public void HeatUp()
        {
            vHeatUp = true;
        }

        private void GetNeighbors()
        {
            //check if the room can affect other rooms
            if (vTemperature >= 150)
            {
                foreach (Room neighbor in vNeighbors)
                {
                    //check the other room is not SAFE
                    if (neighbor.vTemperature>0)
                    {
                        neighbor.HeatUp();
                    }
                }
            }
        }

        private void Burn()
        {
            //increase temperature
            vTemperature += 20;

        }
        public void OnTick()
        {
            if (vHeatUp == true)
            {
                GetNeighbors();
                Burn();
                GetState();
            }
        }

        //change to Switch?
        public void GetState()
        {
            if (vTemperature >= 0 && vTemperature < 150)
            {
                if  (vCurrentState != State.SAFE)
                {
                    Console.WriteLine(GetName() + " is SAFE");
                } 
                vCurrentState =State.SAFE;
            }
            else if (vTemperature >= 150 && vTemperature < 300)
            {
                if (vCurrentState != State.DANGER)
                {
                    Console.WriteLine(GetName() + " is DANGER");
                }
                vCurrentState = State.DANGER;
            }
            else if (vTemperature >= 300 && vTemperature < 600)
            {
                if (vCurrentState != State.SMOULDER)
                {
                    Console.WriteLine(GetName() + " is SMOULDER");
                }
                vCurrentState = State.SMOULDER;
            }
            else if (vTemperature >= 600 && vTemperature < 700)
            {
                if (vCurrentState != State.FIRE)
                {
                    Console.WriteLine(GetName() + " is FIRE");
                }
                vCurrentState = State.FIRE;
            }
            else
            {
                if (vCurrentState != State.BURNEDOUT)
                {
                    Console.WriteLine(GetName() + " is BURNEDOUT");
                }
                vCurrentState = State.BURNEDOUT;
            }
        }
        public void InitialBurn()
        {
            vTemperature=150;
        }
    }
}
