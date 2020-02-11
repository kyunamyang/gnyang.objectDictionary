using System;
using System.Collections.Generic;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.ViewModel
{
    public class CodeViewModel : CodeModelBase
    {
        public string Name { get; set; }
        public List<FieldViewModel> Fields { get; set; }
    }
}
