using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;

namespace AdditionTest
{
    [TestClass]
    public class Test
    {
        private Addition addition;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.addition = new Addition();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for addition operation or the values within the stack for the operation are invalid!";

            try
            {
                this.addition.Work(this.interpreterStack);     //interpreterStack is null         
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }         

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterStack has only one value
                this.interpreterStack.Push(1);
                this.addition.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterStack has empty value(s)
                this.interpreterStack.Push(1);
                this.interpreterStack.Push(" ");
                this.addition.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterStack has invalid value(s)
                this.interpreterStack.Push(1);
                this.interpreterStack.Push("a");
                this.addition.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //interpreterStack should perform addition
            this.interpreterStack.Push(1);
            this.interpreterStack.Push(2);
            Assert.IsTrue((int)this.addition.Work(this.interpreterStack) == 3);
        }
    }
}
