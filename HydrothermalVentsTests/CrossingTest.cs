using HydrothermalVents;

namespace HydrothermalVentsTests
{
    [TestClass]
    public class CrossingTest
    {
        [TestMethod]
        public void TestCTOR()
        {
            Crossing<int> crossdef = new Crossing<int>();

            int[] pos = new int[] {};
            List<Linesegment<int>> listLines = new List<Linesegment<int>>();
            
            Crossing<int> cross = new Crossing<int>(pos,listLines);
        }
        [TestMethod]
        public void TestPositionGetSet()
        {
            Crossing<int> cross = new Crossing<int>();
            cross.Position = new int[] { 10, 20 };

            Assert.IsTrue(cross.Position[0] == 10, "start should be the new vector.");
            Assert.IsTrue(cross.Position[0] == 10, "start should be the new vector.");

            List<Linesegment<int>> listLines = new List<Linesegment<int>>();
            Linesegment<int> line = new Linesegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            listLines.Add(line);

            cross.Lines = listLines;

            Assert.IsTrue(cross.Position[0] == 10, "start should be the new vector.");
            Assert.IsTrue(cross.Position[0] == 10, "start should be the new vector.");

        }

        [TestMethod]
        public void TestLinesGetSet()
        {
            Crossing<int> cross = new Crossing<int>();

            List<Linesegment<int>> listLines = new List<Linesegment<int>>();
            Linesegment<int> line = new Linesegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            listLines.Add(line);

            cross.Lines = listLines;

            Assert.IsTrue(cross.Lines[0].Start[0] == 1, "start should be the new vector.");
            Assert.IsTrue(cross.Lines[0].End[1] == 4, "start should be the new vector.");

        }

        [TestMethod]
        public void TestAddLine()
        {
            Crossing<int> cross = new Crossing<int>();
            Linesegment<int> line = new Linesegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            cross.AddLinesegement(ref line);

            Assert.IsTrue(cross.Lines[0].Start[0] == 1, "start should be the new vector.");
            Assert.IsTrue(cross.Lines[0].End[1] == 4, "start should be the new vector.");
        }

        
    }
}
