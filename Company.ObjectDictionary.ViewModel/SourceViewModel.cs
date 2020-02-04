using System;
using System.Collections.Generic;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.ViewModel
{
    public class SourceViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public UserViewModel User { get; set; }
    }
}