using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    class Program
    {
        static void Main(string[] args) //Sets interpreter object and calls the run method for the program
        {
            Interpreter interpreter = new Interpreter(new FileReader());
            interpreter.Run();
        }
    }
}
