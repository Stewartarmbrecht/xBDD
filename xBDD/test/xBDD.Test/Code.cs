//using Microsoft.Dnx.Runtime;
//using Microsoft.Dnx.Runtime.Infrastructure;
//using Microsoft.Framework.DependencyInjection;
using System;
using System.IO;
using xBDD.Model;
using System.Threading.Tasks;

namespace xBDD.Test
{
    public static class Code
    {
        public static Step HasTheFollowingScenario(string fileName)
        {
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            var path = System.IO.Directory.GetCurrentDirectory() + "..\\..\\.." + fileName;
			if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
			{
                path = System.IO.Directory.GetCurrentDirectory() + "//..//..//.." + fileName;
            }
            
            var code = File.ReadAllText(path);
            //var code = "Need to fix this...";
            var step = xB.CreateStep(
                "has the following scenarion definition",
                (s) => { },
                code,
                TextFormat.cs);
            return step;
        }

        public static Step IsExecuted(Func<Step,Task> code)
        {
            return xB.CreateAsyncStep(
                "the method is executed",
                code);
        }
    }
}
