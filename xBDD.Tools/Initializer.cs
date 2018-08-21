using McMaster.Extensions.CommandLineUtils;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Tools
{
    [Command(
          Name = "dotnet xbdd",
          FullName = "dotnet-xbdd",
          Description = "creates a new test project initialized for xBDD")]
    [HelpOption]
    public partial class Initializer
    {
        [Required(ErrorMessage = "You must specify a command")]
        [Argument(0, Name = "command", Description = "The xBDD command to execute")]
        public string Command { get; }

        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            var codeWriter = new xBDD.Reporting.Code.CodeWriter();
            var directory = System.IO.Directory.GetCurrentDirectory();
            var folder = directory.Substring(directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1, directory.Length - (directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar)+1));
            console.WriteLine($"Directory: {directory}");
            console.WriteLine($"Folder: {folder}");
            console.WriteLine($"Command: {this.Command}");
            codeWriter.WriteProjectFiles(directory, folder, folder);
            console.WriteLine($"Project initialized.");

            return Program.OK;
        }

    }
}
