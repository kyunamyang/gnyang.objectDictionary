using System;
using System.Collections.Generic;
using System.Text;

namespace gnyang.objectDictionary.Common
{
    public class ViewModelBase
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
