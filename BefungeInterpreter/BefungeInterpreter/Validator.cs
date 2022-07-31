using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    public class Validator
    {
        public Validator()
        {

        }
        public Tuple<bool, int, string> ValidateIntegerInput(object val)
        {
            try
            {
                int value = Convert.ToInt32(val.ToString());
                return Tuple.Create(true, value, "Input is right");
            }
            catch (Exception)
            {
                return Tuple.Create(false, -1, "Input is wrong");
            }
        }

        public Tuple<bool, char, string> ValidateCharcterInput(object c)
        {
            try
            {
                char character = Convert.ToChar(c.ToString());
                return Tuple.Create(true, character, "Input is a character");
            }
            catch (Exception)
            {
                return Tuple.Create(false, ' ', "Input isn't a character");
            }
        }

        public bool ValidateEndOfProgram(string end)
        {
            if(end == null)
            {
                throw new InvalidOperationException("input received a null value!");
            }
            switch (end.Trim())
            {
                case "n":
                    return false;
                case "y":
                    return true;
                default:
                    throw new InvalidOperationException("Please enter a valid character!");
            }
        }

        public Tuple<bool, char[,]> ValidateBefungeCode(string[] code)
        {
            int x = 0;
            int y = 0;

            char[,] playField = new char[80, 25];

            if (code == null || code.Length > 25 || code.Any(c=>c == null) || code.All(s=> string.IsNullOrEmpty(s)) || code.All(s => string.IsNullOrWhiteSpace(s)))
            {
                return Tuple.Create(false, new char[80, 25]);
            }
            foreach (var codeLine in code)
            {
                if (codeLine.Length > 80)
                {
                    return Tuple.Create(false, new char[80, 25]);
                }

                foreach (var character in codeLine.ToCharArray())
                {
                    playField[x, y] = character;
                    x++;
                }
                y++;
                x = 0;
            }
            return Tuple.Create(true, playField);
        }

        public bool ValidateFile(string file)
        {
            if(file == null)
            {
                throw new InvalidOperationException("Directory or file was null!");
            }
            string f = $@"..\{file}";
            return File.Exists(f);
        }
    }
}