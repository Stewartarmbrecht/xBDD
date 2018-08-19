namespace MySample.Actors
{
    using xBDD;
    using xBDD.Model;
    public class MyActor 
    {
        public const string Name = "My Actor";
        public Step ExcuteFirstAction()
        {
            return xB.CreateStep("you execute a first action", (step) => {});
        }
        public Step ExcuteAnotherAction()
        {
            return xB.CreateStep("you execute another action", (step) => {});
        }
        public Step WillSeeAResult()
        {
            return xB.CreateStep("you will see a result", (step) => {});
        }
    }
}