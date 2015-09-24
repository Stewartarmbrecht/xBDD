using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Core.Test.Features
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
                string.Join("\n", code));
            return step;
        }

        internal static Step ExecuteMethod(Action code)
        {
            return xBDD.CreateStep(
                "the method is executed",
                code);
        }
    }
}
