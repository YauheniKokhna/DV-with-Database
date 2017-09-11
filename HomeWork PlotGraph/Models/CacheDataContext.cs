using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeWork_PlotGraph.Models
{
    public class CacheDataContext : DbContext
    {
        static CacheDataContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CacheDataContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CacheDataContext>());
        }

        public CacheDataContext() : base("DbConnection")
        {
        }

        public DbSet<CacheData> CacheDatas { get; set; }
        public DbSet<Param> Params { get; set; }

        private static CacheDataContext db = null; //SINGLETON

        public static CacheDataContext GetCacheDataContext()
        {
            if (db == null)
            {
                db = new CacheDataContext();
            }

            return db;
        }
    }
}