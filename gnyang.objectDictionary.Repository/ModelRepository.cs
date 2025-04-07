using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using gnyang.objectDictionary.Common;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.Repository.Interface;

namespace gnyang.objectDictionary.Repository
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

        public IEnumerable<Model> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Model>)db.GetAll(conditions);
        }

        public void Create(Model m)
        {
            db.Create(m);
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
