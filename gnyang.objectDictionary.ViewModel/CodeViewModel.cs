using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.ViewModel
{
    public class CodeViewModel : CodeModelBase
    {
        public string Name { get; set; }
        public List<FieldViewModel> Fields { get; set; }
    }
}
