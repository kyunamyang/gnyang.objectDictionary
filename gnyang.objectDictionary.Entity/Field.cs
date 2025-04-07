using System;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Entity
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
