using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;
using BefungeInterpreter.Directions;
namespace DivisionTest
{
    [TestClass]
    public class Test
    {
        private Division division;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.division = new Division();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for division operation or the values within the stack for the operation are invalid!";

            try
            {
                this.division.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterStack is null
                this.interpreterStack.Push(1);
                this.division.Work(this.interpreterStack);
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
                this.division.Work(this.interpreterStack);
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
                this.division.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //Divison should work
            this.interpreterStack.Push(5);
            this.interpreterStack.Push(3);
            Assert.IsTrue((int)this.division.Work(this.interpreterStack) == 1);
        }
    }
}