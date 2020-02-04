using System;
using System.Collections.Generic;

namespace Company.ObjectDictionary.Common
{
    public interface ICrud<T> where T : EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(IDictionary<string, string> conditions);

        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
    }
}
