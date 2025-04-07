using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace gnyang.objectDictionary.Common
{
    public class RepositoryBase<T> where T : EntityBase
    {
        //protected readonly IConfiguration config;
        protected readonly ICrud<T> db;

        ////public RepositoryBase()
        ////{
        ////}

        public RepositoryBase(/*IConfiguration config,*/ ICrud<T> db)
        {
            //this.config = config;
            this.db = db;
        }

        //protected string GetConnectionString()
        //{
        //    string databaseKey = config.GetValue<string>("Database");

        //    return config.GetValue<string>("ConnectionStrings:" + databaseKey);
        //}
    }
}
