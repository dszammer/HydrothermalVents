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
    [TestClass]
    public class CrossingParserTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            ICrossingParser<int, LineSegment<int>> parser = new CrossingParser();
        }

        [TestMethod]
        public void TestToString()
        {
            ICrossingParser<int, LineSegment<int>> parser = new CrossingParser();
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>(new int[] { 0, 0 }, new List<LineSegment<int>> { new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 }) });
            Assert.AreEqual(parser.ToString(cross), "(0,0) -> 1");
        }

    }
}