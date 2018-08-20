using McMaster.Extensions.CommandLineUtils;
using System;
using System.Threading.Tasks;

namespace xBDD.Tools
{
    class Program
    {
        // Return codes
        public const int EXCEPTION = 2;
        public const int ERROR = 1;
        public const int OK = 0;

        public static int Main(string[] args)
        {
            try
            {
                return CommandLineApplication.Execute<Initializer>(args);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Unexpected error: " + ex.ToString());
                Console.ResetColor();
                return EXCEPTION;
            }
        }
    }
}