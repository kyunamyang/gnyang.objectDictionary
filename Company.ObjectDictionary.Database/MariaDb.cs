using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using Company.ObjectDictionary.Common;
using System.Text;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace Company.ObjectDictionary.Database
{
    public class MariaDb<T> : ICrud<T> where T : EntityBase
    {
        protected readonly IConfiguration config;
        protected string connectionString;
        private string tableName;

        //public MariaDb()
        //{
        //    connectionString = string.Empty;
        //}

        //public MariaDb(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}

        public MariaDb(IConfiguration config)
        {
            string databaseKey = config.GetValue<string>("Database");
            this.connectionString = config.GetValue<string>("ConnectionStrings:" + databaseKey);
            
            tableName = typeof(T).Name;
        }

        public T GetById(Guid id)
        {
            using(var db = new MySqlConnection(connectionString))
            {
                var sql = string.Format("SELECT * FROM {0} WHERE Id = @Id", tableName);
                
                return db.QueryFirstOrDefault<T>(sql, new { Id = id.ToString() });
            }
        }

        public IEnumerable<T> GetAll(IDictionary<string, string> conditions)
        {
            using (var db = new MySqlConnection(connectionString))
            {
                var sql = string.Format("SELECT * FROM {0}", tableName); // 파라미터 값 추가해야

                return db.Query<T>(sql);
            }
        }

        public void Create(T t)
        {
            var sql = GenerateInsertQuery();

            using (var db = new MySqlConnection(connectionString))
            {
                db.Execute(sql);
            }
        }

        public void Update(T t)
        {
            var sql = GenerateUpdateQuery();

            using (var db = new MySqlConnection(connectionString))
            {
                db.Execute(sql);
            }
        }

        public void Delete(Guid id)
        {
            using (var db = new MySqlConnection(connectionString))
            {
                var sql = string.Format("DELETE FROM @TableName WHERE Id = @Id", new { TableName = tableName, Id = id });

                db.Execute(sql);
            }
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
    }
}
