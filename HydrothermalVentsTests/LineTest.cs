using HydrothermalVents;

namespace BusinessLogicTests
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            Linesegment<int> line = new Linesegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 });


            Assert.ThrowsException<LinesegmentException>(delegate () { Linesegment<int> line = new Linesegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 ,0}); });
        }
        [TestMethod]
        public void TestGetSet()
        {
            int[] start = new int[] { 10, 20 };

            Linesegment<int> line = new Linesegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 });

            line.Start = new int[] { 10, 20 };

            Assert.IsTrue(line.Start[0] == start[0]);
            Assert.IsTrue(line.Start[1] == start[1]);
        }
    }
}