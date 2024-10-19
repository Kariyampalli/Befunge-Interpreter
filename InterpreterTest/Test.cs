using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace InterpreterTest
{
    [TestClass]
    public class Test
    {
        private Interpreter interpreter;

        public Test()
        {
            this.interpreter = new Interpreter(new FileReader());
        }

        [TestMethod]
        public void TestCheckIsNumber()
        {
            this.interpreter = new Interpreter(new FileReader());
            PrivateObject obj = new PrivateObject(this.interpreter);

            var checkIsNumber = obj.Invoke("CheckIsNumber",'s');
            Assert.AreEqual(false, checkIsNumber);
            checkIsNumber = obj.Invoke("CheckIsNumber", ' ');
            Assert.AreEqual(false, checkIsNumber);
            checkIsNumber = obj.Invoke("CheckIsNumber", '1');
            Assert.AreEqual(true, checkIsNumber);
        }

        [TestMethod]
        public void TestCheckIsCommand()
        {
            PrivateObject obj = new PrivateObject(this.interpreter);
            var checkIsCommand = obj.Invoke("CheckIsCommand", 's');
            Assert.AreEqual(false, checkIsCommand);
            checkIsCommand = obj.Invoke("CheckIsCommand", ' ');
            Assert.AreEqual(false, checkIsCommand);
            checkIsCommand = obj.Invoke("CheckIsCommand", '1');
            Assert.AreEqual(false, checkIsCommand);
            checkIsCommand = obj.Invoke("CheckIsCommand", '>');
            Assert.AreEqual(false, checkIsCommand);
            checkIsCommand = obj.Invoke("CheckIsCommand", '~');
            Assert.AreEqual(false, checkIsCommand);

            try
            {
                checkIsCommand = obj.Invoke("CheckIsCommand", '+');
                Assert.AreEqual(true, checkIsCommand);
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Stack doesn't have enough values for addition operation or the values within the stack for the operation are invalid!");
            }

            try
            {
                checkIsCommand = obj.Invoke("CheckIsCommand", '-');
                Assert.AreEqual(true, checkIsCommand);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Stack doesn't have enough values for subtraction operation or the values within the stack for the operation are invalid!");
            }

            try
            {
                checkIsCommand = obj.Invoke("CheckIsCommand", '/');
                Assert.AreEqual(true, checkIsCommand);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Stack doesn't have enough values for division operation or the values within the stack for the operation are invalid!");
            }

            try
            {
                checkIsCommand = obj.Invoke("CheckIsCommand", '%');
                Assert.AreEqual(true, checkIsCommand);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Stack doesn't have enough values for modulo operation or the values within the stack for the operation are invalid!");
            }

            try
            {
                checkIsCommand = obj.Invoke("CheckIsCommand", '!');
                Assert.AreEqual(true, checkIsCommand);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Stack doesn't have enough values for negation operation or the values within the stack for the operation are invalid!");
            }

            try
            {
                checkIsCommand = obj.Invoke("CheckIsCommand", '`');
                Assert.AreEqual(true, checkIsCommand);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Stack doesn't have enough values for greater than operation or the values within the stack for the operation are invalid!");
            }

        }


        [TestMethod]
        public void TestCheckIsDirection()
        {
            PrivateObject obj = new PrivateObject(this.interpreter);
            var checkIsDirection = obj.Invoke("CheckIsDirection", 's');
            Assert.AreEqual(false, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", ' ');
            Assert.AreEqual(false, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '1');
            Assert.AreEqual(false, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '~');
            Assert.AreEqual(false, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '+');
            Assert.AreEqual(false, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '<');
            Assert.AreEqual(true, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '>');
            Assert.AreEqual(true, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '^');
            Assert.AreEqual(true, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", 'v');
            Assert.AreEqual(true, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '?');
            Assert.AreEqual(true, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '_');
            Assert.AreEqual(true, checkIsDirection);
            checkIsDirection = obj.Invoke("CheckIsDirection", '|');
            Assert.AreEqual(true, checkIsDirection);
        }
    }
}
