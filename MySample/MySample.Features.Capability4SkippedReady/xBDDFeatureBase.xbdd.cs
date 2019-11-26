namespace MySample.Features.Capability4SkippedReady
{
	using xBDD;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;


	public partial class xBDDFeatureBase: IFeature, IOutputWriter
	{
		public IOutputWriter OutputWriter { get { return this; } }

		public void WriteLine(string text) {
			text = text.Replace("{", "{{").Replace("}","}}");
			Logger.LogMessage(text);
		}
	}
}