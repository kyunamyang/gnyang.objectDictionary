using System;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Entity
{
    public class Model : EntityBase
    {
        public string Name { get; set; }
        public string StartChar { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

    }
}
