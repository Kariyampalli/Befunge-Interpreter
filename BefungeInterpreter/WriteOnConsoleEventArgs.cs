using System;

namespace BefungeInterpreter
{
    public enum ConsoleOutputType
    {
        WriteErrorMessage,
        Write,     
        WriteLine,
    }
    public class WriteOnConsoleEventArgs
    {
        //For ErrorMessage
        public WriteOnConsoleEventArgs(string output, ConsoleOutputType type, object sender)
        {
            if(type != ConsoleOutputType.WriteErrorMessage)
            {
                throw new Exception("WriteOnConsoleEventArgs Konstruktor received wrong type!");
            }
            this.Output = output;
            this.OutputType = type;
            this.Sender = sender;
        }

        //For Write and WriteLine
        public WriteOnConsoleEventArgs(string output, ConsoleOutputType type, bool clearConsole, ConsoleColor color, object sender)
        {
            if (type == ConsoleOutputType.WriteErrorMessage)
            {
                throw new Exception("WriteOnConsoleEventArgs Konstruktor received wrong type!");
            }
            this.Output = output;
            this.OutputType = type;
            this.ClearConsole = clearConsole;
            this.Color = color;
            this.Sender = sender;
        }
        
        public object Sender { get; private set; }
        public ConsoleColor Color
        {
            get;
            set;
        }
        public bool ClearConsole
        {
            get;
            set;
        }

        public string Output
        {
            get;
            set;
        }

        public ConsoleOutputType OutputType
        {
            get;
            set;
        }
    }
}
