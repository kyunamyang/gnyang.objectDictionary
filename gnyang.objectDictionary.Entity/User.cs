using System;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Entity
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
    }
}
