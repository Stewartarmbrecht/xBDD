namespace xBDD.Features.GeneratingCode
{
	using xBDD;
	using xBDD.Model;
	public class Developer
	{
		public Step HaveAnEmptyProjectDirectory() {
			return xB.CreateStep("You have an empgy project directory",
				s => {
					if(System.IO.Directory.Exists("./MySample.Generated")) {
						System.IO.Directory.Delete("./MySample.Generated");		
					} 
					System.IO.Directory.CreateDirectory("./MySample.Generated");
				});
		}
		
	}
}