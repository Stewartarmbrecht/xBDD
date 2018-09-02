namespace xBDD.Features.GeneratingCode.Actors
{
	using xBDD;
	using xBDD.Model;
	using xBDD.Utility;
	using xBDD.Features.GeneratingCode.Interfaces;
    using System.Diagnostics;
	using System.IO;
	using System.Text;
	using TemplateValidator;
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
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
		public Step Add(FileMetadata fileMetaData) {
			return xB.CreateStep($"add a {fileMetaData.StepNameAddition} file",
				s => {
					var filePath = "./MyGeneratedSample.Features/xBDDFeatureImport.txt";
					System.IO.File.Copy(fileMetaData.FilePath, filePath);
					s.Output = System.IO.File.ReadAllText(filePath);
					s.OutputFormat = TextFormat.text;
				});
		}
		public Step RunTheXbddToolsCommand (string[] args, string directory) {
            //var fullCommand = $"{command} | Out-File output.txt";
			return xB.CreateStep("you run the command:",
				s => {
					this.ExecuteXbddToolsCommand(s, directory, args);
				},
				$"dotnet xbdd {string.Join(" ",args)}",
				TextFormat.sh,
				"Executes the command in powershell.");
		}

		private void ExecuteXbddToolsCommand(Step s, string directory, string[] fullCommand) {
			xBDD.Tools.Program program = new xBDD.Tools.Program();
			var currentDirectory = System.IO.Directory.GetCurrentDirectory();
			System.IO.Directory.SetCurrentDirectory(directory);
			var mockConsole = new Mocks.MockConsole();
			xBDD.Tools.Program.Test(mockConsole, fullCommand);
			var output = mockConsole.Output.GetStringBuilder().ToString();
			System.IO.File.WriteAllText("output.txt", output);
			System.IO.Directory.SetCurrentDirectory(currentDirectory);
			s.Output = output;
			s.OutputFormat = TextFormat.text;

			// Process cmd = new Process();
			// cmd.StartInfo.FileName = "pwsh";
			// cmd.StartInfo.RedirectStandardInput = true;
			// cmd.StartInfo.RedirectStandardOutput = true;
			// cmd.StartInfo.CreateNoWindow = true;
			// cmd.StartInfo.UseShellExecute = false;
			// cmd.Start();

			// cmd.StandardInput.WriteLine($"Set-Location {directory}");
			// cmd.StandardInput.Flush();
			// cmd.StandardInput.WriteLine(fullCommand);
			// cmd.StandardInput.Flush();
			// cmd.StandardInput.Close();
			// cmd.WaitForExit(60000);
			// cmd.Close();
			// cmd.Dispose();
			// using (var fileStream = new FileStream($"{directory}/output.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			// {
			// 	using (var textReader = new StreamReader(fileStream))
			// 	{
			// 		s.Output = textReader.ReadToEnd();
			// 		s.OutputFormat = TextFormat.text;
			// 	}
			// }
		}

		private void ExecutePowershellCommand(Step s, string directory, string fullCommand) {

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
			var stepName = $"you will find a file at '{fileMetaData.FilePath}' that matches the template:";
			return this.ValidateFileAgainstTemplate(fileMetaData, stepName);
		}

		public Step WillSeeOutputWithAnException(FileMetadata fileMetaData) {
			var stepName = $"you will see output with an exception for {fileMetaData.StepNameAddition}";
			return this.ValidateFileAgainstTemplate(fileMetaData, stepName);
		}

		private Step ValidateFileAgainstTemplate(FileMetadata fileMetaData, string stepName) {
			var template = "";
			try {
				template = System.IO.File.ReadAllText(fileMetaData.TemplatePath);
			} catch (System.Exception ex) {
				template = $"There was an exception loading the template ('{fileMetaData.TemplatePath}'). Exception Message: {ex.Message}";
			}
			return xB.CreateStep(stepName,
				s => {
					var fileText = System.IO.File.ReadAllText(fileMetaData.FilePath);
					s.Output = fileText;
					s.OutputFormat = TextFormat.cs;
					fileText.ValidateToTemplate(template);
				}, template, TextFormat.cs);
		}

		private void UpdateProjectFileToLocalReference() {
			var fileSystem = new xBDD.Features.GeneratingCode.Interfaces.FileSystem();
			var projectFilePath = fileSystem.MyGeneratedSample_Features.MyGeneratedSample_Features_csproj.FilePath;
			var projectFileContent = System.IO.File.ReadAllText(projectFilePath);
			projectFileContent = projectFileContent.Replace(
				@"
						<PackageReference Include=""xBDD"" Version=""0.0.7-alpha"" />
					</ItemGroup>".RemoveIndentation(4, true), 
				@"
					</ItemGroup>

					<ItemGroup>
						<ProjectReference Include=""..\..\..\..\..\xBDD\xBDD.csproj"" />
					</ItemGroup>".RemoveIndentation(4, true));
			System.IO.File.Delete(projectFilePath);
			System.IO.File.WriteAllText(projectFilePath, projectFileContent);
		}

		public Step WillFindTheProjectExecutesTests () {
            var fullCommand = $"dotnet test | Out-File output.txt";
			return xB.CreateStep("you will find the project execute tests with the 'dotnet test' command",
				s => {
					this.UpdateProjectFileToLocalReference();
					this.ExecutePowershellCommand(s, "./MyGeneratedSample.Features", fullCommand);
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
			var fileStructure = new xBDD.Features.GeneratingCode.Interfaces.FileSystem();
			List<FileMetadata> standardFilePaths = new List<FileMetadata>() {
				fileStructure.MyGeneratedSample_Features.Features_MySampleArea_MySampleFeature_cs,
				fileStructure.MyGeneratedSample_Features.MyGeneratedSample_Features_csproj,
				fileStructure.MyGeneratedSample_Features.MyGeneratedSample_Features_csproj_xbdd,
				fileStructure.MyGeneratedSample_Features.xBddConfig_json,
				fileStructure.MyGeneratedSample_Features.xBddFeatureBase_xbdd_cs,
				fileStructure.MyGeneratedSample_Features.xBddFeatureImport_txt,
				fileStructure.MyGeneratedSample_Features.xBDDInitializeAndComplete_cs,
				fileStructure.MyGeneratedSample_Features.xBddSorting_cs,
				fileStructure.MyGeneratedSample_Features.xBddSorting_xbdd_cs
			};
			return xB.CreateStep("you modify all the standard project files",
				s => {
					standardFilePaths.ForEach(x => {
						var content = System.IO.File.ReadAllText(x.FilePath);
						content = $"{x.ModifiedComment}{content}";
						System.IO.File.WriteAllText(x.FilePath, content);
					});
				});
		}
		public Step WillFindTheFilesEndingInXbddAreOverwritten() {
			var fileStructure = new xBDD.Features.GeneratingCode.Interfaces.FileSystem();
			List<FileMetadata> standardFilePaths = new List<FileMetadata>() {
				fileStructure.MyGeneratedSample_Features.MyGeneratedSample_Features_csproj_xbdd,
				fileStructure.MyGeneratedSample_Features.xBddFeatureBase_xbdd_cs,
				fileStructure.MyGeneratedSample_Features.xBddSorting_xbdd_cs
			};
			return xB.CreateStep("you will find the files ending in xbdd.[ext] or xbdd are overwritten",
				s => {
					standardFilePaths.ForEach(x => {
						var content = System.IO.File.ReadAllText(x.FilePath);
						Assert.IsTrue(!content.StartsWith(x.ModifiedComment));
					});
				});
		}

		public Step WillFindTheFilesNotEndingInXbddAreNotOverwritten() {
			var fileStructure = new xBDD.Features.GeneratingCode.Interfaces.FileSystem();
			List<FileMetadata> standardFilePaths = new List<FileMetadata>() {
				fileStructure.MyGeneratedSample_Features.MyGeneratedSample_Features_csproj,
				fileStructure.MyGeneratedSample_Features.xBddConfig_json,
				fileStructure.MyGeneratedSample_Features.xBddFeatureImport_txt,
				fileStructure.MyGeneratedSample_Features.xBDDInitializeAndComplete_cs,
				fileStructure.MyGeneratedSample_Features.xBddSorting_cs,
			};
			return xB.CreateStep("you will find the files not ending in xbdd.[ext] or xbdd are not overwritten",
				s => {
					standardFilePaths.ForEach(x => {
						var content = System.IO.File.ReadAllText(x.FilePath);
						Assert.IsTrue(content.StartsWith(x.ModifiedComment),
							$"the file ('{x.FilePath}') does not start with '{x.ModifiedComment}'");
					});
				});
		}

		public Step WillFindTheSampleFeatureFileIsNotModifiedBecauseTheXbddBacklogFileAlreadyExisted() {
			var fileStructure = new xBDD.Features.GeneratingCode.Interfaces.FileSystem();
			List<FileMetadata> standardFilePaths = new List<FileMetadata>() {
				fileStructure.MyGeneratedSample_Features.Features_MySampleArea_MySampleFeature_cs,
			};
			return xB.CreateStep("you will find the sample feature file is not modified because the xbdd backlog file already exists",
				s => {
					standardFilePaths.ForEach(x => {
						var content = System.IO.File.ReadAllText(x.FilePath);
						Assert.IsTrue(content.StartsWith(x.ModifiedComment),
							$"the file ('{x.FilePath}') does not start with '{x.ModifiedComment}'");
					});
				});
		}
	}
}