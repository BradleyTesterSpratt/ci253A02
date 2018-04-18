using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Program
    {
        
        

        static void Main(string[] args)
        {

            // add check that rooms are divisible by floors exactly
            double vRooms =27;
            int vFloors =2;
            int vRoomNum = 0;
            int vCurrentFloor = 1;
            HashSet<Location> vMotel = new HashSet<Location>();
            vMotel.Add(new Station(000, "Station"));


            for (int n=0; n<vRooms; n++)
            {
                int vFloorNo;
                double vRoomsPerFloor = Math.Ceiling(vRooms / vFloors);
                if (vRoomNum >= vRoomsPerFloor)
                {
                    vCurrentFloor += 1;
                    vRoomNum = 0;
                }

                vFloorNo = vCurrentFloor * 100 + 1;
            
                vMotel.Add(new Room(vRoomNum + vFloorNo));
                vRoomNum += 1;
            }


            for (int n = 0; n < vMotel.Count; n++)
            {
                if(vMotel.ElementAt(n).GetType() == typeof(Room))
                {
                    Room vCurrentLocation = (Room)vMotel.ElementAt(n);
                    foreach(Location vRoom in vMotel)
                    {
                        vCurrentLocation.mSetNeighbors(vRoom.mGetID());
                    }
                    Console.Write("Room " + vCurrentLocation.mGetID());
                    vCurrentLocation.mGetNeighbors();
                }
                

            }
            Console.ReadKey();

        }
    }
}
