using System;
using Company.ObjectDictionary.Common;

namespace Company.ObjectDictionary.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AccountViewModel Account { get; set; }
    }
}
