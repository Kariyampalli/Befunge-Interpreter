using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Commands
{
    public interface ICommand
    {
        char Command { get; }
        object Work(InterpreterStack stack);
    }
}
