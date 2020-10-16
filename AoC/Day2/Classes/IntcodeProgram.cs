using AoC.Day2.Enums;
using AoC.Day2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Day2.Classes
{
    public class IntcodeProgram : IIntcodeProgram
    {
        private List<int> _rawIntCode;

        public List<int> IntCodeSequence 
        { 
            get
            {
                return _rawIntCode;
            }
        }

        public IntcodeProgram(string rawIntCode)
        {
            _rawIntCode = new List<int>();
            foreach (string s in rawIntCode.Split(','))
            {
                _rawIntCode.Add(Convert.ToInt32(s));
            }
        }

        public IntcodeProgram(int[] rawIntCode)
        {
            _rawIntCode = new List<int>(rawIntCode);
        }

        public string Run()
        {
            List<int> outputSeq = new List<int>(_rawIntCode);
            bool isRunning = true;
            int currentOpcodePos = 0;

            while (isRunning)
            {
                OpcodeEnum currentOpcode = (OpcodeEnum)outputSeq[currentOpcodePos];

                if (currentOpcode == OpcodeEnum.Terminate)
                {
                    break;
                }

                int[] inputPos = { outputSeq[currentOpcodePos + 1], outputSeq[currentOpcodePos + 2] };
                int[] inputVals = { outputSeq[inputPos[0]], outputSeq[inputPos[1]] };
                int outputPos = outputSeq[currentOpcodePos + 3];

                if (currentOpcode == OpcodeEnum.Add)
                {
                    outputSeq[outputPos] = inputVals.Sum();
                }
                else if (currentOpcode == OpcodeEnum.Multiply)
                {
                    outputSeq[outputPos] = inputVals.Aggregate(1, (acc, x) => acc * x);
                }
                else
                {
                    isRunning = false;
                    throw new Exception("Unknown opcode");
                }

                currentOpcodePos += 4;
            }

            return string.Join(',', outputSeq);
        }
    }
}
