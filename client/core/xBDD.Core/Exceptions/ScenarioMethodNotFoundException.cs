using System;

namespace xBDD
{
    /// <summary>
    /// Unable to find the method that the scenario is for
    /// </summary>
    public class ScenarioMethodNotFoundException : Exception
    {
        internal ScenarioMethodNotFoundException() :
            base("The scenario method could not be found.  Due to cross platform limitations, xBDD can only find method names on methods that are directly declared in the parent class.  It can not find names for inherited methods.")
        {

        }
    }
}
