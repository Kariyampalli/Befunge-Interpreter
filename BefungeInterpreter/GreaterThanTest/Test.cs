using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;

namespace GreaterThanTest
{
    [TestClass]
    public class Test
    {
        private GreaterThan greaterThan;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.greaterThan = new GreaterThan();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for greater than operation or the values within the stack for the operation are invalid!";

            try
            {
                this.greaterThan.Work(this.interpreterStack); //interpreterStack null
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterStack has only one value
                this.interpreterStack.Push(1);
                this.greaterThan.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterStack has an empty invalid value(s)
                this.interpreterStack.Push(1);
                this.interpreterStack.Push(" ");
                this.greaterThan.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack();//interpreterStack has invalid value(s)
                this.interpreterStack.Push(1);
                this.interpreterStack.Push("a");
                this.greaterThan.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //Greater than should work
            this.interpreterStack.Push(1);
            this.interpreterStack.Push(2);
            Assert.IsTrue((int)this.greaterThan.Work(this.interpreterStack) == 0);

            this.interpreterStack.Push(2);
            this.interpreterStack.Push(1);
            Assert.IsTrue((int)this.greaterThan.Work(this.interpreterStack) == 1);
        }
    }
}