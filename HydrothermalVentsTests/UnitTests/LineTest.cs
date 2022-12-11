// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;

namespace HydrothermalVentsUnitTests
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 });


            Assert.ThrowsException<LineSegmentException>(delegate () { LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0, 0 }); });
        }
        [TestMethod]
        public void TestGet()
        {
            int[] start = new int[] { 10, 20 };

            LineSegment<int> line = new LineSegment<int>(new int[] { 10, 20 }, new int[] { 0, 0 });

            Assert.IsTrue(line.Start[0] == start[0]);
            Assert.IsTrue(line.Start[1] == start[1]);
        }
    }
}