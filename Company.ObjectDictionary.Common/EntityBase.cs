using System;
using System.Collections.Generic;
using System.Text;

namespace Company.ObjectDictionary.Common
{
    public class EntityBase
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
