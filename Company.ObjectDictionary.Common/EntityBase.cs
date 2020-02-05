using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Company.ObjectDictionary.Common
{
    public class EntityBase
    {
        public string Id { get; set; }

        [Description("ignoreUpdate")]
        public DateTime Created { get; set; }

        [Description("ignoreInsert")]
        public DateTime Modified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
