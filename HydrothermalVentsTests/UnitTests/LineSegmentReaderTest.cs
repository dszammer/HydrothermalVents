// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
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
    [TestClass]
    public class LineSegmentReader
    {
        [TestMethod]
        public void TestCTOR()
        {
            IIO mockreader = new ReaderMock(new string[] { "" });
            ILineSegmentParser<int> parser = new LineSegmentParser();
            ILineSegmentReader<int> reader = new LineSegmentReader<int>(parser, new List<IIO> { mockreader });
        }

        [TestMethod]
        public void TestWriteCrossings()
        {
            IIO mockreader = new ReaderMock(new string[] { "0,0 -> 1,1" });
            ILineSegmentParser<int> parser = new LineSegmentParser();
            ILineSegmentReader<int> reader = new LineSegmentReader<int>(parser, new List<IIO> { mockreader });
            LineSegment<int>? ls = reader.GetLineSegment();

            Assert.IsNotNull(ls);
            ls = reader.GetLineSegment();

            Assert.IsNull(ls);

        }

    }
}
