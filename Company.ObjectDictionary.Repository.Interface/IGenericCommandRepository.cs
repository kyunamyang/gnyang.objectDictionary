using System;
using System.Collections.Generic;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Repository.Interface
{
    public interface IGenericCommandRepository<T> where T : EntityBase
    {
        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
    }
}