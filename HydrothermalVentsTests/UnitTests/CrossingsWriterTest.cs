// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Parser;
using HydrothermalVentsTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsUnitTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="CrossingsWriter{U, T}"/> class.
    /// </summary>
    [TestClass]
    public class CrossingsWriterTest
    {
        /// <summary>
        /// Tests the constructor of the <see cref="CrossingsWriter{U, T}"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            IIO mockwriter = new WriterMock();
            ICrossingParser<int, LineSegment<int>> parser = new CrossingParser();
            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriter<int, LineSegment<int>>(parser, new List<IIO> { mockwriter });
        }

        /// <summary>
        /// Tests the <see cref="CrossingsWriter{U, T}.writeCrossings(List{Crossing{U, T}})"/> method.
        /// </summary>
        [TestMethod]
        public void TestWriteCrossings()
        {
            IIO mockwriter = new WriterMock();
            ICrossingParser<int, LineSegment<int>> parser = new CrossingParser();
            ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriter<int, LineSegment<int>>(parser, new List<IIO> { mockwriter });
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>(new int[] { 0, 0 }, new List<LineSegment<int>> { new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 }) });
            writer.writeCrossings(new List<Crossing<int, LineSegment<int>>> { cross });

            Assert.AreEqual(((WriterMock)mockwriter).m_written, 2); // one crossing and one header line

        }

    }
}
