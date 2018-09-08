namespace MySample.Features
{
    using xBDD;

    public class FeatureTestClass: IFeature
    {
        public IOutputWriter OutputWriter { get; private set; }

		public FeatureTestClass()
		{
			this.OutputWriter = new TestContextWriter();
		}
    }
}
