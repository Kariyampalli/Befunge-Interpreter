using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;
using System.IO;

namespace FileReaderTest
{
    [TestClass]
    public class Test
    {
        private FileReader reader;
        public Test()
        {
            this.reader = new FileReader();
        }

        [TestMethod]
        public void TestRead()
        {
            try
            {
                this.reader.Read(null);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Filename was null!");
            }

            try
            {
                this.reader.Read("AFJSDKFJDKFJKDSJFSDKFKS");
            }
            catch (FileNotFoundException ex)
            {
                Assert.IsTrue(ex.Message == "File to be read doesn't exit!");
            }

            try
            {
                this.reader.Read(".");
            }
            catch (FileNotFoundException ex)
            {
                Assert.IsTrue(ex.Message == "File to be read doesn't exit!");
            }

            /*string [] codeLines = this.reader.Read("code");
            Assert.IsTrue(codeLines[0] == "92+9*                           :. v  <" && codeLines.Length == 17); --> See if code line 0 matches with first line of befunge code*/
        }
    }
}
