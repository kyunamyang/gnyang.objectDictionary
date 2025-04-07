using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using gnyang.objectDictionary.Common;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.Repository.Interface;

namespace gnyang.objectDictionary.Repository
{
    public class UserRepository : RepositoryBase<User>, IGenericCommandRepository<User>, IGenericQueryRepository<User>
    {
        public UserRepository(ICrud<User> db) : base(db)
        {

        }

        public User GetById(Guid id)
        {
            return (User)db.GetById(id);
        }

        public void Create(User u)
        {
            db.Create(u);
        }

        public IEnumerable<User> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<User>)db.GetAll(conditions);
        }

        public void Update(User u)
        {
            db.Update(u);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
