using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Service.Interface
{
    public interface ICodeService<T> where T : CodeModelBase
    {
        string GetClassDefinition(T t);
    }
}
