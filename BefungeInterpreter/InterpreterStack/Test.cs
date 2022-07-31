using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace InterpreterStackTests
{
    [TestClass]
    public class Test
    {
        private InterpreterStack stack;
        public Test()
        {
            this.stack = new InterpreterStack();
        }
       
        [TestMethod]
        public void TestPop()
        {
            this.stack.Push(1);
            Assert.IsTrue((int)this.stack.Pop() == 1);
            Assert.IsTrue((int)this.stack.Pop() == 0);
        }

        [TestMethod]
        public void TestPush()
        {
            this.stack.Push(1);
            Assert.IsTrue((int)this.stack.Pop() == 1);
            try
            {
                this.stack.Push(null);
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Program tried to push null to stack!");
            }
        }

        [TestMethod]
        public void TestPeek()
        {
            this.stack.Push(1);
            Assert.IsTrue((int)this.stack.Peek() == 1 && this.stack.Count() == 1);
        }
    }
}
