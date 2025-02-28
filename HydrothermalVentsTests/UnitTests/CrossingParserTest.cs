// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Parser;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsUnitTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="CrossingParser"/> class.
    /// </summary>
    [TestClass]
    public class CrossingParserTest
    {
        /// <summary>
        /// Tests the constructor of the <see cref="CrossingParser"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            ICrossingParser<int, LineSegment<int>> parser = new CrossingParser();
        }

        /// <summary>
        /// Tests the <see cref="CrossingParser.ToString(Crossing{int, LineSegment{int}})"/> method.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            ICrossingParser<int, LineSegment<int>> parser = new CrossingParser();
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>(new int[] { 0, 0 }, new List<LineSegment<int>> { new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 }) });
            Assert.AreEqual(parser.ToString(cross), "(0,0) -> 1");
        }

    }
}