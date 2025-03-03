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
        private readonly ArgumentsParser _arguments;
        private readonly string _directory;
        private List<IIO> _writers;
        private List<IIO> _readers;
        private ICrossingCalculator<int, LineSegment<int>> _calculator;
        private ILineSegmentParser<int> _lineSegmentParser;
        private ICrossingParser<int, LineSegment<int>> _crossingParser;
        private ILineSegmentReader<int> _reader;
        private ICrossingsWriter<int, LineSegment<int>> _writer;
        private ILineSegmentCrossingPainter<int, LineSegment<int>>? _painter;

        /// <summary>
        /// Initializes a new instance of the <see cref="HydrothermalVentLineCrossingsBuilder"/> class with the specified arguments and directory.
        /// </summary>
        /// <param name="arguments">The command-line arguments parser.</param>
        /// <param name="directory">The directory path for input and output files.</param>
        public HydrothermalVentLineCrossingsBuilder(ArgumentsParser arguments, string directory)
        {
            _arguments = arguments;
            _directory = directory;
            _writers = new List<IIO>();
            _readers = new List<IIO>();
        }

        /// <summary>
        /// Configures the writers based on the command-line arguments.
        /// </summary>
        /// <returns>The current instance of <see cref="HydrothermalVentLineCrossingsBuilder"/>.</returns>
        /// <exception cref="BadArgumentFormatException">Thrown when no input sources are provided.</exception>
        public HydrothermalVentLineCrossingsBuilder ConfigureWriters()
        {
            if (_arguments.writeOutputToConsole())
                _writers.Add(new ConsoleWriter());

            foreach (string output in _arguments.getOutputs())
            {
                _writers.Add(new FileWriter(Path.Combine(_directory, output)));
            }

            return this;
        }

        /// <summary>
        /// Configures the readers based on the command-line arguments.
        /// </summary>
        /// <returns>The current instance of <see cref="HydrothermalVentLineCrossingsBuilder"/>.</returns>
        public HydrothermalVentLineCrossingsBuilder ConfigureReaders()
        {
            foreach (string input in _arguments.getInputs())
            {
                _readers.Add(new FileReader(Path.Combine(_directory, input)));
            }

            if (_readers.Count == 0)
            {
                throw new BadArgumentFormatException("At least one input source is needed.");
            }

            return this;
        }

        /// <summary>
        /// Configures the parsers and calculators.
        /// </summary>
        /// <returns>The current instance of <see cref="HydrothermalVentLineCrossingsBuilder"/>.</returns>

        public HydrothermalVentLineCrossingsBuilder ConfigureParsersAndCalculators()
        {
            _calculator = new LineSegmentCrossingCalculator();
            _lineSegmentParser = new LineSegmentParser();
            _crossingParser = new CrossingParser();
            _reader = new LineSegmentReader<int>(_lineSegmentParser, _readers);
            _writer = new CrossingsWriter<int, LineSegment<int>>(_crossingParser, _writers);

            if (_arguments.doPainting() && _arguments.writeOutputToConsole())
                _painter = new LineSegmentCrossingPainter(new List<IIO> { new ConsoleWriter() });
            else
                _painter = null;

            return this;
        }

        /// <summary>
        /// Builds and returns the <see cref="HydrothermalVentLineCrossings{T, U}"/> instance.
        /// </summary>
        /// <returns>A configured instance of <see cref="HydrothermalVentLineCrossings{T, U}"/>.</returns>
        public HydrothermalVentLineCrossings<int, int> Build()
        {
            return new HydrothermalVentLineCrossings<int, int>(_calculator, _reader, _writer, _painter);
        }
    }
}