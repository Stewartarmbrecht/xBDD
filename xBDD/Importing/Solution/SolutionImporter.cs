namespace xBDD.Importing.Solution
{
	using System;
	using System.Text;
	using xBDD.Model;
	using xBDD.Core;
	using xBDD.Utility;
	using xBDD;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	/// <summary>
	/// Imports a solution outline and creates an array of test runs.
	/// </summary>
	public class SolutionImporter
	{
		/// <summary>
		/// Imports a solution outline and creates an array of test runs.
		/// </summary>
		/// <param name="solutionOutline">The text of the solution outline to deserialize into test runs.</param>
		/// <param name="indentation">The standard form of indentation for example '\t' or '  ' - two spaces.</param>
		/// <returns>A string array of project folders that were created and where xBDDFeatureOutline.txt files were copied.</returns>
		public string[] ImportSolution(string solutionOutline, string indentation) {
			if(solutionOutline.StartsWith("Project:") == false) {
				throw new Exception("The first line must define a project. Ex. 'Project: My Project'.");
			}
			solutionOutline = solutionOutline.Substring(9,solutionOutline.Length - 9);
			string[] projectOutlines = solutionOutline.Split(
				new string[] { $"{System.Environment.NewLine}Project: " }, 
				System.StringSplitOptions.None);
			List<string> projectFolders = new List<string>();
			foreach(string projectFile in projectOutlines) {
				var fileContent = projectFile;
				if(fileContent.StartsWith("Project: ")) {
					fileContent = fileContent.Substring(9, projectFile.Length - 9);
				}
				var firstlineBreak = fileContent.IndexOf(System.Environment.NewLine);
				var secondLineStart = firstlineBreak + System.Environment.NewLine.Length + indentation.Length;
				var projectFolder = fileContent.Substring(0, fileContent.IndexOf(System.Environment.NewLine));
				projectFolders.Add(projectFolder);
				fileContent = fileContent.Substring(secondLineStart, fileContent.Length - secondLineStart);
				fileContent = fileContent.Replace($"{System.Environment.NewLine}{indentation}",System.Environment.NewLine);
				if(!System.IO.Directory.Exists(projectFolder)) {
					System.IO.Directory.CreateDirectory(projectFolder);
				}
				System.IO.File.WriteAllText($"{projectFolder}/xBDDFeatureImport.txt", fileContent);
			}
			return projectFolders.ToArray();
		}
	}
}