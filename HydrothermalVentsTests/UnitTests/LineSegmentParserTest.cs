// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;
using HydrothermalVents.Parser;

namespace HydrothermalVentsUnitTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="LineSegmentParser"/> class.
    /// </summary>
    [TestClass]
    public class LineSegmentParserTests
    {
        /// <summary>
        /// Tests the constructor of the <see cref="LineSegmentParser"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
        }

        /// <summary>
        /// Tests the <see cref="LineSegmentParser.FromString(string)"/> method with a correct string.
        /// </summary>
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

        /// <summary>
        /// Tests the <see cref="LineSegmentParser.FromString(string)"/> method with an incorrect string.
        /// </summary>
        [TestMethod]
        public void TestFromBSString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            Assert.ThrowsException<LineSegmentParserException>(() => parser.FromString("This better throws"));
        }

        /// <summary>
        /// Tests the <see cref="LineSegmentParser.FromString(string)"/> method with an empty string.
        /// </summary>
        [TestMethod]
        public void TestFromEmptyString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            Assert.ThrowsException<LineSegmentParserException>(() => parser.FromString(""));
        }

        /// <summary>
        /// Tests the <see cref="LineSegmentParser.FromString(string)"/> method with an almost correct string.
        /// </summary>
        [TestMethod]
        public void TestFromAlmostCorrectString()
        {
            ILineSegmentParser<int> parser = new LineSegmentParser();
            Assert.ThrowsException<LineSegmentParserException>(() => parser.FromString("1,2 -> BS,4"));
        }
    }
}
