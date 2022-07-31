using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    public class ConsoleWriter
    {
        private ConsoleWriterValidator validator;
        public ConsoleWriter()
        {
            this.validator = new ConsoleWriterValidator();
        }

        //Selects which way to write on the console
        public void WriteOnConsole(object sender, WriteOnConsoleEventArgs args) //Method called up by an event and choses writting method
        {
            if(args == null)
            {
                throw new InvalidOperationException("ConsoleWriter received an argument that was null!");
            }
            switch (args.OutputType)
            {
               
                case ConsoleOutputType.WriteErrorMessage:
                    this.WriteErrorMessage(args.Output);
                    break;
                case ConsoleOutputType.Write:
                    this.Write(args.Output, args.ClearConsole, args.Color);
                    break;
              
                case ConsoleOutputType.WriteLine:
                    this.WriteLine(args.Output, args.ClearConsole, args.Color);
                    break;
                default:
                    Console.WriteLine("Writing Type doesn't exist!");
                    break;
            }
        }

        public void WriteErrorMessage(string message)
        {
            if (this.validator.ValidateOutput(message))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(message);
                Thread.Sleep(2000);
               
            }
            else
            {
                throw new InvalidOperationException("No output message was passed!");
            }
        }

        public void Write(string output, bool clearConsoleBeforeWrite, ConsoleColor color)
        {
            if (this.validator.ValidateOutput(output))
            {
                if (clearConsoleBeforeWrite)
                {
                    Console.Clear();
                }
                Console.ForegroundColor = color;
                Console.Write(output);
            }
            else
            {
                throw new InvalidOperationException("No output message was passed!");
            }
        }
        public void WriteLine(string output, bool clearConsoleBeforeWrite, ConsoleColor color)
        {
            if (this.validator.ValidateOutput(output))
            {
                if (clearConsoleBeforeWrite)
                {
                    Console.Clear();
                }
                Console.ForegroundColor = color;
                Console.WriteLine(output);
            }
            else
            {
                throw new InvalidOperationException("No output message was passed!");
            }
        }
    }
}
