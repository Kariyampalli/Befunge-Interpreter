using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace ConsoleWriterValidatorTest
{
    [TestClass]
    public class Test
    {
        private ConsoleWriterValidator validator;

        public Test()
        {
            this.validator = new ConsoleWriterValidator();
        }

        [TestMethod]
        public void TestValidateOutput()
        {
            Assert.IsFalse(this.validator.ValidateOutput(string.Empty));
            Assert.IsFalse(this.validator.ValidateOutput(null));
            Assert.IsTrue(this.validator.ValidateOutput("\n"));
            Assert.IsTrue(this.validator.ValidateOutput("    "));
            Assert.IsTrue(this.validator.ValidateOutput("Hallo"));
        }
    }
}
