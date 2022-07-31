using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    public class ConsoleWriterValidator
    {
        public bool ValidateOutput(string output) //Validator for the ConsoleWriter
        {
            if (output == null)
            {
                return false;
            }

            if (output.Contains("\n"))
            {
                return true;
            }

            return !string.IsNullOrEmpty(output);
        }
    }
}
