using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BefungeInterpreter.Directions;

namespace BefungeInterpreter
{
    public class InterpreterDirections
    {
        public List<IDirection> BefungeDirections;
        private IDirection currentDirection;

        public IDirection CurrentDirection
        {
            get
            {
                return this.currentDirection;
            }
            set
            {
                if (value != this.currentDirection && value != null)
                {
                    this.currentDirection = value;
                }
            }
        }

        public InterpreterDirections()
        {
            this.BefungeDirections = new List<IDirection> {
                new Right(), new Left(), new Up(),  new Down(),
            };

            this.CurrentDirection = BefungeDirections[0];
        }

        public bool IsDirection(char character, InterpreterStack stack) //Checks if char is a direction
        {
            if (character == '?') //If ? then set currentDirection random direction
            {
                this.SetRandomDirection();
                return true;
            }

            if(this.IsSpecialCharacter(character, stack)) //If char is _ or | 
            {
                return true;
            }

            foreach (var direction in this.BefungeDirections)  //If char is normal direction char 
            {
                if (direction.Direction == character)
                {
                    this.CurrentDirection = direction;
                    return true;
                }
            }
            return false;
        }

        private bool IsSpecialCharacter(char character, InterpreterStack stack)
        {
            //POPs the top value of the stack, if value is zero--> direction is right else direction is left
            if (character == '_')
            {
                if (stack.Pop().ToString() == "0")
                {
                    this.CurrentDirection = this.BefungeDirections[0];//Goes to the right
                    return true;
                }
                else
                {
                    this.CurrentDirection = this.BefungeDirections[1];//Goes to the left
                    return true;
                }
            }

            //POPs the top value of the stack, if value is zero--> direction is down else direction is up
            if (character == '|')
            {
                if (stack.Pop().ToString() == "0")
                {
                    this.CurrentDirection = this.BefungeDirections[3];//Goes to the down
                    return true;
                }
                else
                {
                    this.CurrentDirection = this.BefungeDirections[2];//Goes to the up
                    return true;
                }
            }
            return false;
        }
        private void SetRandomDirection()
        {
            Random random = new Random();

            switch (random.Next(1, 5))
            {
                case 1:
                    this.CurrentDirection = this.BefungeDirections[0];
                    break;
                case 2:
                    this.CurrentDirection = this.BefungeDirections[1];
                    break;
                case 3:
                    this.CurrentDirection = this.BefungeDirections[2];
                    break;
                case 4:
                    this.CurrentDirection = this.BefungeDirections[3];
                    break;
                default:
                    throw new Exception();
            }
        }

        public Tuple<int, int> GetNextPosition(int currentX, int currentY)
        {
            return this.CurrentDirection.GetNextPosition(currentX, currentY);
        }
    }
}
