using System;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.Entity
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
    }
}
