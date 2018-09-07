namespace xBDD.Features.Common
{
	using xBDD;
	using xBDD.Model;
	using xBDD.Utility;
    using System.Diagnostics;
	using System.IO;
	using System.Text;
	using TemplateValidator;
	using System.Collections.Generic;
	
	public class Developer
	{
		private void UpdateProjectFileToLocalReference() {
			var projectFilePath = "./MyGeneratedSample.Features/MyGeneratedSample.Features.csproj";
			var projectFileContent = System.IO.File.ReadAllText(projectFilePath);
			projectFileContent = projectFileContent.Replace(
				@"
						<PackageReference Include=""xBDD"" Version=""0.0.8-alpha"" />
					</ItemGroup>".RemoveIndentation(4, true), 
				@"
					</ItemGroup>

					<ItemGroup>
						<ProjectReference Include=""..\..\..\..\..\xBDD\xBDD.csproj"" />
					</ItemGroup>".RemoveIndentation(4, true));
			System.IO.File.Delete(projectFilePath);
			System.IO.File.WriteAllText(projectFilePath, projectFileContent);
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
		public Step HaveAnEmptyDirectory(string directory) {
			return xB.CreateStep("you have an empty directory",
				s => {
					if(System.IO.Directory.Exists(directory)) {
						System.IO.Directory.Delete(directory, true);		
					} 
					System.IO.Directory.CreateDirectory(directory);
				}, null, TextFormat.text, "Creates a MySample.Generated folder that will contain the test project files. Deletes all content under the folder if it already exists.");
		}
		public Step RunTheXbddToolsCommand (string[] args, string directory, Wrapper<string> output = null) {
            //var fullCommand = $"{command} | Out-File output.txt";
			if(output == null)
				output = new Wrapper<string>();
			return xB.CreateStep("you run the command:",
				s => {
					xBDD.Tools.ToolsCLI program = new xBDD.Tools.ToolsCLI();
					var currentDirectory = System.IO.Directory.GetCurrentDirectory();
					System.IO.Directory.SetCurrentDirectory(directory);
					var mockConsole = new MockConsole();
					xBDD.Tools.ToolsCLI.Test(mockConsole, args);
					output.Object = mockConsole.Output.GetStringBuilder().ToString();
					System.IO.Directory.SetCurrentDirectory(currentDirectory);
					s.Output = output.Object;
					s.OutputFormat = TextFormat.text;
				},
				$"dotnet xbdd {string.Join(" ",args)}",
				TextFormat.sh,
				"Executes the command in powershell.");
		}
		public Step WillFindAMatchingFile (string filePath, string templatePath, TextFormat format) {
			var stepName = $"you will find a file at '{filePath}' that matches the template:";
			var template = "";
			var missingTemplate = false;
			try {
				template = System.IO.File.ReadAllText(templatePath);
			} catch (System.Exception ex) {
				template = $"There was an exception loading the template ('{templatePath}'). Exception Message: {ex.Message}";
				missingTemplate = true;
			}
			return xB.CreateStep(stepName,
				s => {
					var fileText = System.IO.File.ReadAllText(filePath);
					s.Output = fileText;
					s.OutputFormat = format;
					if(missingTemplate) {
						System.IO.File.WriteAllText(templatePath, fileText);
					}
					fileText.ValidateToTemplate(template);
				}, template, format);
		}
		public Step WillSeeOutput(string outputTemplate, Wrapper<string> output, bool templateFile = false) {
			var stepName = $"you will see output matching the following template:";
			var template = outputTemplate;
			var templateFound = false;
			if(templateFile) {
				if(System.IO.File.Exists(outputTemplate)) {
					template = System.IO.File.ReadAllText(outputTemplate);
					templateFound = true;
				}
				else {
					template = $"Error: The templat file ('{outputTemplate}') could not be found!";
				}
			}
			return xB.CreateStep(stepName,
				s => {
					if(templateFile && !templateFound) {
						System.IO.File.WriteAllText(outputTemplate, output.Object);
					}
					s.Output = output.Object;
					s.OutputFormat = TextFormat.cs;
					output.Object.ValidateToTemplate(template);
				}, template, TextFormat.text);
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
		public Step WillFind(string fileDescription, TextFormat format, string filePath) {
			return xB.CreateStep($"you will find {fileDescription} file located at '{filePath}'.",
				s => {
					var report = System.IO.File.ReadAllText(filePath);
					s.Output = report;
					s.OutputFormat = format;
				}, filePath, TextFormat.sh);
		}
		public Step WillNotFind(string fileDescription, string filePath) {
			return xB.CreateStep($"you will not find {fileDescription} located at '{filePath}'.",
				s => {
					if(System.IO.File.Exists(filePath)) {
						throw new System.Exception($"The file ('{filePath}') does exist.");
					}
				}, filePath, TextFormat.text);
		}
		public Step DoNotHave(string fileDescription, string filePath) {
			return xB.CreateStep($"you do not have {fileDescription} located at '{filePath}'.",
				s => {
					if(System.IO.File.Exists(filePath)) {
						System.IO.File.Delete(filePath);
					}
				}, filePath, TextFormat.text);
		}
	}
}