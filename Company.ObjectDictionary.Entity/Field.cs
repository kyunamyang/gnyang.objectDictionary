using System;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Entity
{
    public class Field : EntityBase
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string ModelId { get; set; }
    }
}
