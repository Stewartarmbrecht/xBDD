namespace xBDD.Features.Actors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;
    using System.Collections.Generic;
    using xBDD;
	using xBDD.Model;
    using xBDD.Browser;

	public class Developer: User
	{
		public const string Name = "developer";
		public Step HaveTheFollowingClass(string description, string pathToFile)
		{
            var step = xB.CreateStep(
                $"you have a similar class in your test project {description}:",
                (s) => { 
                    var path = System.IO.Directory.GetCurrentDirectory() + "../../../../../" + pathToFile;
                    
                    string code = null;
                    try {
                        code = File.ReadAllText(path);
                        s.Output = code;
                        s.OutputFormat = TextFormat.cs;
                    } catch(System.Exception ex)
                    {
                        code = $"Exception encountered getting file content: {ex.Message}";
                        s.Output = code;
                        s.OutputFormat = TextFormat.cs;
                        throw;
                    }
                });
            return step;

		}
		public Step RunTheTests(List<Func<Task>> scenarios, xBDDMock xBMock)
		{
            var step = xB.CreateAsyncStep(
                $"run the tests",
                async (s) => { 
                    var currentTestRun = xB.CurrentRun;
                    Exception exception = null;
                    xB.CurrentRun = xBMock.CurrentRun;
                    await scenarios.ForEachAsync(async scenario => {
                        if(exception == null) {
                            try {
                                await scenario();
                            } catch(Exception ex) {
                                exception = ex;
                            }
                        }
                    });
                    xB.CurrentRun = currentTestRun;
                }, "dotnet test", TextFormat.sh);
            return step;

		}
	}
}