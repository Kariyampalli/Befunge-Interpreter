using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Commands
{
    public class Negation : ICommand
    {
        public char Command
        {
            get
            {
                return '!';
            }
        }
        public object Work(InterpreterStack stack)
        {
            if (stack == null || stack.Count() < 1 || stack.Peek() == null)
            {
                throw new InvalidOperationException("Stack doesn't have enough values for negation operation or the values within the stack for the operation are invalid!");
            }
            if (stack.Pop().ToString() == "0")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
