using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Service.Interface
{
    public interface IGenericService<T> where T : ViewModelBase
    {
        void Create(T t);
        T GetById(Guid id);
        IEnumerable<T> GetAll(IDictionary<string, string> conditions);
        void Update(T t);
        void Delete(Guid id);
    }
}
