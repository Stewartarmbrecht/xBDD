using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System;
using System.IO;
using xBDD.Model;

namespace xBDD.Test
{
    public static class Code
    {
        public static Step HasTheFollowingScenario(string fileName)
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            
            var code = File.ReadAllText(appEnv.ApplicationBasePath + fileName);
            var step = xB.CreateStep(
                "has the following scenarion definition",
                (s) => { },
                code,
                TextFormat.cs);
            return step;
        }

        public static Step IsExecuted(Action<Step> code)
        {
            return xB.CreateStep(
                "the method is executed",
                code);
        }
    }
}
