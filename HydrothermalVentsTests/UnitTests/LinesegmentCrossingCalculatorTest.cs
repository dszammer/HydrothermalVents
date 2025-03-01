﻿// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
using HydrothermalVents.BusinessLogic;
using System.Collections.Generic;

namespace HydrothermalVentsUnitTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="LineSegmentCrossingCalculator"/> class.
    /// </summary>
    [TestClass]
    public class LinesegmentCrossingCalculatorTest
    {
        /// <summary>
        /// Tests the constructor of the <see cref="LineSegmentCrossingCalculator"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            ICrossingCalculator<int, LineSegment<int>> calc = new LineSegmentCrossingCalculator();
        }

        /// <summary>
        /// Tests the <see cref="LineSegmentCrossingCalculator.CalculateCrossing(LineSegment{int}, LineSegment{int})"/> method with crossing line segments.
        /// </summary>
        [TestMethod]
        public void TestAddLineWithCrossing()
        {
            ICrossingCalculator<int, LineSegment<int>> calc = new LineSegmentCrossingCalculator();

            //Line segments are crossing.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 4 }, new int[] { 3, 2 });

            Crossing<int, LineSegment<int>>? cross = calc.CalculateCrossing(line1, line2);

            Assert.IsTrue(cross != null);
        }

        /// <summary>
        /// Tests the <see cref="LineSegmentCrossingCalculator.CalculateCrossing(LineSegment{int}, LineSegment{int})"/> method with parallel line segments.
        /// </summary>
        [TestMethod]
        public void TestAddLineParrallels()
        {

            ICrossingCalculator<int, LineSegment<int>> calc = new LineSegmentCrossingCalculator();

            // Line segments are parallel.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 0 }, new int[] { 1, 2 });

            Crossing<int, LineSegment<int>>? cross = calc.CalculateCrossing(line1, line2);

            Assert.IsTrue(cross == null);
        }

        /// <summary>
        /// Tests the <see cref="LineSegmentCrossingCalculator.CalculateCrossing(LineSegment{int}, LineSegment{int})"/> method with line segments that do not intersect within their bounds.
        /// </summary>
        [TestMethod]
        public void TestAddLineOutOfBounds()
        {
            ICrossingCalculator<int, LineSegment<int>> calc = new LineSegmentCrossingCalculator();

            // Lines are crossing but the crossing point is outside of the line segments.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 4 }, new int[] { 3, 2 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 6, 6 }, new int[] { 5, 5 });

            Crossing<int, LineSegment<int>>? cross = calc.CalculateCrossing(line1, line2);

            Assert.IsTrue(cross == null);
        }
    }
}
