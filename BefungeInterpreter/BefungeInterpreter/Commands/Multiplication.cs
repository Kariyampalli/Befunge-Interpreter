using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Commands
{
    public class Multiplication : ICommand
    {
        public char Command
        {
            get
            {
                return '*';
            }
        }
        public object Work(InterpreterStack stack)
        {
            int a;
            int b;

            if (stack == null || stack.Count() < 2 || stack.Peek() == null || !int.TryParse(stack.Pop().ToString(), out a) || stack.Peek() == null || !int.TryParse(stack.Pop().ToString(), out b))
            {
                throw new InvalidOperationException("Stack doesn't have enough values for multiplication operation or the values within the stack for the operation are invalid!");
            }

            return a * b;
        }
    }
}
