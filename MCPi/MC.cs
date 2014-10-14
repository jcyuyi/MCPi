using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCPi
{
    class MC
    {
        public List<Point> pointList = null;
        public long times = 1000;
        public double calculate()
        {
            long count = 0;//point in circle
            pointList = new List<Point>();
            for (long i = 0; i < times; i++)
            {
                //generate a point in (-1,-1) - (1,1)
                Point p = new Point(MCRandom.getRandomNumber(-1, 1), MCRandom.getRandomNumber(-1, 1));
                double dis2 = p.x * p.x + p.y * p.y;
                if (dis2 <= 1)
                {
                    count++;
                }
                pointList.Add(p);
            }
            return (Double)count * 4 / times;
        }
    }
    class Point
    {
        public double x;
        public double y;
        public Point(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
    }
}
