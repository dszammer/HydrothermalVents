// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Parser;
using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;
using HydrothermalVents.IO;

namespace HydrothermalVents
{
    /// <summary>
    /// The main entry point for the Hydrothermal Vents application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the return values for the application.
        /// </summary>
        enum ReturnValues : int
        {
            /// <summary>
            /// Indicates that the application completed successfully.
            /// </summary>
            OK = 0,

            /// <summary>
            /// Indicates that there was a bad argument format.
            /// </summary>
            BadArgumentFormat = -1,

            /// <summary>
            /// Indicates that there was a bad input file format.
            /// </summary>
            BadInputFileFormat = -2,

            /// <summary>
            /// Indicates that an unknown exception occurred.
            /// </summary>
            UnknownExeption = -3
        }

        /// <summary>
        /// The main entry point for the application.
        /// It builds the application based on the command-line arguments and runs the calculation process and handles exeptions.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>An integer representing the application's exit code.</returns>
        static int Main(string[] args)
        {
            try
            {
                string? dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                if (dir == null)
                {
                    throw new InvalidOperationException("The directory path could not be determined.");
                }

                ArgumentsParser arguments = new ArgumentsParser(args);

                if (arguments.printHelp())
                {
                    printHelp();
                    return (int)ReturnValues.OK;
                }

                // Use the builder to construct the business logic
                HydrothermalVentLineCrossings<int, int> HVLC = new HydrothermalVentLineCrossingsBuilder(arguments, dir)
                   .Build();

                if (arguments.writeOutputToConsole())
                {
                    Console.WriteLine("Calculating... this might take a while.");
                    Console.WriteLine("Press ctrl+C to cancel.");
                }

                // The magic happens here.
                HVLC.CalculateAllLineSegementCrossings();

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

        /// <summary>
        /// Prints the help information for the application.
        /// </summary>
        static void printHelp()
        {
            Console.WriteLine("Hydrothermal Vent Line Calulator.");
            Console.WriteLine("(c) David Szammer 2022. All rights reserved.");
            Console.WriteLine("");

            Console.WriteLine("Usage: ");
            Console.WriteLine("\"-i <relative file location>\" \"--input <relative file location>\"\tSecifies input file(s).");
            Console.WriteLine("\"-o <relative file location>\" \"--output <relative file location>\"\tSecifies output file(s).");
            Console.WriteLine("\"-q \" \"--quiet\"\t\t\t\t\t\t\tNo output in console.");
            Console.WriteLine("\"-d \" \"--draw\"\t\t\t\t\t\t\t\tDraw line diagram.");
            Console.WriteLine("\"-h \" \"--help\"\t\t\t\t\t\t\t\tDisplay help.");
        }
    }
}

