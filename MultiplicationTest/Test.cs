using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;

namespace MultiplicationTest
{
    [TestClass]
    public class Test
    {
        private Multiplication multiplication;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.multiplication = new Multiplication();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for multiplication operation or the values within the stack for the operation are invalid!";

            try
            {
                this.multiplication.Work(this.interpreterStack); //interpreterstack is null
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage); 
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterstack has not enough values
                this.interpreterStack.Push(1);
                this.multiplication.Work(this.interpreterStack);
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
                this.multiplication.Work(this.interpreterStack);
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
                this.multiplication.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //Multiply
            this.interpreterStack.Push(5);
            this.interpreterStack.Push(5);
            Assert.IsTrue((int)this.multiplication.Work(this.interpreterStack) == 25);
        }
    }
}