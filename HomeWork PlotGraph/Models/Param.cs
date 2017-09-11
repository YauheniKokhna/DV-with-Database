using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork_PlotGraph.Models
{
    public class Param : IEqualityComparer<Param>
    {
        public int Id { get; set; }
        public double CoeffA { get; set; }
        public double CoeffB { get; set; }
        public double CoeffC { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }

        public ICollection<CacheData> CacheDatas { get; set; }

        public Param(double a, double b, double c, double step, double rangeFrom, double rangeTo)
        {
            CoeffA = a;
            CoeffB = b;
            CoeffC = c;
            Step = step;
            RangeFrom = rangeFrom;
            RangeTo = rangeTo;
        }

        public Param()
        {
        }

        //public static bool operator ==(Param p1, Param p2)
        //{
        //    return //p1.Equals(p2);
        //    (p1.CoeffA == p2.CoeffA) && (p1.CoeffB == p2.CoeffB) && (p1.CoeffC == p2.CoeffC) && (p1.Step == p2.Step) && (p1.RangeFrom == p2.RangeFrom) && (p1.RangeTo == p2.RangeTo);
        //}

        //public static bool operator !=(Param p1, Param p2)
        //{
        //    return //!p1.Equals(p2);
        //    (p1.CoeffA != p2.CoeffA) || (p1.CoeffB != p2.CoeffB) || (p1.CoeffC != p2.CoeffC) || (p1.Step != p2.Step) || (p1.RangeFrom != p2.RangeFrom) || (p1.RangeTo != p2.RangeTo);
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    Param p = obj as Param;
        //    if (p == null)
        //    {
        //        return false;
        //    }
        //    return (CoeffA == p.CoeffA) && (CoeffB == p.CoeffB) && (CoeffC == p.CoeffC) && (Step == p.Step) && (RangeFrom == p.RangeFrom) && (RangeTo == p.RangeTo);
        //}

        public bool Equals(Param p1, Param p2) // реализуем IEqualityComparer для метода Contains
        {
            if (p1 == null || p2 ==null)
            {
                return false;
            }
            return (p1.CoeffA == p2.CoeffA) && (p1.CoeffB == p2.CoeffB) && (p1.CoeffC == p2.CoeffC) && (p1.Step == p2.Step) && (p1.RangeFrom == p2.RangeFrom) && (p1.RangeTo == p2.RangeTo);
        }

        public int GetHashCode(Param p)
        {
            return (100 + (int)CoeffA+ (int)CoeffB + (int)CoeffC + (int)Step + (int)RangeFrom + (int)RangeTo);
        }
    }
}