using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Directions
{
    public class Up : IDirection
    {
        public char Direction
        {
            get
            {
                return '^';
            }
        }
        public Tuple<int, int> GetNextPosition(int currentX, int currentY)
        {
            if (currentX > 80 || currentX < 0 || currentY > 25 || currentY < 0)
            {
                throw new InvalidOperationException("coordinates were invalid during moving");
            }

            if (currentY == 0)
            {
                currentY = 24;
            }
            else
            {
                currentY--;
            }
            return Tuple.Create(currentX, currentY);
        }
    }
}
