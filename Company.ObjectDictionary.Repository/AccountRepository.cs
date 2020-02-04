using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Company.ObjectDictionary.Common;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.Repository.Interface;

namespace Company.ObjectDictionary.Repository
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

        public void Create(Account m)
        {
            db.Create(m);
        }

        public IEnumerable<Account> GetAll(IDictionary<string, string> conditions)
        {
            return (IEnumerable<Account>)db.GetAll(conditions);
        }

        public void Update(Account m)
        {
            db.Update(m);
        }

        public void Delete(Guid id)
        {
            db.Delete(id);
        }
    }
}
