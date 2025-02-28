// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Exceptions;

namespace HydrothermalVents
{
    /// <summary>
    /// Parses command-line arguments for the application.
    /// </summary>
    public class ArgumentsParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentsParser"/> class with the specified arguments.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <exception cref="NoArgumentsException">Thrown when no arguments are provided.</exception>
        public ArgumentsParser(string[] args)
        {
            if(args.Length == 0) 
            {
                throw new NoArgumentsException("Requires at least on input file.");  
            }

            m_args = args;
        }

        /// <summary>
        /// Gets the input file paths from the arguments.
        /// </summary>
        /// <returns>A list of input file paths.</returns>
        /// <exception cref="BadArgumentFormatException">Thrown when the argument format is invalid.</exception>
        public List<string> getInputs()
        {
            try
            {
                List<string> inputs = new List<string>();
                int[] indexes = m_args.Select((b, i) => (b == "-i") || (b == "--input") ? i : -1).Where(i => i != -1).ToArray();

                foreach (int index in indexes)
                {
                    inputs.Add(m_args[index + 1]);
                }

                return inputs;
            } catch (Exception ex) 
            {
                throw new BadArgumentFormatException("Bad argument format.", ex);
            }
        }

        /// <summary>
        /// Gets the output file paths from the arguments.
        /// </summary>
        /// <returns>A list of output file paths.</returns>
        /// <exception cref="BadArgumentFormatException">Thrown when the argument format is invalid.</exception>
        public List<string> getOutputs()
        {
            try
            {
                List<string> inputs = new List<string>();
                int[] indexes = m_args.Select((b, i) => (b == "-o") || (b == "--ouput") ? i : -1).Where(i => i != -1).ToArray();

                foreach (int index in indexes)
                {
                    inputs.Add(m_args[index + 1]);
                }

                return inputs;
            }
            catch (Exception ex)
            {
                throw new BadArgumentFormatException("Bad argument format.", ex);
            }
        }

        /// <summary>
        /// Determines whether the drawing option is enabled.
        /// </summary>
        /// <returns><c>true</c> if the drawing option is enabled; otherwise, <c>false</c>.</returns>
        public bool doPainting() => m_args.Contains("-d") || m_args.Contains("--draw");

        /// <summary>
        /// Determines whether the output should be written to the console.
        /// </summary>
        /// <returns><c>true</c> if the output should be written to the console; otherwise, <c>false</c>.</returns>
        public bool writeOutputToConsole () => !(m_args.Contains("-q") || m_args.Contains("--quiet"));

        /// <summary>
        /// Determines whether the help option is enabled.
        /// </summary>
        /// <returns><c>true</c> if the help option is enabled; otherwise, <c>false</c>.</returns>
        public bool printHelp() => (m_args.Contains("-h") || m_args.Contains("--help") || m_args.Contains("-?"));

        string[] m_args;
    }
}
