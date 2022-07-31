using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter
{
    public class FileReader
    {

        Validator validator;
        public FileReader()
        {
            this.validator = new Validator();
        }

        public string[] Read(string fileName)  //Reads a bf file with the befunge code and returns a string array with the code lines in it
        {
            string file = fileName + ".bf";
            if (fileName == null)
            {
                throw new InvalidOperationException("Filename was null!");
            }

            if (!this.validator.ValidateFile(file)) //Validates File
            {
                throw new FileNotFoundException("File to be read doesn't exit!");
            }
            string[] code;
            using (StreamReader sr = new StreamReader(new FileStream(($@"..\{file}"), FileMode.Open)))
            {
                string readCode = sr.ReadToEnd().Replace("\r\n", "\n"); //Replaces "\r\n" with "\n" so the code can be splitt
                code = readCode.Split('\n');
            }
            return code;
        }
    }
}
