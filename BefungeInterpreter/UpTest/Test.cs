using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter.Directions;

namespace UpTest
{
    [TestClass]
    public class Test
    {
        private Up up;
        public Test()
        {
            this.up = new Up();
        }

        [TestMethod]
        public void TestGetNextPosition()
        {
            string exceptionMessage = "coordinates were invalid during moving";
            Tuple<int, int> t;

            try
            {
                t = this.up.GetNextPosition(-20, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.up.GetNextPosition(100, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.up.GetNextPosition(1, -20);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.up.GetNextPosition(1, 100);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }


            t = this.up.GetNextPosition(10, 10);
            Assert.IsTrue(t.Item1 == 10 && t.Item2 == 9);

            t = this.up.GetNextPosition(10, 0);
            Assert.IsTrue(t.Item1 == 10 && t.Item2 == 24);
        }
    }
}
