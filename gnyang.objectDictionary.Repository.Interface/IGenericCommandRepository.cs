using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Repository.Interface
{
    public interface IGenericCommandRepository<T> where T : EntityBase
    {
        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
    }
}