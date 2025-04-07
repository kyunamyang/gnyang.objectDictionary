using System;
using gnyang.objectDictionary.Common;

namespace gnyang.objectDictionary.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AccountViewModel Account { get; set; }
    }
}
