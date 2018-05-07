using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Command
    {
        public String CommandWord { get; set; } //gets the use of the first word
        public String SecondWord { get; set; } //gets the use of the second word
        public String ThirdWord { get; set; } //allows the use of the third word
        public String FourthWord { get; set; } //gets the use of the fourth word
        public Boolean IsUnknown { get { return (CommandWord == null); } } //if the word is not recognised it will come out as null

    }
}
