namespace MySample.Actors
{
    using xBDD;
    using xBDD.Model;
    public class MyActor 
    {
        public const string Name = "My Actor";
        public Step ExcuteStep28()
        {
            return xB.CreateStep("you execute step 28", (step) => {});
        }
        public Step ExcuteStep29()
        {
            return xB.CreateStep("you execute step 29", (step) => {});
        }
        public Step ExcuteStep30()
        {
            return xB.CreateStep("you execute step 30", (step) => {});
        }
    }
}