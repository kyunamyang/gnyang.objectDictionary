using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using gnyang.objectDictionary.Common;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.Repository.Interface;

namespace gnyang.objectDictionary.Repository
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

        public IEnumerable<Source> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Source>)db.GetAll(conditions);
        }

        public void Create(Source s)
        {
            db.Create(s);
        }

        public void Update(Source s)
        {
            db.Update(s);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
