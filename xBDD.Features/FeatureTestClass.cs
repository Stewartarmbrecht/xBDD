namespace xBDD.Features
{
    public class FeatureTestClass: IFeature
    {
        public IOutputWriter OutputWriter { get; private set; }

		public FeatureTestClass()
		{
			this.OutputWriter = new TestContextWriter();
		}
    }
}