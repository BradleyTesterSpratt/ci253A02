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
        private HashSet<int> vNeighbors;
        enum vState { SAFE, DANGER, SMOULDER, FIRE, BURNEDOUT };
        Boolean vHeatUp;


        public Room(int RoomID)
        {
            vLocationID = RoomID;
            vTemperature = 0;
            vNeighbors = new HashSet<int>();
            vLocationName = vLocationID.ToString();
        }

        public void mSetNeighbors(int RoomID)
        {
            if (RoomID == vLocationID-100 || 
                RoomID == vLocationID + 100 || 
                RoomID == vLocationID - 1 || 
                RoomID == vLocationID + 1)
            {
                vNeighbors.Add(RoomID);
            }
        }

        public void mGetNeighbors()
        {
            Console.Write(" is neighbored by ");

            foreach (int vNeighborID in vNeighbors)
            {
                Console.Write("Room " + vNeighborID + ", ");
            }
            Console.WriteLine();
                
        }

        public void mCanBurn(short Temperature)
        {

        }


    }
}
