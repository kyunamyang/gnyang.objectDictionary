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
        public ModelRepository(ICrud<Model> db) : base(db)
        {

        }

        public Model GetById(Guid id)
        {
            return (Model)db.GetById(id);
        }

        public void Create(Model m)
        {
            db.Create(m);
        }

        public IEnumerable<Model> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Model>)db.GetAll(conditions);
        }

        public void Update(Model m)
        {
            db.Update(m);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
