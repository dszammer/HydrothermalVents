using System;
using System.Reflection.Metadata;

namespace HydrothermalVents
{
    internal class Program
    {
        enum ReturnValues : int
        {
            OK = 0,
            BadArgumentFormat = -1,
            BadInputFileFormat = -2,
            UnknownExeption = -3
        }

        static int Main(string[] args)
        {
            try
            {
                string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                ArgumentsParser arguments = new ArgumentsParser(args);

                if (arguments.printHelp())
                {
                    printHelp();
                    return (int)ReturnValues.OK;
                }

                List<IIO> writers = new List<IIO>();

                if (arguments.writeOutputToConsole())
                    writers.Add(new ConsoleWriter());

                foreach (string output in arguments.getOutputs()) 
                {
                    writers.Add(new FileWriter(dir + output));
                }

                List<IIO> readers = new List<IIO> ();

                foreach (string inputs in arguments.getInputs())
                {
                    readers.Add(new FileReader(dir + inputs));
                }

                if (readers.Count == 0) 
                {
                    throw new BadArgumentFormatException("At least one input source is needed.");
                }

                ICrossingCalculator<int, LineSegment<int>> calculator = new LineSegmentCrossingCalculator();
                ILineSegmentParser<int> lineSegmentParser = new LineSegmentParser();
                ICrossingParser<int, LineSegment<int>> crossingParser = new CrossingParser();
                ILineSegmentReader<int> reader = new LineSegmentReader<int>(lineSegmentParser, readers);
                ICrossingsWriter<int, LineSegment<int>> writer = new CrossingsWriter<int, LineSegment<int>>(crossingParser, writers);
                ILineSegmentCrossingPainter<int, LineSegment<int>>? painter;

                if (arguments.doPainting() && arguments.writeOutputToConsole())
                    painter = new LineSegmentCrossingPainter(new List<IIO> { new ConsoleWriter() });
                else
                    painter = null;


                HydrothermalVentLineCrossings<int, int> HVLC = new HydrothermalVentLineCrossings<int, int>(calculator, reader, writer, painter);

                Console.WriteLine("Calculating... this might take a while.");
                Console.WriteLine("Press ctrl+C to cancel.");

                HVLC.CalculateAllLineSegementCrossings();

                Console.Clear();
        
                HVLC.PaintAllLineSegementsAndCrossings();
                HVLC.WriteAllLineSegementCrossings();

                return (int)ReturnValues.OK;
            }
            catch (ArgumentsParserException ex)
            {
                Console.WriteLine($"Bad argument format: \"{ex.Message}\". Aborting calculation.");
                Console.WriteLine("\n\n");
                printHelp();
                return (int)ReturnValues.BadArgumentFormat;
            }
            catch (LineSegmentParserException ex)
            {
                Console.WriteLine($"Corrupt input file: \"{ex.Message}\". Aborting calculation.");
                return (int)ReturnValues.BadInputFileFormat;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured: \"{ex.Message}\". Aborting calculation.");
                Console.WriteLine("\n\n");
                printHelp();
                return (int)ReturnValues.UnknownExeption;
            }
        }
        static void printHelp()
        {
            Console.WriteLine("Hydrothermal Vent Line Calulator.");
            Console.WriteLine("(c) David Szammer 2022. All rights reserved.");
            Console.WriteLine("");

            Console.WriteLine("Usage: ");
            Console.WriteLine("\"-i <relative file location>\" \"--input <relative file location>\"\tSecifies input file(s).");
            Console.WriteLine("\"-o <relative file location>\" \"--output <relative file location>\"\tSecifies output file(s).");
            Console.WriteLine("\"-s \" \"--silent\"\t\t\t\t\t\t\tNo output in console.");
            Console.WriteLine("\"-p \" \"--paint\"\t\t\t\t\t\t\t\tPaint line diagram.");
            Console.WriteLine("\"-h \" \"--help\"\t\t\t\t\t\t\t\tDisplay help.");
        }
    }
}

