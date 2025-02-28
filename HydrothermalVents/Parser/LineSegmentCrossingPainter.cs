// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents.Parser
{
    public class LineSegmentCrossingPainter : ILineSegmentCrossingPainter<int, LineSegment<int>>
    {
        public LineSegmentCrossingPainter(List<IIO>? writers)
        {
            m_writers = writers;
            m_canvas = Array.Empty<char[]>();
        }

        public void draw(List<LineSegment<int>> lineSegments, List<Crossing<int, LineSegment<int>>> crossings)
        {
            calculateCanvas(lineSegments);
            drawLines(lineSegments);
            drawCrossings(crossings);
            paintCanvas();
        }

        private void drawLines(List<LineSegment<int>> lineSegments)
        {
            foreach (LineSegment<int> lineSegment in lineSegments)
            {
                int dx = lineSegment.End[0] - lineSegment.Start[0];
                int dy = lineSegment.End[1] - lineSegment.Start[1];

                int x = lineSegment.Start[0] - zeroX;
                int y = lineSegment.Start[1] - zeroY;

                int endX = lineSegment.End[0] - zeroX;
                int endY = lineSegment.End[1] - zeroY;

                while (x != endX && y != endY)
                {
                    m_canvas[y][x] = '1';

                    if (dx != 0)
                        x += dx / Math.Abs(dx);

                    if (dy != 0)
                        y += dy / Math.Abs(dy);
                }

                m_canvas[y][x] = '1';
            }
        }

        private void drawCrossings(List<Crossing<int, LineSegment<int>>> crossings)
        {
            foreach (Crossing<int, LineSegment<int>> crossing in crossings)
            {
                int x = crossing.Position[0] - zeroX;
                int y = crossing.Position[1] - zeroY;

                m_canvas[y][x] = crossing.Elements.Count.ToString()[0];
            }
        }

        private void paintCanvas()
        {
            if (m_writers == null)
                return;

            foreach (IIO? writer in m_writers)
            {
                if (writer == null)
                    continue;

                for (int i = 0; i < m_canvas.GetLength(0); i++)
                {
                    writer.WriteLine(new string(m_canvas[i]));
                }
            }
        }

        private void calculateCanvas(List<LineSegment<int>> lineSegments)
        {
            foreach (LineSegment<int> lineSegment in lineSegments)
            {
                if (lineSegment.Start[0] > maxX)
                    maxX = lineSegment.Start[0];
                if (lineSegment.Start[1] > maxY)
                    maxY = lineSegment.Start[1];
                if (lineSegment.End[0] > maxX)
                    maxX = lineSegment.End[0];
                if (lineSegment.End[1] > maxY)
                    maxY = lineSegment.End[1];

                if (lineSegment.Start[0] < minX)
                    minX = lineSegment.Start[0];
                if (lineSegment.Start[1] < minY)
                    minY = lineSegment.Start[1];
                if (lineSegment.End[0] < minX)
                    minX = lineSegment.End[0];
                if (lineSegment.End[1] < minY)
                    minY = lineSegment.End[1];

            }

            zeroX = minX;
            zeroY = minY;

            m_canvas = new char[maxY - zeroY + 1][];

            for (int i = 0; i < m_canvas.Length; i++)
            {
                m_canvas[i] = new char[maxX - zeroX + 1];
                for (int j = 0; j < m_canvas[i].Length; j++)
                {
                    m_canvas[i][j] = ' ';
                }
            }
        }

        private List<IIO>? m_writers;
        private char[][] m_canvas;

        private int zeroX = 0, zeroY = 0;

        private int maxX = int.MinValue, maxY = int.MinValue;
        private int minX = int.MaxValue, minY = int.MaxValue;
    }
}
