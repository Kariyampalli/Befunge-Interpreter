using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    public class Interpreter
    {
        private bool end;  //boolen indicating if programm should end
        private bool stringModeOn;  //boolen indicating if string mode is on


        private Validator validator; //validator validates specifc values
        private FileReader fileReader;
        private ConsoleWriter writer;
        public EventHandler<WriteOnConsoleEventArgs> writeArgs; //Event for writing
        private InterpreterDirections directions; //manages characters that defines the program counters direction
        private InterpreterCommands commands; //manages characters that are a command
        private InterpreterStack interpreterStack; //stack for the values

        private char[,] playField; //Field for each char which was read from the befunge file
        private int currentX; //Current x position in the stack
        private int currentY; //Current y position in the stack

        public Interpreter(FileReader reader)
        {
            this.end = false;
            this.stringModeOn = false;

            this.validator = new Validator();
            this.fileReader = reader;
            this.writer = new ConsoleWriter();
            this.writeArgs += this.writer.WriteOnConsole;
            this.directions = new InterpreterDirections();
            this.commands = new InterpreterCommands();
            this.interpreterStack = new InterpreterStack();

            this.playField = new char[80, 25];
            this.currentX = 0;
            this.currentY = 0;
        }

        public void FillInPlayField()// Fills in the chars from the befunge code into the multidimensional playfield array after file has been validated
        {
            bool fileIsCorrect = false;

            while (!fileIsCorrect)
            {
                this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("--- Disclaimer: Only bf File allowed stored in the folder \\Befunge_Samples ---", ConsoleOutputType.WriteLine, true, ConsoleColor.White, this));
                this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("Put in the filename: ", ConsoleOutputType.WriteLine, false, ConsoleColor.White, this));
                string input = Console.ReadLine();

                try
                {
                    string[] code = fileReader.Read(input);
                    Tuple<bool, char[,]> t = this.validator.ValidateBefungeCode(code);
                    if (t.Item1)
                    {
                        this.playField = t.Item2;
                        fileIsCorrect = !fileIsCorrect;
                    }
                    else
                    {
                        this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("The file is in the wrong format/didn't match the criteria for being a valid file!", ConsoleOutputType.WriteErrorMessage, this));
                    }
                }
                catch (FormatException fex)
                {
                    this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs(fex.Message, ConsoleOutputType.WriteErrorMessage, this));
                }
                catch (Exception ex)
                {
                    this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs(ex.Message, ConsoleOutputType.WriteErrorMessage, this));
                }
            }
        }

        public void Run() //Will be called in the beginning and runs the program after the befunge code has been validated
        {
            this.FillInPlayField();
            this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("\n", ConsoleOutputType.WriteLine, true, ConsoleColor.White, this));
            while (!end)
            {
                try
                {
                    this.HandleChar(this.GetNextChar());
                    this.SetNextPosition();
                }
                catch (Exception ex)
                {
                    this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs(ex.Message, ConsoleOutputType.WriteErrorMessage, this));
                    bool rightEndInput = false;
                    while (!rightEndInput)
                    {
                        try
                        {
                            this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("End program? (y/n)", ConsoleOutputType.WriteLine, false, ConsoleColor.White, this));
                            if (this.validator.ValidateEndOfProgram(Console.ReadLine()))
                            {
                                this.end = true;
                                rightEndInput = true;
                            }
                            else
                            {
                                this.FillInPlayField();
                                this.interpreterStack.Clear();
                                this.directions.CurrentDirection = this.directions.BefungeDirections[0];
                                this.currentX = 0;
                                this.currentY = 0;
                                rightEndInput = true;
                            }
                        }
                        catch (Exception)
                        {
                            this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("Please put in a vlaid input!", ConsoleOutputType.WriteErrorMessage, this));
                        }
                    }
                }
            }
            Console.ReadLine();
        }

        public char GetNextChar() //Returns the next char within the plafield
        {
            return this.playField[this.currentX, this.currentY];
        }
        public void HandleChar(char character) //Handles the char received by the GetNextChar method
        {
            if (character == '"') //Activates /Deactivates StringMode
            {
                this.stringModeOn = !this.stringModeOn;
                return;
            }
            if (this.stringModeOn)
            {
                this.interpreterStack.Push((int)character);
            }
            else
            {
                if (character == ' ') //Empty chars will be skiped and not checked
                {
                    return;
                }
                if (this.CheckIsCommand(character)) //Checks if the char is a command that returns a value
                {
                    return;
                }
                if (this.CheckIsNumber(character)) //Checks if the char is a number
                {
                    return;
                }
                if (this.CheckIsDirection(character)) //Checks if the char is a direction
                {
                    return;
                }
                this.SpecialCommand(character); //Checks if the char is a one of the other commands
            }
        }

        //Checks if received char is a number
        private bool CheckIsNumber(char character)
        {
            Tuple<bool, int, string> t = this.validator.ValidateIntegerInput((object)character);
            if (t.Item1)
            {
                this.interpreterStack.Push(t.Item2);
            }
            return t.Item1;
        }

        //Checks if received char is a command
        private bool CheckIsCommand(char character)
        {
            Tuple<bool, object> t = this.commands.GetCommandSpecificValue(character, this.interpreterStack);
            if (t.Item1)
            {
                this.interpreterStack.Push(t.Item2);
            }
            return t.Item1;
        }

        //Checks if received char is a direction
        private bool CheckIsDirection(char character)
        {
            return this.directions.IsDirection(character, this.interpreterStack);
        }

        //Points to the next position
        public void SetNextPosition()
        {
            Tuple<int, int> t = this.directions.GetNextPosition(this.currentX, this.currentY);
            this.currentX = t.Item1;
            this.currentY = t.Item2;
        }

        public void SpecialCommand(char character)
        {
            switch (character)
            {
                case ':': //duplicates top element of the stack
                    object duplicatedValue = this.interpreterStack.Pop();
                    this.interpreterStack.Push(duplicatedValue);
                    this.interpreterStack.Push(duplicatedValue);
                    break;
                case '\\': //Switches the two top elements of the stack
                    object a = this.interpreterStack.Pop();
                    object b = this.interpreterStack.Pop();
                    this.interpreterStack.Push(a);
                    this.interpreterStack.Push(b);
                    break;
                case '$': //Just pops' top elements of the stack
                    this.interpreterStack.Pop();
                    break;
                case '.': //Asci format of the top element will be written out
                    Tuple<bool, int, string> t = this.validator.ValidateIntegerInput(interpreterStack.Pop());
                    if (!t.Item1)
                    {
                        throw new InvalidOperationException("There is something wrong within the read code, the (.) command couldn't be execuded!");
                    }
                    this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs($"{t.Item2} ", ConsoleOutputType.Write, false, ConsoleColor.Cyan, this));
                    break;
                case ',': //Get the top element of the stack adn write it out as an ASCII-sign
                    this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs(Convert.ToChar(this.interpreterStack.Pop()).ToString(), ConsoleOutputType.Write, false, ConsoleColor.Cyan, this));
                    break;
                case '#': //Go to the next cell
                    this.SetNextPosition();
                    break;
                case 'g': //Get x and y from stack and push the ASCII-value of the char in the playfield at x and y position to the stack
                    object y = this.interpreterStack.Pop();
                    object x = this.interpreterStack.Pop();
                    int gx = Convert.ToInt32(x);
                    int gy = Convert.ToInt32(y);
                    if (gx > 80 || gy > 25 || gx < 0 || gy < 0)
                    {
                        throw new IndexOutOfRangeException($"g command tried to push a vlaue into an invalid position y:{gy}  x:{gx}");
                    }
                    this.interpreterStack.Push((int)this.playField[Convert.ToInt32(x), Convert.ToInt32(y)]);
                    break;
                case 'p'://Get x, y and v from stack and change the char in the playfield at x and y position to the ASCII-value of v
                    y = this.interpreterStack.Pop();
                    x = this.interpreterStack.Pop();
                    int px = Convert.ToInt32(x);
                    int py = Convert.ToInt32(y);
                    if (px > 80 || py > 25 || px < 0 || py < 0)
                    {
                        throw new IndexOutOfRangeException($"g command tried to push a vlaue into an invalid position y:{py}  x:{px}");
                    }
                    object v = this.interpreterStack.Pop();
                    this.playField[Convert.ToInt32(x), Convert.ToInt32(y)] = Convert.ToChar(Convert.ToInt32(v));
                    break;
                case '&': //Asks the user to input a number and then push the number to the stack
                    //this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("integer>> ", ConsoleOutputType.Write, false, ConsoleColor.White, this));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    object input = Console.ReadLine();
                    Tuple<bool, int, string> tAmpersand = this.validator.ValidateIntegerInput(input);//NEEDS TO BE VALIDATED
                    if (tAmpersand.Item1)
                    {
                        this.interpreterStack.Push(tAmpersand.Item2);
                    }
                    break;
                case '~': //Asks the user to input a character, to knwow which operation to perform next
                    bool correct = false;
                    while (!correct)
                    {
                        //this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs("char>> ", ConsoleOutputType.Write, false, ConsoleColor.White, this));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string c = Console.ReadLine();
                        Tuple<bool, char, string> tTilde = this.validator.ValidateCharcterInput(c);

                        if (tTilde.Item1)
                        {
                            this.interpreterStack.Push((int)tTilde.Item2);
                            correct = true;
                        }
                        else
                        {
                            this.writeArgs?.Invoke(this, new WriteOnConsoleEventArgs(tTilde.Item3, ConsoleOutputType.WriteErrorMessage, this));
                        }
                    }
                    break;
                case '@': //Ends the program
                    this.end = true;
                    break;
                default:
                    if (character == '\0')
                    {
                        return;
                    }
                    throw new ApplicationException("Something is wrong with the file!\n" +
                        $"The character that tried to be checked as a command isn't even a command!\nChar: {character}");
            }
        }
    }
}
