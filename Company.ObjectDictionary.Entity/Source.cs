using System;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Entity
{
    public class Source : EntityBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string UserId { get; set; }
    }
}
