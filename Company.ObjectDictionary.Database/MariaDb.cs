using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using Company.ObjectDictionary.Common;

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
                string and = GetWhereCondition(conditions);

                if(!string.IsNullOrEmpty(and))
                {
                    sql = sql + " WHERE " + and;
                }

                return db.Query<T>(sql);
            }
        }

        public void Create(T t)
        {
            var sql = GenerateInsertQuery();

            using (var db = new MySqlConnection(connectionString))
            {
                t.Created = DateTime.Now;

                db.Execute(sql, t);
            }
        }

        public void Update(T t)
        {
            var sql = GenerateUpdateQuery();

            using (var db = new MySqlConnection(connectionString))
            {
                t.Modified = DateTime.Now;

                db.Execute(sql, t);
            }
        }

        public void Delete(Guid id)
        {
            using (var db = new MySqlConnection(connectionString))
            {
                // 실제 삭제하지 않음
                ////var sql = string.Format("DELETE FROM @TableName WHERE Id = @Id");
                ////db.Execute(sql, new { TableName = tableName, Id = id });
                // 삭제 플래그 처리
                var sql = string.Format("UPDATE {0} SET IsDeleted = true, Modified = @Modified WHERE Id = @Id", tableName);

                db.Execute(sql, new { Modified = DateTime.Now, Id = id.ToString() });
            }
        }

        private string GetWhereCondition(IDictionary<string, string> conditions)
        {
            string result = string.Empty;

            if(conditions.Count == 0)
            {
                return result;
            }
            //var pair = conditions.Select((key, val) => string.Format("{0} = {1}", key, val)).ToList();
            //result = string.Join(" AND ", pair);
            string and = string.Empty;
            foreach( KeyValuePair<string, string> pair in conditions)
            {
                if (Int32.TryParse(pair.Value, out int temp))
                {
                    and = string.Format(" {0} = {1} AND", pair.Key, pair.Value);
                }
                else
                {
                    and = string.Format(" {0} = '{1}' AND", pair.Key, pair.Value);
                }
            }

            and = and.TrimEnd("AND".ToCharArray());

            return result + and;
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties, "ignoreInsert");
            properties.ForEach(prop => { insertQuery.Append($"{prop},"); });

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
            var properties = GenerateListOfProperties(GetProperties, "ignoreUpdate");

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

        private List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties, string ignoreDescription)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != ignoreDescription
                    select prop.Name).ToList();
        }
    }
}
