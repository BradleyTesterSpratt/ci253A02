using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Station : Location
    {
        public Station(int StationID, string StationName)
        {
            vLocationID = StationID;
            vLocationName= StationName;
        }
    }

}
