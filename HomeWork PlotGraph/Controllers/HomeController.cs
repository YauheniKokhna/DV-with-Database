using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork_PlotGraph.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace HomeWork_PlotGraph.Controllers
{
    public class HomeController : Controller
    {
        static HomeController()
        {


        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Compute(List<string> param)
        {
            CacheDataContext db = CacheDataContext.GetCacheDataContext();
            ValidationClass vc = new ValidationClass(param);

            using (db)
            {
                List<Point> pointList = new List<Point>();

                //double a = Double.Parse(param[0]);
                //double b = Double.Parse(param[1]);
                //double c = Double.Parse(param[2]);
                //double step = Double.Parse(param[3]);
                //double rangeFrom = Double.Parse(param[4]);
                //double rangeTo = Double.Parse(param[5]);

                Param p1 = new Param(vc.A, vc.B, vc.C, vc.Step, vc.RangeFrom, vc.RangeTo);
                int requeredId=0;

                if (!db.Params.AsEnumerable().Contains(p1, new Param())) // 1. AsEnumerable() - костыль, есть возможность решить появляющееся исключение (без AsEnumerable) с помощью файла .edmx - написать там метод (пример в интернете). 2. new Param() - объект-компаратор
                {
                    db.Params.Add(p1);

                    double y;
                    for (double x = vc.RangeFrom; x <= vc.RangeTo; x += vc.Step)
                    {
                        y = vc.A * x * x + vc.B * x + vc.C;
                        db.CacheDatas.Add(new CacheData(x, y, p1.Id));
                    }
               
                    db.SaveChanges();
                }

                //    var newP = db.Params.SqlQuery("select * from dbo.Params where CoeffA=@par1 and CoeffB=@par2 and CoeffC=@par3 and Step=@par4 and RangeFrom=)

                //var qqq = db.Params.Where(o => p1.Equals(o,p1)).Select(x => x.Id);

                var queryForFindId = db.Params.Where(o => o.CoeffA == p1.CoeffA).Where(o => o.CoeffB == p1.CoeffB).Where(o => o.CoeffC == p1.CoeffC).Where(o => o.Step == p1.Step).Where(o => o.RangeFrom == p1.RangeFrom).Where(o => o.RangeTo == p1.RangeTo).Select(o=>o.Id); //написал длинно, т.к. не разобрался сто нужно определить в классе Param чтобы работало сравнение на равенство Where(cd => cd == p1)

                //var qqq = db.Params.Where(o => Equals(o, p1));

                //var qqq = db.Params.SqlQuery("select * from dbo.Params where CoeffA=@par1 and CoeffB=@par2 and CoeffC=@par3 and Step=@par4 and RangeFrom=@par5 and RangeTo=@par6", new SqlParameter(("@par1", p1.CoeffA), new SqlParameter("@par2", p1.CoeffB), new SqlParameter("@par3", p1.CoeffC), new SqlParameter("@par4", p1.Step), new SqlParameter("@par5", p1.RangeFrom), new SqlParameter("@par6", p1.RangeTo));

                foreach (var item in queryForFindId)
                {
                    requeredId = item;//.First();//.Id;
                }

                var mmm = db.CacheDatas.Where(cd => cd.ParamId == requeredId);//.ToList();
                foreach (var item in mmm)
                {
                    pointList.Add(new Point(item.CoordX, item.CoordY));
                }

                return Json(pointList, JsonRequestBehavior.AllowGet);
            }
        }
    }
}