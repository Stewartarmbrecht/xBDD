using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface ITestCase
    {
        string ClassName { get; set; }
        string Name { get; set; }
        string Namespace { get; set; }
        List<ITestStep> Steps { get; }

        ITestCase Given(Action<ITestStep> stepAction);
        ITestCase Given(string name, Action<ITestStep> stepAction);
        ITestCase When(Action<ITestStep> stepAction);
        ITestCase When(string name, Action<ITestStep> stepAction);
        ITestCase Then(Action<ITestStep> stepAction);
        ITestCase Then(string name, Action<ITestStep> stepAction);
        ITestCase And(Action<ITestStep> stepAction);
        ITestCase And(string name, Action<ITestStep> stepAction);
        void Run();
    }
}
