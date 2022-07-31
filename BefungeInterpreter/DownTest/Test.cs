using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter.Directions;

namespace DownTest
{
    [TestClass]
    public class Test
    {
        private Down down;
        public Test()
        {
            this.down = new Down();
        }

        [TestMethod]
        public void TestGetNextPosition()
        {
            string exceptionMessage = "coordinates were invalid during moving";
            Tuple<int, int> t;
           
            try
            {
                t = this.down.GetNextPosition(-20, 1);
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.down.GetNextPosition(100, 1);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.down.GetNextPosition(1, -20);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }

            try
            {
                t = this.down.GetNextPosition(1, 100);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == exceptionMessage);
            }


            t = this.down.GetNextPosition(10,10);
            Assert.IsTrue(t.Item1 == 10 && t.Item2 == 11);

            t = this.down.GetNextPosition(10, 24);
            Assert.IsTrue(t.Item1 == 10 && t.Item2 == 0);
        }
    }
}
