using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BefungeInterpreter.Directions
{
    public interface IDirection
    {
        char Direction { get; }
        Tuple<int, int> GetNextPosition(int currentX, int currentY);
    }
}
