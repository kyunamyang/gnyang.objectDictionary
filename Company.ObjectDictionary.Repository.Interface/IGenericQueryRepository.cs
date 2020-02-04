using System;
using System.Collections.Generic;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Repository.Interface
{
    public interface IGenericQueryRepository<T> where T : EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(IDictionary<string, string> conditions);
    }
}