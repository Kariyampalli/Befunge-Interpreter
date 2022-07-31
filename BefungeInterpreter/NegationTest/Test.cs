using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;

namespace NegationTest
{
    [TestClass]
    public class Test
    {
        private Negation negation;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.negation = new Negation();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for negation operation or the values within the stack for the operation are invalid!";

            try
            {
                this.negation.Work(this.interpreterStack); //interpreterstack is null
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //Negation
            this.interpreterStack.Push("Aafwf2");
            Assert.IsTrue((int)this.negation.Work(this.interpreterStack) == 0);
            this.interpreterStack.Push(23);
            Assert.IsTrue((int)this.negation.Work(this.interpreterStack) == 0);
            this.interpreterStack.Push(0);
            Assert.IsTrue((int)this.negation.Work(this.interpreterStack) == 1);
        }
    }
}