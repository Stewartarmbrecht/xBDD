using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features
{
    public class Feature
    {
        internal readonly IOutputWriter outputWriter;

        public Feature(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

    }
}
