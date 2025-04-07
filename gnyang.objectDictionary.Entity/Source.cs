using System;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.Entity
{
    public class Source : EntityBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string UserId { get; set; }
        public string ModelId { get; set; }
    }
}
