using System;
using System.Collections.Generic;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.ViewModel
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
