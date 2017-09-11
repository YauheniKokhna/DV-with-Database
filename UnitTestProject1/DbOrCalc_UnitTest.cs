using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork_PlotGraph.Controllers;
using HomeWork_PlotGraph.Models;
using System.Collections.Generic;
using System.Data.Entity;
//using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class DbOrCalc_UnitTest
    {
        [TestMethod]
        public void IsGetFromDbOrCalculate()
        {

            Param testParam = new Param { CoeffA = 10, CoeffB = 10, CoeffC = 10, Step = 1, RangeFrom = -5, RangeTo = 5 }; //при данных коэффициентах при расчете получаем 11 точек, в базу забрасываем только одну (см. ниже)
            CacheData testCacheData = new CacheData { CoordX = 10, CoordY = 10 };// CacheDataId = 100 }; //одна точка
            //Point pointTest = new Point(testCacheData.CoordX, testCacheData.CoordY);

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
                db.Params.Add(testParam); // забрасываем в базу тестовые параметры
                db.CacheDatas.Add(testCacheData); // забрасываем ОДНУ точку
                db.SaveChanges();

                JsonResult jsonResultReturned = contr.Compute(paramListTest); // вызываем проверяемый метод - в базе эти параметры уже есть - если он работает неверно и станет их рассчитывать, то он вернет нам 11 точек
                List<Point> jsonResultToList = (List<Point>)jsonResultReturned.Data;
                //var jsonResultString = new JavaScriptSerializer().Serialize(jsonResultReturned.Data);
                //var xxx = new JavaScriptSerializer().Deserialize()
                //var xxx = JsonConvert.DeserializeObject<Point>(jsonResultString);

                Assert.IsTrue(jsonResultToList.Count == 1); //проверяем - одна ли точка

                //pointListTest.Add(new Point(jsonResult.X, jsonResult.Y));

                //bool isExists = pointListTest.Exists(c => c == pointTest);
                //Assert.IsTrue((isExists);
            }
        }

        [TestMethod]
        public void IsSingleton()
        {
            var A = CacheDataContext.GetCacheDataContext();
            var B = CacheDataContext.GetCacheDataContext();
            Assert.AreSame(A, B);
        }
    }
}
