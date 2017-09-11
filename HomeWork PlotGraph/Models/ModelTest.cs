using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft..VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Reflection;
using HomeWork_PlotGraph.Controllers;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace HomeWork_PlotGraph.Models
{
    class Programm
    {
        static void Main()
        {
        }

        [TestFixture]
        public class ModelTest
        {
            [Test]
            public static void IsGetFormDbOfCalculateTest()
            {

                Param testParam = new Param { CoeffA = 10, CoeffB = 10, CoeffC = 10, Step = 1, RangeFrom = -5, RangeTo = 5, Id = 100 }; //при данных коэффициентах при расчете получаем 11 точек
                CacheData testCacheData = new CacheData { CoordX = 10, CoordY = 10, CacheDataId = 100, ParamId = 100 };
                Point pointTest = new Point(testCacheData.CoordX, testCacheData.CoordY);

                List<string> paramListTest = new List<string>();
                paramListTest.Add(testParam.CoeffA.ToString());
                paramListTest.Add(testParam.CoeffB.ToString());
                paramListTest.Add(testParam.CoeffC.ToString());
                paramListTest.Add(testParam.Step.ToString());
                paramListTest.Add(testParam.RangeFrom.ToString());
                paramListTest.Add(testParam.RangeTo.ToString());

                HomeController contr = new HomeController();

                CacheDataContext db = CacheDataContext.GetCacheDataContext();

                using (db)
                {
                    db.Params.Add(testParam);
                    db.CacheDatas.Add(testCacheData); 
                    db.SaveChanges();

                    var jsonResultReturned = contr.Compute(paramListTest);
                    var jsonResultString = new JavaScriptSerializer().Serialize(jsonResultReturned);
                    var xxx = JsonConvert.DeserializeObject<Point>(jsonResultString);

                    List<Point> pointListTest = new List<Point>();

                    pointListTest.Add(xxx);

                    Assert.Contains(pointTest, pointListTest);


            }

            }
        }
    }
}