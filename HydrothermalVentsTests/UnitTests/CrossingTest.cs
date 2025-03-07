﻿// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVentsUnitTests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Crossing{U, T}"/> class.
    /// </summary>
    [TestClass]
    public class CrossingTest
    {
        /// <summary>
        /// Tests the constructor of the <see cref="Crossing{U, T}"/> class.
        /// </summary>
        [TestMethod]
        public void TestCTOR()
        {
            Crossing<int, LineSegment<int>> crossdef = new Crossing<int, LineSegment<int>>();

            int[] pos = new int[] { };
            List<LineSegment<int>> listLines = new List<LineSegment<int>>();

            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>(pos, listLines);
        }
        
        /// <summary>
        /// Tests the getter and setter for the <see cref="Crossing{U, T}.Position"/> property.
        /// </summary>
        [TestMethod]
        public void TestPositionGetSet()
        {
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>();
            cross.Position = new int[] { 10, 20 };

            Assert.IsTrue(cross.Position[0] == 10);
            Assert.IsTrue(cross.Position[0] == 10);
        }

        /// <summary>
        /// Tests the getter and setter for the <see cref="Crossing{U, T}.Elements"/> property.
        /// </summary>
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

        /// <summary>
        /// Tests the <see cref="Crossing{U, T}.AddElement(T)"/> method.
        /// </summary>
        [TestMethod]
        public void TestAddLine()
        {
            Crossing<int, LineSegment<int>> cross = new Crossing<int, LineSegment<int>>();
            LineSegment<int> line = new LineSegment<int>(new int[] { 1, 2 }, new int[] { 3, 4 });
            cross.AddElement(line);

            Assert.IsTrue(cross.Elements[0].Start[0] == 1);
            Assert.IsTrue(cross.Elements[0].End[1] == 4);
        }
    }
}
