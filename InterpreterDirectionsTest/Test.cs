using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace InterpreterDirectionsTest
{
    [TestClass]
    public class Test
    {
        private InterpreterDirections directions;
        private InterpreterStack stack;
        public Test()
        {
            this.directions = new InterpreterDirections();
            this.stack = new InterpreterStack();
        }

        [TestMethod]
        public void TestIsDirection()
        {
            this.directions.IsDirection('<',this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[1]);

            this.directions.IsDirection('>', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[0]);

            this.directions.IsDirection('^', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[2]);

            this.directions.IsDirection('v', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[3]);

            this.stack.Push(1);
            this.stack.Push(0);
            this.directions.IsDirection('_', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[0]);
            this.directions.IsDirection('_', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[1]);

            this.stack.Push(1);
            this.stack.Push(0);
            this.directions.IsDirection('|', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[3]);
            this.directions.IsDirection('|', this.stack);
            Assert.IsTrue(this.directions.CurrentDirection == this.directions.BefungeDirections[2]);

            //? cant be checked
            //GetNextPosition just returns might not need to be checked
        }
    }
}
