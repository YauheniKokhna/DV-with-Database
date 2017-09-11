using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork_PlotGraph.Models
{
    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.X==p2.X) && (p1.Y==p2.Y);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.X != p2.X) || (p1.Y != p2.Y);
        }

        //public static implicit operator Point(CacheData cacheData)
        //{
        //    return new Point(cacheData.CoordX, cacheData.CoordY);
        //}
    }
}