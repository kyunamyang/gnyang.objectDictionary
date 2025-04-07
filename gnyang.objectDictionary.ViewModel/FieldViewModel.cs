using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.ViewModel
{
    public class FieldViewModel : ViewModelBase
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserViewModel User { get; set; }
        public ModelViewModel Model { get; set; }
    }
}
