using HydrothermalVents;

namespace BusinessLogicTests
{
    [TestClass]
    public class CrossingTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            Crossing<int, Linesegment<int>> crossdef = new Crossing<int, Linesegment<int>>();

            int[] pos = new int[] {};
            List<Linesegment<int>> listLines = new List<Linesegment<int>>();
            
            Crossing<int, Linesegment<int>> cross = new Crossing<int, Linesegment<int>>(pos,listLines);
        }
        [TestMethod]
        public void TestPositionGetSet()
        {
            Crossing<int, Linesegment<int>> cross = new Crossing<int, Linesegment<int>>();
            cross.Position = new int[] { 10, 20 };

            Assert.IsTrue(cross.Position[0] == 10);
            Assert.IsTrue(cross.Position[0] == 10);
        }

        [TestMethod]
        public void TestLinesGetSet()
        {
            Crossing<int, Linesegment<int>> cross = new Crossing<int, Linesegment<int>>();

            List<Linesegment<int>> listLines = new List<Linesegment<int>>();
            Linesegment<int> line = new Linesegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            listLines.Add(line);

            cross.Elements = listLines;

            Assert.IsTrue(cross.Elements[0].Start[0] == 1);
            Assert.IsTrue(cross.Elements[0].End[1] == 4);

        }

        [TestMethod]
        public void TestAddLine()
        {
            Crossing<int, Linesegment<int>> cross = new Crossing<int, Linesegment<int>>();
            Linesegment<int> line = new Linesegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            cross.AddLinesegement(ref line);

            Assert.IsTrue(cross.Elements[0].Start[0] == 1);
            Assert.IsTrue(cross.Elements[0].End[1] == 4);
        }
    }
}
