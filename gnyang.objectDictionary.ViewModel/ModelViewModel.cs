using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.ViewModel
{
    public class ModelViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UserViewModel User { get; set; }
        public List<FieldViewModel> Fields { get; set; }
        public List<SourceViewModel> Sources { get; set; }
        public CodeViewModel Code { get; set; }
    }
}
