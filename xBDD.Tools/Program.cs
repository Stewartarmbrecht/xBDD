using McMaster.Extensions.CommandLineUtils;
using System;
using System.Threading.Tasks;

namespace xBDD.Tools
{
	/// <summary>
	/// Provides a CLI for calling operations in xBDD Tools
	/// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for xBDD tools.
        /// </summary>
        /// <param name="args">The args to pass to xBDD tools.</param>
        public static void Main(string[] args) => CommandLineApplication.Execute<ToolsCLI>(args);

    }
}