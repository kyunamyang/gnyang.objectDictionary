using System;
using System.Collections.Generic;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.ViewModel
{
    public class SourceViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public UserViewModel User { get; set; }
        public ModelViewModel Model { get; set; }
    }
}