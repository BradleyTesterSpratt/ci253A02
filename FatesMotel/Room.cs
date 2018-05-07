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
        public enum State
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
            vLocationName = "Room " + vLocationID.ToString();
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
        public bool Extinguished()
        {
            if (vTemperature<=0)
            {
                vTemperature = 0;
                return true;
            }
            else
            { return false; }
        }

        private void GetNeighbors()
        {
            //check if the room can affect other rooms
            if (vTemperature >= 150)
            {
                foreach (Room neighbor in vNeighbors)
                {
                      neighbor.HeatUp();
                }
            }
        }

        private void Burn()
        {
            //increase temperature
            vTemperature += 20;
        }

        public void Cool(int coolant)
        {
            //cool by amount of coolant given
            vTemperature -= coolant;
        }

        public void OnTick()
        {
            if (Extinguished()==false)
            {
                if (vHeatUp == true)
                {
                    GetNeighbors();
                    Burn();
                    SetState();
                }
            }
        }

        public void Report()
        {
            SetState();
            if (vCurrentState == State.SAFE)
            {
                Console.WriteLine(GetName() + " is SAFE");
            }
            else if (vCurrentState == State.DANGER)
            {
                Console.WriteLine(GetName() + " is in danger");
            }
            else if (vCurrentState == State.SMOULDER)
            {
                Console.WriteLine(GetName() + " is smouldering");
            }
            else if (vCurrentState == State.FIRE)
            {
                Console.WriteLine(GetName() + " is on fire");
            }
            else if (vCurrentState == State.BURNEDOUT)
            {
                Console.WriteLine(GetName() + " is BURNEDOUT");
            }
        }

        private void SetState()
        {
            if (vTemperature >= 0 && vTemperature < 150)
            {
                vCurrentState =State.SAFE;
            }
            else if (vTemperature >= 150 && vTemperature < 300)
            {
                    vCurrentState = State.DANGER;
            }
            else if (vTemperature >= 300 && vTemperature < 600)
            {
                    vCurrentState = State.SMOULDER;
            }
            else if (vTemperature >= 600 && vTemperature < 700)
            {
                    vCurrentState = State.FIRE;
            }
            else if (vCurrentState != State.BURNEDOUT)
            {
                    vCurrentState = State.BURNEDOUT;
            }
        }
        public void InitialBurn()
        {
            vTemperature=150;
        }

        public State GetState()
        {
            return vCurrentState;
        }
    }
}
