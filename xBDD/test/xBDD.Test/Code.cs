using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System;
using System.IO;

namespace xBDD.Test
{
    public static class Code
    {
        public static Step HasMethod(string fileName)
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            
            var code = File.ReadAllLines(appEnv.ApplicationBasePath + fileName);
            var step = xBDD.CreateStep(
                "the following method",
                () => { },
                string.Join("\r\n", code));
            return step;
        }

        public static Step ExecuteMethod(Action code)
        {
            return xBDD.CreateStep(
                "the method is executed",
                code);
        }
    }
}
