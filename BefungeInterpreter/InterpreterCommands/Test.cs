using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace InterpreterCommandsTest
{
    [TestClass]
    public class Test
    {
        private InterpreterCommands interpreterCommands;
        private InterpreterStack stack;
        public Test()
        {
            this.interpreterCommands = new InterpreterCommands();
            this.stack = new InterpreterStack();
        }

        [TestMethod]
        public void TestGetCommandSpecificValue()
        {        
            Tuple<bool, object> t;

            t = this.interpreterCommands.GetCommandSpecificValue('e', this.stack); //e is not a command
            Assert.IsFalse(t.Item1 && t.Item2 == new object());

            this.stack.Push(1);
            this.stack.Push(2);
            t = this.interpreterCommands.GetCommandSpecificValue('+', this.stack); 
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 3);

            this.stack.Push(1);
            this.stack.Push(2);
            t = this.interpreterCommands.GetCommandSpecificValue('-', this.stack); 
            Assert.IsTrue(t.Item1 && (int)t.Item2 == -1);

            this.stack.Push(4);
            this.stack.Push(2);
            t = this.interpreterCommands.GetCommandSpecificValue('*', this.stack); 
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 8);

            this.stack.Push(5);
            this.stack.Push(3);
            t = this.interpreterCommands.GetCommandSpecificValue('/', this.stack);
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 1);

            this.stack = new InterpreterStack();
            this.stack.Push(1);
            this.stack.Push(2);
            t = this.interpreterCommands.GetCommandSpecificValue('`', this.stack);
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 0);

            this.stack = new InterpreterStack();
            this.stack.Push(2);
            this.stack.Push(1);
            t = this.interpreterCommands.GetCommandSpecificValue('`', this.stack);
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 1);

            this.stack.Push(5);
            this.stack.Push(3);
            t = this.interpreterCommands.GetCommandSpecificValue('%', this.stack);
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 2);

            this.stack.Push(23);
            t = this.interpreterCommands.GetCommandSpecificValue('!', this.stack);
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 0);

            this.stack.Push(0);
            t = this.interpreterCommands.GetCommandSpecificValue('!', this.stack);
            Assert.IsTrue(t.Item1 && (int)t.Item2 == 1);
        }
    }
}
