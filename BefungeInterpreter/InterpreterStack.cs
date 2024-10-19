using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    public class InterpreterStack
    {
        private Stack stack;
        public InterpreterStack()
        {
            this.stack = new Stack();
        }

        public void Clear()
        {
            this.stack.Clear();
        }

        public object Pop() 
        {
            if (this.stack.Count <= 0) //if stack is empty push a 0 value to the stack
            {
                this.stack.Push(0);
            }      
            return this.stack.Pop();
        }

        public int Count()
        {
            return this.stack.Count;
        }

        public void Push(object o)
        {
            if(o == null)
            {
                throw new InvalidOperationException("Program tried to push null to stack!");
            }
            this.stack.Push(o);
        }

        public object Peek()
        {
            return this.stack.Peek();
        }
    }
}
