using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;

namespace SubtractionTest
{
    [TestClass]
    public class Test
    {
        private Subtraction subtraction;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.subtraction = new Subtraction();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for subtraction operation or the values within the stack for the operation are invalid!";

            try
            {
                this.subtraction.Work(this.interpreterStack); //interpreterstack is null
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterstack has not enough values
                this.interpreterStack.Push(1);
                this.subtraction.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterstack has invalid value(s)
                this.interpreterStack.Push(1);
                this.interpreterStack.Push(" ");
                this.subtraction.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterstack has invalid value(s)
                this.interpreterStack.Push(1);
                this.interpreterStack.Push("a");
                this.subtraction.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //Sub
            this.interpreterStack.Push(1);
            this.interpreterStack.Push(2);
            Assert.IsTrue((int)this.subtraction.Work(this.interpreterStack) == -1);
        }
    }
}