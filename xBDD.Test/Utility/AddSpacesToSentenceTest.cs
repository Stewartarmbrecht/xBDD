using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Test.Utility
{
    using xBDD.Importing.Text;
    using xBDD.Utility;
    using TemplateValidator;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class AddSpacesToSentenceTest
    {
        
        [TestMethod]
        public void SimpleSentence()
        {
            var result = "ThisIsATest".AddSpacesToSentence();
            Assert.AreEqual(result, "This Is A Test");
        }

        [TestMethod]
        public void SentenceWithNumber()
        {
            var result = "ThisIsThe9Test".AddSpacesToSentence();
            Assert.AreEqual(result, "This Is The 9 Test");
        }

        [TestMethod]
        public void SentenceWithMultipleNumbers()
        {
            var result = "ThisIsThe999Test".AddSpacesToSentence();
            Assert.AreEqual(result, "This Is The 999 Test");
        }
    }
}

