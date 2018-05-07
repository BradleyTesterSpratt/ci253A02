using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    internal abstract class Location
    {

        protected int vLocationID;
        protected string vLocationName;

        public int GetID()
        {
            return vLocationID;
        }

        public string GetName()
        {
            return vLocationName;
        }
    }
}
