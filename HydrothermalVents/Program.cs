using System;

namespace HydrothermalVents // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int Main(string[] args)
        {
            try
            {
                string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                List<IIO> writers = new List<IIO> { new ConsoleWriter(), new FileWriter(dir + @"../../../../../testout.txt") };
                List<IIO> readers = new List<IIO> { new FileReader(dir+@"../../../../../testin.txt") };

                ILineSegmentParser<int> lineSegmentParser = new LineSegmentParser();
                ICrossingParser<int, LineSegment<int>> crossingParser = new CrossingParser();

                ILineSegmentReader<int> reader = new LineSegmentReader<int>(lineSegmentParser, readers);
                ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriter<int, LineSegment<int>>(crossingParser, writers);

                ICrossingCalculator<int, LineSegment<int>> calculator = new LineSegmentCrossingCalculator();

                HydrothermalVentLineCrossings<int, int> HVLC = new HydrothermalVentLineCrossings<int,int>(ref reader,ref writer,ref calculator);

                HVLC.CalculateAllLineSegementCrossings();
                HVLC.PaintAllLineSegementsAndCrossings();
                HVLC.WriteAllLineSegementCrossings();

                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }

            
        }
    }
}

