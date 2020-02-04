using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Company.ObjectDictionary.Common;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.Repository.Interface;

namespace Company.ObjectDictionary.Repository
{
    public class ModelRepository : RepositoryBase<Model>, IGenericCommandRepository<Model>, IGenericQueryRepository<Model>
    {
        //public EntityRepository()
        //{
        //}

        //public EntityRepository(IConfiguration config, ICrud<Model> db) : base(config, db)
        //{

        //}
        public ModelRepository(ICrud<Model> db) : base(db)
        {

        }

        public Model GetById(Guid id)
        {
            return (Model)db.GetById(id);
        }

        public void Create(Model e)
        {
            db.Create(e);
        }

        public IEnumerable<Model> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Model>)db.GetAll(conditions);
        }

        public void Update(Model e)
        {
            db.Update(e);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
