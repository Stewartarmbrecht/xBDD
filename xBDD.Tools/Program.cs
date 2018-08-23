using McMaster.Extensions.CommandLineUtils;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Collections.Generic;
using xBDD.Importing.Text;
using xBDD;
using xBDD.Model;

namespace xBDD.Tools
{
    [Command(
          Name = "dotnet xbdd",
          FullName = "dotnet-xbdd",
          Description = "Creates a new test project initialized for xBDD"),
    Subcommand("init", typeof(Init)), 
    Subcommand("code", typeof(Code))]
    [HelpOption]
    class Program
    {
        public static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        // Return codes
        public const int EXCEPTION = 2;
        public const int ERROR = 1;
        public const int OK = 0;

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify at a subcommand.");
            app.ShowHelp();
            return 1;
        }

        /// <summary>
        /// <see cref="HelpOptionAttribute"/> must be declared on each type that supports '--help'.
        /// Compare to the inheritance example, in which <see cref="GitCommandBase"/> delcares it
        /// once so that all subcommand types automatically support '--help'.
        /// </summary>
        [Command("init", Description = "Initializes a new test project in the current folder."),
         Subcommand("mstest", typeof(MSTest)),
         Subcommand("xunit", typeof(XUnit))]
        private class Init
        {
            private int OnExecute(IConsole console)
            {
                console.Error.WriteLine("You must specify an action. See --help for more details.");
                return 1;
            }

            [Command(Description = "Creates an MSTest project that uses xBDD."), HelpOption]
            private class MSTest
            {
                private int OnExecute(IConsole console)
                {
                    try {
                        var codeWriter = new xBDD.Reporting.Code.CodeWriter();
                        var directory = System.IO.Directory.GetCurrentDirectory();
                        var folder = directory.Substring(directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1, directory.Length - (directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar)+1));
                        console.WriteLine($"Directory: {directory}");
                        console.WriteLine($"Folder: {folder}");
                        codeWriter.WriteProjectFiles(directory, folder, folder);
                        console.WriteLine($"Project initialized.");
                        return 0;
                    } catch (Exception ex) {
                        console.Error.WriteLine(ex.Message);
                        console.Error.WriteLine(ex.StackTrace);
                        return 1;
                    }
                }
            }

            [Command(Description = "Creates an MSTest project that uses xBDD."), HelpOption]
            private class XUnit
            {
                private int OnExecute(IConsole console)
                {
                    console.Error.WriteLine("This feature still needs to be implemented.");
                    return 1;
                }
            }
        }

        [Command("code",
            Description = "Generates feature code for the source you specify.")]
        private class Code
        {
            [Option("-s|--source-file", "Sets the path to the source file.", CommandOptionType.SingleValue)]
            [FileExists]
            public string SourceFile { get; }
            
            [Option("-st|--source-type", "Sets the source type.", CommandOptionType.SingleValue)]
            public SourceType SourceType { get; }
            
            [Option("-d|--destination-file", "Sets the source type.", CommandOptionType.SingleValue)]
            [DirectoryExists]
            public string Destination { get; }
            
            [Option("-i|--indentation", "Sets the string used to indent a level in the text file.", CommandOptionType.SingleValue)]
            public string Indentation { get; }
            
            [Option("-rn|--root-namespace", "Sets the root namespace for the generated feature files.", CommandOptionType.SingleValue)]
            public string RootNamespace { get; }
            
            [Option("-sr|--skip-reason", "Sets the default skip reason for all scenarios.", CommandOptionType.SingleValue)]
            public string SkipReason { get; }

            [Option("-fo|--features-only", "Sets the code generator to only generate feature files.", CommandOptionType.SingleValue)]
            public bool FeaturesOnly { get; }

            [Option("-ran|--remove-area-name", "Sets the remove from area name start setting for report generation in the new project.", CommandOptionType.SingleValue)]
            public string RemoveAreaNameStart { get; }

            private int OnExecute(IConsole console)
            {
                try {
                    string source = System.IO.File.ReadAllText(SourceFile);
                    console.WriteLine($"Source Type: {SourceType}");
                    console.WriteLine($"Source Length: {source.Length}");
                    switch (this.SourceType)
                    {
                        case SourceType.Text:
                            console.WriteLine($"Source File: {SourceFile}");
                            console.WriteLine($"Indentation: {Indentation}");
                            console.WriteLine($"Root Namespace: {RootNamespace}");
                            console.WriteLine($"Skip Reason: {SkipReason}");
                            TextImporter textImporter = new TextImporter();
                            console.WriteLine($"Source Content:");
                            console.WriteLine(source);
                            TestRun testRun = textImporter.ImportText(source, Indentation, RootNamespace, SkipReason);
                            console.WriteLine($"Test Run Scenario Count: {testRun.Scenarios.Count}");
                            if(FeaturesOnly) {
                                console.WriteLine($"Writing Feautres Only To: {Destination}");
                                testRun.WriteFeaturesToCode(RootNamespace, Destination);
                            } else {
                                console.WriteLine($"Writing All Code To: {Destination}");
                                console.WriteLine($"Using Area Name Clipping Setting: {RemoveAreaNameStart}");
                                testRun.WriteToCode(RootNamespace, Destination, RemoveAreaNameStart);
                            }
                        break;
                        default:
                            console.Error.WriteLine($"The source type of '{this.SourceType}' is not currently supported.");
                        break;
                    }
                    return 0;
                } catch (Exception ex) {
                    console.Error.WriteLine(ex.Message);
                    return 1;
                }
            }
        }    
    }
}