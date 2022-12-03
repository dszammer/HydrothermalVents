using HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserTests
{
    [TestClass]
    public class CrossingParserTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            CrossingParser parser = new CrossingParser();
        }

        [TestMethod]
        public void TestToString()
        {
            CrossingParser parser = new CrossingParser();
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>(new int[] {0,0}, new List<LineSegment<int>> { new LineSegment<int>(new int[] { 0, 0 }, new int[] { 0, 0 }) });
            Assert.AreEqual(parser.ToString(cross), "(0,0) -> 1");
        }

    }
}