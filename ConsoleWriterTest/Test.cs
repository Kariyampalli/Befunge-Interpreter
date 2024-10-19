using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace ConsoleWriterTest
{
    [TestClass]
    public class Test
    {
        private ConsoleWriter writer;
        public Test()
        {
            this.writer = new ConsoleWriter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestWriteOnConsole()
        {
            this.writer.WriteOnConsole(this,null);
        }

        [TestMethod]
        public void TestWriteErrorMessage()
        {
            string exceptionMessage = "No output message was passed!";
            try
            {
                this.writer.WriteErrorMessage(string.Empty);
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.writer.WriteErrorMessage("    ");            
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.writer.WriteErrorMessage(null);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }
        }

        [TestMethod]
        public void TestWrite()
        {
            string exceptionMessage = "No output message was passed!";
            try
            {
                this.writer.Write(string.Empty, false, ConsoleColor.White);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.writer.Write("    ", false, ConsoleColor.White);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.writer.Write(null, false, ConsoleColor.White);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }
        }

        [TestMethod]
        public void TestWriteLine()
        {
            string exceptionMessage = "No output message was passed!";
            try
            {
                this.writer.WriteLine(string.Empty, false, ConsoleColor.White);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.writer.WriteLine("    ", false, ConsoleColor.White);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                this.writer.WriteLine(null, false, ConsoleColor.White);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }
        }
    }
}
