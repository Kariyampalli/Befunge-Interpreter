using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.Collections;
using BefungeInterpreter.Commands;

namespace ModuloTest
{
    [TestClass]
    public class Test
    {
        private Modulo modulo;
        private InterpreterStack interpreterStack;
        public Test()
        {
            this.modulo = new Modulo();
        }

        [TestMethod]
        public void TestWork()
        {
            string exceptionMessage = "Stack doesn't have enough values for modulo operation or the values within the stack for the operation are invalid!";

            try
            {
                this.modulo.Work(this.interpreterStack); //interpreterstack is null
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.interpreterStack = new InterpreterStack(); //interpreterstack has not enough values
                this.interpreterStack.Push(1);
                this.modulo.Work(this.interpreterStack);
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
                this.modulo.Work(this.interpreterStack);
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
                this.modulo.Work(this.interpreterStack);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            this.interpreterStack = new InterpreterStack(); //Modulo
            this.interpreterStack.Push(5);
            this.interpreterStack.Push(3);
            Assert.IsTrue((int)this.modulo.Work(this.interpreterStack) == 2);

            //CANT TEST ZERO BECAUSE IT AWAITS INPUT
        }
    }
}