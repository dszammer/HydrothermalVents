using HydrothermalVents;
using System.Collections.Generic;

namespace BusinessLogicTests
{
    [TestClass]
    public class LinesegmentCrossingCalculatorTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            LinesegmentCrossingCalculator calc = new LinesegmentCrossingCalculator();
        }

        [TestMethod]
        public void TestAddLine()
        {
            LinesegmentCrossingCalculator calc = new LinesegmentCrossingCalculator();
            Linesegment<int> line1 = new Linesegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });

            calc.AddLinesegment(line1);

            Linesegment<int> line2 = new Linesegment<int>(new int[] { 1, 4 }, new int[] { 3, 2 });

            calc.AddLinesegment(line2);

            Assert.AreEqual(calc.Crossings.Count, 1);
        }
    }
}
