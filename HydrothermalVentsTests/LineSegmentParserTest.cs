using HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserTests
{
    [TestClass]
    public class LineSegmentParserTests
    {
        [TestMethod]
        public void TestCTOR()
        {
            LineSegmentParser parser = new LineSegmentParser();
        }

        [TestMethod]
        public void TestFromCorrectString()
        {
            LineSegmentParser parser = new LineSegmentParser();
            LineSegment<int> segment = parser.FromString("1,2 -> 3,4");
            Assert.AreEqual(segment.Start[0], 1);
            Assert.AreEqual(segment.Start[1], 2);
            Assert.AreEqual(segment.End[0], 3);
            Assert.AreEqual(segment.End[1], 4);
        }

        [TestMethod]
        public void TestFromBSString()
        {
            LineSegmentParser parser = new LineSegmentParser();
            LineSegment<int> segment = parser.FromString("This better throws");
        }

        [TestMethod]
        public void TestFromEmptyString()
        {
            LineSegmentParser parser = new LineSegmentParser();
            LineSegment<int> segment = parser.FromString("");
        }

        [TestMethod]
        public void TestFromAlmostCorrectString()
        {
            LineSegmentParser parser = new LineSegmentParser();
            LineSegment<int> segment = parser.FromString("1,2 -> BS,4");
        }
    }
}
