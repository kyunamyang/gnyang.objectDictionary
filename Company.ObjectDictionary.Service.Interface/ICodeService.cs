using System;
using System.Collections.Generic;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Service.Interface
{
    public interface ICodeService<T> where T : CodeModelBase
    {
        string GetClassDefinition(T t);
    }
}
