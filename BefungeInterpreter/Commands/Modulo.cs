using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Commands
{
    public class Modulo : ICommand
    {
        private EventHandler<WriteOnConsoleEventArgs> writeArgs;
        private ConsoleWriter writer;
        private Validator validator;
        public Modulo()
        {
            this.writer = new ConsoleWriter();
            this.validator = new Validator();
            this.writeArgs += this.writer.WriteOnConsole;
        }
        public char Command
        {
            get
            {
                return '%';
            }
        }
        public object Work(InterpreterStack stack)
        {
            int a;
            int b;

            if (stack == null || stack.Count() < 2 || stack.Peek() == null || !int.TryParse(stack.Pop().ToString(), out a) || stack.Peek() == null || !int.TryParse(stack.Pop().ToString(), out b))
            {
                throw new InvalidOperationException("Stack doesn't have enough values for modulo operation or the values within the stack for the operation are invalid!");
            }

            if (a == 0)
            {
                Tuple<bool, int, string> t;

                do
                {
                    this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("\na is 0 in the stack, please put in a result>> ", ConsoleOutputType.Write, false, ConsoleColor.White, this));
                    t = this.validator.ValidateIntegerInput(Console.ReadLine());
                    if (t.Item1)
                    {
                        return t.Item2;
                    }
                    else
                    {
                        this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs(t.Item3, ConsoleOutputType.WriteErrorMessage, this));
                    }
                } while (!t.Item1);
            }
            else
            {
                return b % a;
            }
            throw new Exception("Modulu method ended without returning a object");
        }
    }
}
