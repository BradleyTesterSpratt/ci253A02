using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    abstract class Location
    {

        protected int vLocationID;
        protected string vLocationName;

        public int mGetID()
        {
            return vLocationID;
        }

        public string mGetName()
        {
            return vLocationName;
        }
    }
}
