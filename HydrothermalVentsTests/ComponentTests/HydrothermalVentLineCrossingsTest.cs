﻿// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
using HydrothermalVents.BusinessLogic;
using HydrothermalVentsTests;

namespace HydrothermalVentsCompontentTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="HydrothermalVentLineCrossings{T, U}"/> class.
    /// </summary>
    [TestClass]
    public class HydrothermalVentLineCrossingsTest
    {
        /// <summary>
        /// Tests the constructor of the <see cref="HydrothermalVentLineCrossings{T, U}"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriterMock<int, LineSegment<int>>();
            ILineSegmentReader<int> reader = new LineSegmentReaderMock<int>(null);
            ICrossingCalculator<int, LineSegment<int>> calculator = new LineSegmentCrossingCalculator();
            ILineSegmentCrossingPainter<int, LineSegment<int>> painter = new LineSegmentCrossingPainterMock();


            HydrothermalVentLineCrossings<int, int> hydro = new HydrothermalVentLineCrossings<int, int>(calculator, reader, writer, painter);
        }

        /// <summary>
        /// Tests the calculation of line segment crossings.
        /// </summary>
        [TestMethod]
        public void TestCalculateLineCrossings()
        {
            LineSegment<int> line1 = new LineSegment<int>(new int[] { 2, 1 }, new int[] { 2, 4 });
            LineSegment<int> line2 = new LineSegment<int>(new int[] { 1, 3 }, new int[] { 3, 1 });
            LineSegment<int> line3 = new LineSegment<int>(new int[] { 5, 5 }, new int[] { 6, 6 });

            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriterMock<int, LineSegment<int>>();
            ILineSegmentReader<int> reader = new LineSegmentReaderMock<int>(new List<LineSegment<int>>() { line1, line2, line3 });
            ICrossingCalculator<int, LineSegment<int>> calculator = new LineSegmentCrossingCalculator();
            ILineSegmentCrossingPainter<int, LineSegment<int>> painter = new LineSegmentCrossingPainterMock();

            HydrothermalVentLineCrossings<int, int> hydro = new HydrothermalVentLineCrossings<int, int>(calculator, reader, writer, painter);

            Assert.AreEqual(hydro.CalculateAllLineSegementCrossings(), 1);

            hydro.WriteAllLineSegementCrossings();

            Assert.IsTrue(((CrossingsWriterMock<int, LineSegment<int>>)writer).m_written);
            Assert.IsTrue(((LineSegmentCrossingPainterMock)painter).m_drew);
        }
    }
}
