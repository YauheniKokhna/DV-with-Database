using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork_PlotGraph.Models
{
    public class CacheData
    {
        public int CacheDataId { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }

        public int ParamId { get; set; }
        public Param Parameter { get; set; }

        public CacheData(double x, double y, int paramId)
        {
            CoordX = x;
            CoordY = y;
            ParamId = paramId;
        }
        public CacheData() // нужен для LINQ - когда делает выборку CacheData - создает экземпляры с использованием конструктора по умолчанию, затем присваивает значения свойствам(скорее всего)
        {
        }

        
    }
}