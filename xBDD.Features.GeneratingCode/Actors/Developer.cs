namespace xBDD.Features.GeneratingCode.Actors
{
	using xBDD;
	using xBDD.Model;
	using xBDD.Utility;
	using xBDD.Features.GeneratingCode.Interfaces;
    using System.Diagnostics;
	using System.IO;
	using TemplateValidator;
	public class Developer
	{
		public Step HaveAnEmptyProjectDirectory() {
			return xB.CreateStep("you have an empty project directory",
				s => {
					var directory = "./MyGeneratedSample.Features";
					if(System.IO.Directory.Exists(directory)) {
						System.IO.Directory.Delete(directory, true);		
					} 
					System.IO.Directory.CreateDirectory(directory);
				}, null, TextFormat.text, "Creates a MySample.Generated folder that will contain the test project files. Deletes all content under the folder if it already exists.");
		}
		public Step RunTheCommand (string command, string directory) {
            var fullCommand = $"{command} | Out-File output.txt";
			return xB.CreateStep("you run the command:",
				s => {
					this.ExecuteCommand(s, directory, fullCommand);
				},
				command,
				TextFormat.sh,
				"Executes the command in powershell.");
		}

		private void ExecuteCommand(Step s, string directory, string fullCommand) {
			Process cmd = new Process();
			cmd.StartInfo.FileName = "pwsh";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.Start();

			cmd.StandardInput.WriteLine($"Set-Location {directory}");
			cmd.StandardInput.Flush();
			cmd.StandardInput.WriteLine(fullCommand);
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			cmd.WaitForExit(60000);
			cmd.Close();
			cmd.Dispose();
			using (var fileStream = new FileStream($"{directory}/output.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (var textReader = new StreamReader(fileStream))
				{
					s.Output = textReader.ReadToEnd();
					s.OutputFormat = TextFormat.text;
				}
			}
		}

		public Step WillFindAValidFile (FileMetadata fileMetaData) {
			var template = "";
			try {
				template = System.IO.File.ReadAllText(fileMetaData.TemplatePath);
			} catch (System.Exception ex) {
				template = $"There was an exception loading the template ('{fileMetaData.TemplatePath}'). Exception Message: {ex.Message}";
			}
			return xB.CreateStep($"you will find a file at '{fileMetaData.FilePath}' that matches the template:",
				s => {
					var fileText = System.IO.File.ReadAllText(fileMetaData.FilePath);
					s.Output = fileText;
					s.OutputFormat = TextFormat.cs;
					fileText.ValidateToTemplate(template);
				}, template, TextFormat.cs);
		}

		public Step WillFindTheProjectExecutesTests () {
            var fullCommand = $"dotnet test | Out-File output.txt";
			return xB.CreateStep("you will find the project execute tests with the 'dotnet test' command",
				s => {
					this.ExecuteCommand(s, "./MyGeneratedSample.Features", fullCommand);
				},
				"dotnet test",
				TextFormat.sh,
				"Executes the command in powershell.");
		}

		public Step WillFindTheProjectGenerated (ReportType reportType) {
			var reportName = System.Enum.GetName(typeof(ReportType), reportType);
			var baseUrl = "./MyGeneratedSample.Features/test-results/MyGeneratedSample.Features.Results";
			string reportPath = "";
			TextFormat format = new TextFormat();
			switch(reportType) {
				case ReportType.HtmlReport:
					reportPath = $"{baseUrl}.html";
					format = TextFormat.htmlpreview;
				break;
				case ReportType.JsonReport:
					reportPath = $"{baseUrl}.json";
					format = TextFormat.js;
				break;
				case ReportType.OpmlReport:
					reportPath = $"{baseUrl}.opml";
					format = TextFormat.xml;
				break;
				case ReportType.TextOutlineReport:
					reportPath = $"{baseUrl}.Outline.txt";
					format = TextFormat.text;
				break;
				case ReportType.TextReport:
					reportPath = $"{baseUrl}.txt";
					format = TextFormat.text;
				break;
			}
			return xB.CreateStep($"you will find the project generated a {reportName.ConvertNamespaceToAreaName()}.",
				s => {
					var report = System.IO.File.ReadAllText(reportPath);
					s.Output = report;
					s.OutputFormat = format;
				}, reportPath, TextFormat.sh);
		}
		public Step ModifyAllTheStandardProjectFiles() {
			return xB.CreateStep("you modify all the standard project files",
				s => {
					throw new System.NotImplementedException();
				});
		}
		public Step WillFindTheFilesEndingInXbddDotFileTypeOrXbddAreOverwritten() {
			return xB.CreateStep("you will find the files ending in xbdd.[ext] or xbdd are overwritten",
				s => {
					throw new System.NotImplementedException();
				});
		}

		public Step WillFindTheFilesNotEndingInXbddDotFileTypeOrXbddAreNotOverwritten() {
			return xB.CreateStep("you will find the files not ending in xbdd.[ext] or xbdd are not overwritten",
				s => {
					throw new System.NotImplementedException();
				});
		}

		public Step WillFindTheSampleFeatureFileIsNotModifiedBecauseTheXbddBacklogFileAlreadyExisted() {
			return xB.CreateStep("you will find the sample feature file is not modified because the xbdd backlog file already exists",
				s => {
					throw new System.NotImplementedException();
				});
		}
		public Step WillFindTheProjectCompiles() {
			return xB.CreateStep("you will find the project compiles",
				s => {
					throw new System.NotImplementedException();
				});
		}
	}
}