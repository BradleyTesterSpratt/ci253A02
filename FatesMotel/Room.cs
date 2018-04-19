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
        enum vState { SAFE, DANGER, SMOULDER, FIRE, BURNEDOUT};
        private Boolean vHeatUp;

    
        public Room(int RoomID)
        {
            vLocationID = RoomID;
            vTemperature = 1;
            vNeighbors = new HashSet<Room>();
            vLocationName = vLocationID.ToString();
            vHeatUp = false;
        }

        public void mSetNeighbors(Room neighbor)
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
        public void mPrintNeighbors()
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

        public void mHeatUp()
        {
            vHeatUp = true;
        }

        private void mGetNeighbors()
        {
            //check if the room can affect other rooms
            if (vTemperature >= 150)
            {
                foreach (Room neighbor in vNeighbors)
                {
                    //check the other room is not SAFE
                    if (neighbor.vTemperature>0)
                    {
                        neighbor.mHeatUp();
                    }
                }
            }
        }

        private void mBurn()
        {
            //increase temperature
        }
        public void mOnTick()
        {
            if (vHeatUp == true)
            {
                mGetNeighbors();
                mBurn();
            }
        }
    }
}
