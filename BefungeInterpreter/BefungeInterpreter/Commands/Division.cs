using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Commands
{
    public class Division : ICommand
    {
        public char Command
        {
            get
            {
                return '/';
            }
        }
        public object Work(InterpreterStack stack)
        {
            int a;
            int b;

            if (stack == null || stack.Count() < 2 || stack.Peek() == null || !int.TryParse(stack.Pop().ToString(), out a) || stack.Peek() == null || !int.TryParse(stack.Pop().ToString(), out b))
            {
                throw new InvalidOperationException("Stack doesn't have enough values for division operation or the values within the stack for the operation are invalid!");
            }

            if (a == 0)
            {
                Console.Write("\na is 0 in the stack, please put in a result:");
                int result = int.Parse(Console.ReadLine());//Mit validator abfragen ob der wert gültig ist
                return result;
            }
            else
            {
                return b / a;
            }          
        }
    }
}
