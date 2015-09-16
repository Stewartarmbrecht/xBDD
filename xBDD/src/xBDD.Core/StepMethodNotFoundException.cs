using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public class StepMethodNotFoundException : Exception
    {
        public StepMethodNotFoundException() :
            base("The step method could not be found.  Due to cross platform limitations, xBDD can only find method names on methods that are directly declared in the parent class.  It can not find names for inherited methods.")
        {

        }
    }
}
