using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhkWrapper.AHKFunctions
{
    public struct Point
    {
        public static Point Min = new Point(0, 0);
        public static Point Max = new Point(1000, 650);
        public static Point Error = new Point(-1, -1);

        public int X, Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
