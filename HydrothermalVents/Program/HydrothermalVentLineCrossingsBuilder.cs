using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;
using HydrothermalVents.IO;
using HydrothermalVents.Parser;
using System;
using System.Collections.Generic;
using System.IO;

namespace HydrothermalVents
{
    /// <summary>
    /// Builder class for constructing the HydrothermalVentLineCrossings business logic.
    /// </summary>
    public class HydrothermalVentLineCrossingsBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HydrothermalVentLineCrossingsBuilder"/> class with the specified arguments and directory.
        /// </summary>
        /// <param name="arguments">The command-line arguments parser.</param>
        /// <param name="directory">The directory path for input and output files.</param>
        public HydrothermalVentLineCrossingsBuilder(ArgumentsParser arguments, string directory)
        {
            m_arguments = arguments;
            m_directory = directory;
            m_calculator = new LineSegmentCrossingCalculator();
            m_lineSegmentParser = new LineSegmentParser();
            m_crossingParser = new CrossingParser();
            m_writers = new List<IIO>();
            m_readers = new List<IIO>();

            ConfigureWriters();
            ConfigureReaders();

            m_reader = new LineSegmentReader<int>(m_lineSegmentParser, m_readers);
            m_writer = new CrossingsWriter<int, LineSegment<int>>(m_crossingParser, m_writers);

            ConfigureParsersAndCalculators();
        }

        private HydrothermalVentLineCrossingsBuilder ConfigureWriters()
        {
            if (m_arguments.writeOutputToConsole())
                m_writers.Add(new ConsoleWriter());

            foreach (string output in m_arguments.getOutputs())
            {
                m_writers.Add(new FileWriter(Path.Combine(m_directory, output)));
            }

            return this;
        }

        private HydrothermalVentLineCrossingsBuilder ConfigureReaders()
        {
            foreach (string input in m_arguments.getInputs())
            {
                m_readers.Add(new FileReader(Path.Combine(m_directory, input)));
            }

            if (m_readers.Count == 0)
            {
                throw new BadArgumentFormatException("At least one input source is needed.");
            }

            return this;
        }

        private HydrothermalVentLineCrossingsBuilder ConfigureParsersAndCalculators()
        {
            if (m_arguments.doPainting() && m_arguments.writeOutputToConsole())
                m_painter = new LineSegmentCrossingPainter(new List<IIO> { new ConsoleWriter() });
            else
                m_painter = null;

            return this;
        }

        /// <summary>
        /// Builds and returns the <see cref="HydrothermalVentLineCrossings{T, U}"/> instance.
        /// </summary>
        /// <returns>A configured instance of <see cref="HydrothermalVentLineCrossings{T, U}"/>.</returns>
        public HydrothermalVentLineCrossings<int, int> Build()
        {
            return new HydrothermalVentLineCrossings<int, int>(m_calculator, m_reader, m_writer, m_painter);
        }

        private readonly ArgumentsParser m_arguments;
        private readonly string m_directory ="";
        private List<IIO> m_writers;
        private List<IIO> m_readers;
        private ICrossingCalculator<int, LineSegment<int>> m_calculator;
        private ILineSegmentParser<int> m_lineSegmentParser;
        private ICrossingParser<int, LineSegment<int>> m_crossingParser;
        private ILineSegmentReader<int> m_reader;
        private ICrossingsWriter<int, LineSegment<int>> m_writer;
        private ILineSegmentCrossingPainter<int, LineSegment<int>>? m_painter;
    }
}