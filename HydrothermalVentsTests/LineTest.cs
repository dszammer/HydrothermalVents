// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;

namespace BusinessLogicTests
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 });


            Assert.ThrowsException<LineSegmentException>(delegate () { LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 ,0}); });
        }
        [TestMethod]
        public void TestGetSet()
        {
            int[] start = new int[] { 10, 20 };

            LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 });

            line.Start = new int[] { 10, 20 };

            Assert.IsTrue(line.Start[0] == start[0]);
            Assert.IsTrue(line.Start[1] == start[1]);
        }
    }
}