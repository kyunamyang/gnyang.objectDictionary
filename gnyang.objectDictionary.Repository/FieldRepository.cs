using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using gnyang.objectDictionary.Common;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.Repository.Interface;

namespace gnyang.objectDictionary.Repository
{
    public class FieldRepository : RepositoryBase<Field>, IGenericCommandRepository<Field>, IGenericQueryRepository<Field>
    {
        public FieldRepository(ICrud<Field> db) : base(db)
        {

        }

        public Field GetById(Guid id)
        {
            return (Field)db.GetById(id);
        }

        public IEnumerable<Field> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Field>)db.GetAll(conditions);
        }

        public void Create(Field f)
        {
            db.Create(f);
        }

        public void Update(Field f)
        {
            db.Update(f);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
