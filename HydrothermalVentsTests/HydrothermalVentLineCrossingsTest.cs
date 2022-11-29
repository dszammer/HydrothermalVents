﻿// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
using HydrothermalVentsTests;

namespace BusinessLogicTests
{
    [TestClass]
    public class HydrothermalVentLineCrossingsTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriterMock<int, LineSegment<int>>();
            ILineSegmentReader<int> reader = new LineSegmentReaderMock<int>(null);

            HydrothermalVentLineCrossings<int, int> hydro = new HydrothermalVentLineCrossings<int, int>(ref reader, ref writer);
        }
        [TestMethod]
        public void TestCalculateLineCrossings()
        {
            //Line segments are crossing.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 4 }, new int[] { 3, 2 });

            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriterMock<int, LineSegment<int>>();
            ILineSegmentReader<int> reader = new LineSegmentReaderMock<int>(new List<LineSegment<int>>() { line1, line2 }); ;

            HydrothermalVentLineCrossings<int, int> hydro = new HydrothermalVentLineCrossings<int, int>(ref reader, ref writer);

            Assert.AreEqual(hydro.CalculateAllLineSegementCrossings(), 1) ;

        }
    }
}
