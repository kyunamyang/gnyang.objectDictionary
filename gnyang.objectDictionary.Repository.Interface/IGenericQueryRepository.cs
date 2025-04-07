using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Repository.Interface
{
    public interface IGenericQueryRepository<T> where T : EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(IDictionary<string, string> conditions);
    }
}