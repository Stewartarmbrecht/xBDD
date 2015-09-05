using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public class StepMethodNotFoundException : Exception
    {
        public StepMethodNotFoundException() :
            base("The step method could not be found.  Could it be that it is in a step library that does not have the [StepLibrary] attribute?  If so add this attribute to the step library class.")
        {

        }
    }
}
