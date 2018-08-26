﻿using McMaster.Extensions.CommandLineUtils;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Collections.Generic;
using xBDD.Importing.Text;
using xBDD.Importing.Json;
using xBDD;
using xBDD.Model;

namespace xBDD.Tools
{
    [Command(
          Name = "dotnet xbdd",
          FullName = "dotnet-xbdd",
          Description = "Creates a new test project initialized for xBDD"),
    Subcommand("init", typeof(Init)), 
    Subcommand("convert", typeof(Convert))]
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

        [Command("convert",
            Description = "Converts from one TestRun serialization format to another.")]
        private class Convert
        {
            [Option("-s|--source-file", "Sets the path to the source file.", CommandOptionType.SingleValue)]
            [FileExists]
            public string SourceFile { get; }
            
            [Option("-sf|--source-format", "Designates the format of the source.", CommandOptionType.SingleValue)]
            public SourceFormat SourceFormat { get; }
            
            [Option("-d|--destination-file", "Sets the source type.", CommandOptionType.SingleValue)]
            [DirectoryExists]
            public string Destination { get; }
            
            [Option("-dt|--destination-format", "Sets the de type.", CommandOptionType.SingleValue)]
            public DestinationFormat DestinationFormat { get; }
            
            [Option("-ti|--text-indentation", "Sets the string used to indent a level in the text file.", CommandOptionType.SingleValue)]
            public string TextIndentation { get; }
            
            [Option("-rn|--root-namespace", "Sets the root namespace for the generated feature files.", CommandOptionType.SingleValue)]
            public string RootNamespace { get; }
            
            [Option("-trn|--testrun-name", "Sets the default name for the test run when the tests are executed.", CommandOptionType.SingleValue)]
            public string TestRunName { get; }
            
            [Option("-dsr|--default-skip-reason", "Sets the default skip reason for all scenarios.", CommandOptionType.SingleValue)]
            public string DefaultSkipReason { get; }

            [Option("-fo|--features-only", "Sets the code generator to only generate feature files.", CommandOptionType.SingleValue)]
            public bool FeaturesOnly { get; }

            [Option("-ans|--area-name-skip", "The part of the area name so skip when writing certain reports.  Full Area names can be repetitive in a test project that covers a subset of features.", CommandOptionType.SingleValue)]
            public string AreaNameSkip { get; }

            private int OnExecute(IConsole console)
            {
                try {
                    TestRun testRun = null;
                    string source = System.IO.File.ReadAllText(SourceFile);
                    console.WriteLine($"Source Type: {SourceFormat}");
                    console.WriteLine($"Source Length: {source.Length}");
                    switch (this.SourceFormat)
                    {
                        case SourceFormat.Text:
                            console.WriteLine($"Source File: {SourceFile}");
                            console.WriteLine($"Indentation: {TextIndentation}");
                            console.WriteLine($"Root Namespace: {RootNamespace}");
                            console.WriteLine($"Skip Reason: {DefaultSkipReason}");
                            console.WriteLine($"Test Run Name: {TestRunName}");
                            TextImporter textImporter = new TextImporter();
                            console.WriteLine($"Source Content:");
                            console.WriteLine(source);
                            testRun = textImporter.ImportText(source, TextIndentation, RootNamespace, DefaultSkipReason);
                            testRun.Name = TestRunName;
                            console.WriteLine($"Test Run Scenario Count: {testRun.Scenarios.Count}");
                        break;
                        case SourceFormat.Json:
                            console.WriteLine($"Source File: {SourceFile}");
                            console.WriteLine($"Skip Reason: {DefaultSkipReason}");
                            JsonImporter jsonImporter = new JsonImporter();
                            console.WriteLine($"Source Content:");
                            console.WriteLine(source);
                            TestRun testRunJson = jsonImporter.ImportJson(source);
                            console.WriteLine($"Test Run Scenario Count: {testRunJson.Scenarios.Count}");
                        break;
                        default:
                            console.Error.WriteLine($"The source type of '{this.SourceFormat}' is not currently supported.");
                        break;
                    }
                    switch (DestinationFormat)
                    {
                        case DestinationFormat.Code:
                            if(FeaturesOnly) {
                                console.WriteLine($"Writing code for only feautres to: {Destination}");
                                testRun.WriteFeaturesToCode(RootNamespace, Destination);
                            } else {
                                console.WriteLine($"Writing all code to: {Destination}");
                                console.WriteLine($"Using area name clipping setting: {AreaNameSkip}");
                                testRun.WriteToCode(RootNamespace, Destination, AreaNameSkip);
                            }
                        break;
                        case DestinationFormat.HtmlTestRunReport:
                            console.WriteLine($"Writing Html Test Run Report To: {Destination}");
                            var htmlReport = testRun.WriteToHtml(AreaNameSkip);
                            System.IO.File.WriteAllText(Destination, htmlReport);
                        break;
                        case DestinationFormat.Text:
                            console.WriteLine($"Writing Text Outline Report To: {Destination}");
                            var textReport = testRun.WriteToText(false);
                            System.IO.File.WriteAllText(Destination, textReport);
                        break;
                        case DestinationFormat.Json:
                            console.WriteLine($"Writing Json Report To: {Destination}");
                            var jsonReport = testRun.WriteToJson();
                            System.IO.File.WriteAllText(Destination, jsonReport);
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