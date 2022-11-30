// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
using System.Collections.Generic;

namespace BusinessLogicTests
{
    [TestClass]
    public class LinesegmentCrossingCalculatorTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            LineSegmentCrossingCalculator<int, int> calc = new LineSegmentCrossingCalculator<int, int>();
        }

        [TestMethod]
        public void TestAddLineWithCrossing()
        {
            LineSegmentCrossingCalculator<int, int> calc = new LineSegmentCrossingCalculator<int, int>();

            //Line segments are crossing.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 4 }, new int[] { 3, 2 });
            
            Crossing<int, LineSegment<int>>? cross = calc.CalculateCrossing(line1, line2);

            Assert.IsTrue(cross != null);
        }

        [TestMethod]
        public void TestAddLineParrallels()
        {
            
            LineSegmentCrossingCalculator<int, int> calc = new LineSegmentCrossingCalculator<int,int>();

            // Line segments are parallel.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 0 }, new int[] { 1, 2 });

            Crossing<int, LineSegment<int>>? cross = calc.CalculateCrossing(line1, line2);

            Assert.IsTrue(cross == null);
        }

        [TestMethod]
        public void TestAddLineOutOfBounds()
        {
            LineSegmentCrossingCalculator<int, int> calc = new LineSegmentCrossingCalculator<int, int>();
            
            // Lines are crossing but the crossing point is outside of the line segments.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 0 }, new int[] { 1, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 0, 3 }, new int[] { 3, 3 });

            Crossing<int, LineSegment<int>>? cross = calc.CalculateCrossing(line1, line2);

            Assert.IsTrue(cross == null);
        }
    }
}
