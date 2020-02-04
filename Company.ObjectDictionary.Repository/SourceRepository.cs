using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Company.ObjectDictionary.Common;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.Repository.Interface;

namespace Company.ObjectDictionary.Repository
{
    public class SourceRepository : RepositoryBase<Source>, IGenericCommandRepository<Source>, IGenericQueryRepository<Source>
    {
        public SourceRepository(ICrud<Source> db) : base(db)
        {

        }

        public Source GetById(Guid id)
        {
            return (Source)db.GetById(id);
        }

        public void Create(Source m)
        {
            db.Create(m);
        }

        public IEnumerable<Source> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Source>)db.GetAll(conditions);
        }

        public void Update(Source m)
        {
            db.Update(m);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
