using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter.Directions;

namespace RightTest
{
    [TestClass]
    public class Test
    {
        private Right right;
        public Test()
        {
            this.right = new Right();
        }

        [TestMethod]
        public void TestGetNextPosition()
        {
            string exceptionMessage = "coordinates were invalid during moving";
            Tuple<int, int> t;

            try
            {
                t = this.right.GetNextPosition(-20, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.right.GetNextPosition(100, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.right.GetNextPosition(1, -20);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.right.GetNextPosition(1, 100);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }


            t = this.right.GetNextPosition(10, 10);
            Assert.IsTrue(t.Item1 == 11 && t.Item2 == 10);

            t = this.right.GetNextPosition(79, 10);
            Assert.IsTrue(t.Item1 == 0 && t.Item2 == 10);
        }
    }
}