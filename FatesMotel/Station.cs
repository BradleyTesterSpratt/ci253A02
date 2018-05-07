using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    //station inherits from Location class
    class Station : Location
    {
        //station int id set and string name
        public Station(int StationID, string StationName)
        {
            vLocationID = StationID;
            vLocationName= StationName;
        }
    }

}
