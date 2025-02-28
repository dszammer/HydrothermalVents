// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;

namespace HydrothermalVentsUnitTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="LineSegment{T}"/> class.
    /// </summary>
    [TestClass]
    public class LineTest
    {
        /// <summary>
        /// Tests the constructor of the <see cref="LineSegment{T}"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 });

            // Test a dimonsion mismatch between start and endpoints. In this case it is a 2D start and a 3D endpoint.
            Assert.ThrowsException<LineSegmentException>(delegate () { LineSegment<int> line = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0, 0 }); });
        }

        /// <summary>
        /// Tests the getter for the <see cref="LineSegment{T}.Start"/> property.
        /// </summary>
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