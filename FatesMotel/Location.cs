using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    internal abstract class Location
    {
        /*protected allows dervied classes to access
         * ID and Name
        */
        protected int vLocationID;
        protected string vLocationName;
        //Gets location ID
        public int GetID()
        {
            return vLocationID;
        }
        //Gets Location Name
        public string GetName()
        {
            return vLocationName;
        }
    }
}
