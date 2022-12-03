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
            ILineSegmentParser<int> parser = new LineSegmentParser();
        }

        [TestMethod]
        public void TestFromCorrectString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            LineSegment<int> segment = parser.FromString("1,2 -> 3,4");
            Assert.AreEqual(segment.Start[0], 1);
            Assert.AreEqual(segment.Start[1], 2);
            Assert.AreEqual(segment.End[0], 3);
            Assert.AreEqual(segment.End[1], 4);
        }

        [TestMethod]
        public void TestFromBSString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            try
            {
                LineSegment<int> segment = parser.FromString("This better throws");
            }
            catch (LineSegmentParserException ex)
            {
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestFromEmptyString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            try
            {
                LineSegment<int> segment = parser.FromString("");
            }
            catch (LineSegmentParserException ex)
            {
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestFromAlmostCorrectString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            try
            {
                LineSegment<int> segment = parser.FromString("1,2 -> BS,4");
            }
            catch (LineSegmentParserException ex)
            {
                return;
            }
            Assert.IsTrue(false);
        }
    }
}
