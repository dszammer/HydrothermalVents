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
            ICrossingCalculator<int, LineSegment<int>> calculator = new LineSegmentCrossingCalculator();

            HydrothermalVentLineCrossings<int, int> hydro = new HydrothermalVentLineCrossings<int, int>(ref reader, ref writer, ref calculator);
        }
        [TestMethod]
        public void TestCalculateLineCrossings()
        {
            //Line segments are crossing.
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 2, 1 }, new int[] { 2, 4 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 3 }, new int[] { 3, 1 });
            LineSegment<int> line3 = new LineSegment<int>(new int[] { 5, 5 }, new int[] { 6, 6 });

            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriterMock<int, LineSegment<int>>();
            ILineSegmentReader<int> reader = new LineSegmentReaderMock<int>(new List<LineSegment<int>>() { line1, line2, line3});
            ICrossingCalculator<int, LineSegment<int>> calculator = new LineSegmentCrossingCalculator();

            HydrothermalVentLineCrossings<int, int> hydro = new HydrothermalVentLineCrossings<int, int>(ref reader, ref writer, ref calculator);

            Assert.AreEqual(hydro.CalculateAllLineSegementCrossings(), 1) ;

            hydro.WriteAllLineSegementCrossings();

            Assert.IsTrue(((CrossingsWriterMock<int, LineSegment<int>>)writer).m_written);
        }
    }
}
