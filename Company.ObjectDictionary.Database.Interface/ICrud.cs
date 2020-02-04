using System;

namespace Company.ObjectDictionary.Database.Interface
{
    public interface ICrud<T>
    {
        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
    }
}
