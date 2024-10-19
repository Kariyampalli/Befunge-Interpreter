using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BefungeInterpreter;

namespace ValidatorTest
{
    [TestClass]
    public class Test
    {
        private Validator validator;
        public Test()
        {
            this.validator = new Validator();
        }

        [TestMethod]
        public void TestValidateIntegerInput()
        {
            Tuple<bool, int, string> t;

            t = this.validator.ValidateIntegerInput(1);
            Assert.IsTrue(t.Item1 == true && t.Item2 == 1 && t.Item3 == "Input is right");

            t = this.validator.ValidateIntegerInput(null);
            Assert.IsTrue(t.Item1 == false && t.Item2 == -1 && t.Item3 == "Input is wrong");

            t = this.validator.ValidateIntegerInput(" ");
            Assert.IsTrue(t.Item1 == false && t.Item2 == -1 && t.Item3 == "Input is wrong");

            t = this.validator.ValidateIntegerInput(string.Empty);
            Assert.IsTrue(t.Item1 == false && t.Item2 == -1 && t.Item3 == "Input is wrong");

            t = this.validator.ValidateIntegerInput("abc");
            Assert.IsTrue(t.Item1 == false && t.Item2 == -1 && t.Item3 == "Input is wrong");
        }

        [TestMethod]
        public void TestValidateCharcterInput()
        {
            Tuple<bool, char, string> t;

            t = this.validator.ValidateCharcterInput(1);
            Assert.IsTrue(t.Item1 == true && t.Item2 == '1' && t.Item3 == "Input is a character");

            t = this.validator.ValidateCharcterInput("A");
            Assert.IsTrue(t.Item1 == true && t.Item2 == 'A' && t.Item3 == "Input is a character");

            t = this.validator.ValidateCharcterInput(123);
            Assert.IsTrue(t.Item1 == false && t.Item2 == ' ' && t.Item3 == "Input isn't a character");

            t = this.validator.ValidateCharcterInput("abc");
            Assert.IsTrue(t.Item1 == false && t.Item2 == ' ' && t.Item3 == "Input isn't a character");

            t = this.validator.ValidateCharcterInput(null);
            Assert.IsTrue(t.Item1 == false && t.Item2 == ' ' && t.Item3 == "Input isn't a character");

            t = this.validator.ValidateCharcterInput("  ");
            Assert.IsTrue(t.Item1 == false && t.Item2 == ' ' && t.Item3 == "Input isn't a character");

            t = this.validator.ValidateCharcterInput(string.Empty);
            Assert.IsTrue(t.Item1 == false && t.Item2 == ' ' && t.Item3 == "Input isn't a character");
        }

        [TestMethod]
        public void TestValidateEndOfProgram()
        {
            try
            {
                this.validator.ValidateEndOfProgram("123");
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Please enter a valid character!");
            }

            try
            {
                this.validator.ValidateEndOfProgram("abcs");
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Please enter a valid character!");
            }

            try
            {
              this.validator.ValidateEndOfProgram(null);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "input received a null value!");
            }
            Assert.IsTrue(this.validator.ValidateEndOfProgram("y"));
            Assert.IsFalse(this.validator.ValidateEndOfProgram("n"));
        }

        [TestMethod]
        public void TestValidateBefungeCode()
        {
            string[] code = new string[26];
            Assert.IsFalse(this.validator.ValidateBefungeCode(code).Item1);

            Assert.IsFalse(this.validator.ValidateBefungeCode(null).Item1);

            Tuple<bool, char[,]> t;
            t = this.validator.ValidateBefungeCode(new string[] {"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"});
            Assert.IsFalse(t.Item1);


            t = this.validator.ValidateBefungeCode(new string[] {"12","34"});
            Assert.IsTrue(t.Item1 && t.Item2[0,0] == '1' && t.Item2[1, 0] == '2' && t.Item2[0, 1] == '3' && t.Item2[1, 1] == '4');
        }

        [TestMethod]
        public void TestValidateFile()
        {
            try
            {
                this.validator.ValidateFile(@".\..\", "test.bf");
            }
            catch(InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Directory or file was null!");
            }

            try
            {
                this.validator.ValidateFile(null,null);
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message == "Directory or file was null!");
            }
        }
    }
}
