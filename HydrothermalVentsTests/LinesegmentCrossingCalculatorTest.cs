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
            LinesegmentCrossingCalculator calc = new LinesegmentCrossingCalculator();
        }

        [TestMethod]
        public void TestAddLineWithCrossing()
        {
            LinesegmentCrossingCalculator calc = new LinesegmentCrossingCalculator();

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
            
            LinesegmentCrossingCalculator calc = new LinesegmentCrossingCalculator();

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
            LinesegmentCrossingCalculator calc = new LinesegmentCrossingCalculator();
            
            // Lines are crossing but the crossing point is outside of the line segments.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 0 }, new int[] { 1, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 0, 3 }, new int[] { 3, 3 });
            
            calc.AddLinesegment(line1);
            calc.AddLinesegment(line2);

            Assert.AreEqual(calc.Crossings.Count, 0);
        }
    }
}
