using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BefungeInterpreter.Commands;
using BefungeInterpreter.Directions;

namespace BefungeInterpreter
{
    public class InterpreterCommands
    {
        public List<ICommand> BefungeCommands;
        private ICommand currentCommand;
        public InterpreterCommands()
        {
            this.BefungeCommands = new List<ICommand> {
                new Addition(), new Subtraction(), new Multiplication(),  new Division(), new Modulo(), new Negation(), new GreaterThan()
            };
        }

        private bool IsCommand(char character) //Checks if the char is a command
        {
            foreach (var command in this.BefungeCommands)
            {
                if (command.Command == character)
                {
                    this.currentCommand = command; //If char is command set currentCommand to the command so it can be performed in the called up method
                    return true;
                }
            }
            return false;
        }

        public Tuple<bool,object> GetCommandSpecificValue(char character, InterpreterStack stack) //Checks if char is command and performs the task of the command and returns back a tuple containing if char is a command and the value the command returned
        {
            if(IsCommand(character))
            {
                return Tuple.Create(true, this.currentCommand.Work(stack)); //Performs the task of the current command set in the currentCommand property
            }
            return Tuple.Create(false, new object());
        }
    }
}
