// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;

namespace BusinessLogicTests
{
    [TestClass]
    public class CrossingTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            Crossing<int, LineSegment<int>> crossdef = new Crossing<int, LineSegment<int>>();

            int[] pos = new int[] {};
            List<LineSegment<int>> listLines = new List<LineSegment<int>>();
            
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>(pos,listLines);
        }
        [TestMethod]
        public void TestPositionGetSet()
        {
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>();
            cross.Position = new int[] { 10, 20 };

            Assert.IsTrue(cross.Position[0] == 10);
            Assert.IsTrue(cross.Position[0] == 10);
        }

        [TestMethod]
        public void TestLinesGetSet()
        {
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>();

            List<LineSegment<int>> listLines = new List<LineSegment<int>>();
            LineSegment<int> line = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            listLines.Add(line);

            cross.Elements = listLines;

            Assert.IsTrue(cross.Elements[0].Start[0] == 1);
            Assert.IsTrue(cross.Elements[0].End[1] == 4);

        }

        [TestMethod]
        public void TestAddLine()
        {
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>();
            LineSegment<int> line = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            cross.AddLinesegement(ref line);

            Assert.IsTrue(cross.Elements[0].Start[0] == 1);
            Assert.IsTrue(cross.Elements[0].End[1] == 4);
        }
    }
}
