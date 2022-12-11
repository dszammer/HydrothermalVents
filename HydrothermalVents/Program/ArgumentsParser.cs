﻿// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Exceptions;

namespace HydrothermalVents
{
    public class ArgumentsParser
    {
        public ArgumentsParser(string[] args)
        {
            if(args.Length == 0) 
            {
                throw new NoArgumentsException("Requires at least on input file.");  
            }

            m_args = args;
        }

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

        public bool doPainting() => m_args.Contains("-d") || m_args.Contains("--draw");
        public bool writeOutputToConsole () => !(m_args.Contains("-q") || m_args.Contains("--quiet"));
        public bool printHelp() => (m_args.Contains("-h") || m_args.Contains("--help") || m_args.Contains("-?"));

        string[] m_args;
    }
}
