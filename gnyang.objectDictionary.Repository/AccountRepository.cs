using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using gnyang.objectDictionary.Common;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.Repository.Interface;

namespace gnyang.objectDictionary.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IGenericCommandRepository<Account>, IGenericQueryRepository<Account>
    {
        public AccountRepository(ICrud<Account> db) : base(db)
        {

        }

        public Account GetById(Guid id)
        {
            return (Account)db.GetById(id);
        }

        public IEnumerable<Account> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Account>)db.GetAll(conditions);
        }

        public void Create(Account a)
        {
            db.Create(a);
        }

        public void Update(Account a)
        {
            db.Update(a);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
