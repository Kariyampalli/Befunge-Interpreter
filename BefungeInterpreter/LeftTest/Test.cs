using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter.Directions;

namespace LeftTest
{
    [TestClass]
    public class Test
    {
        private Left left;
        public Test()
        {
            this.left = new Left();
        }

        [TestMethod]
        public void TestGetNextPosition()
        {
            string exceptionMessage = "coordinates were invalid during moving";
            Tuple<int, int> t;

            try
            {
                t = this.left.GetNextPosition(-20, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.left.GetNextPosition(100, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.left.GetNextPosition(1, -20);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.left.GetNextPosition(1, 100);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }


            t = this.left.GetNextPosition(10, 10);
            Assert.IsTrue(t.Item1 == 9 && t.Item2 == 10);

            t = this.left.GetNextPosition(0, 10);
            Assert.IsTrue(t.Item1 == 79 && t.Item2 == 10);
        }
    }
}