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
            LineSegmentCrossingCalculator calc = new LineSegmentCrossingCalculator();
        }

        [TestMethod]
        public void TestAddLineWithCrossing()
        {
            LineSegmentCrossingCalculator calc = new LineSegmentCrossingCalculator();

            //Line segments are crossing.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 4 }, new int[] { 3, 2 });
            
            calc.AddLinesegment(line1);
            calc.AddLinesegment(line2);

            Assert.AreEqual(calc.Crossings.Count, 1);
        }

        [TestMethod]
        public void TestAddLineParrallels()
        {
            
            LineSegmentCrossingCalculator calc = new LineSegmentCrossingCalculator();

            // Line segments are parallel.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 0 }, new int[] { 1, 2 });
            
            calc.AddLinesegment(line1);
            calc.AddLinesegment(line2);

            Assert.AreEqual(calc.Crossings.Count, 0);
        }

        [TestMethod]
        public void TestAddLineOutOfBounds()
        {
            LineSegmentCrossingCalculator calc = new LineSegmentCrossingCalculator();
            
            // Lines are crossing but the crossing point is outside of the line segments.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 0 }, new int[] { 1, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 0, 3 }, new int[] { 3, 3 });
            
            calc.AddLinesegment(line1);
            calc.AddLinesegment(line2);

            Assert.AreEqual(calc.Crossings.Count, 0);
        }
    }
}
