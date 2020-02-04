using AutoMapper;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.ViewModel;

namespace Company.ObjectDictionary.Web
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<Model, ModelViewModel>();
            CreateMap<Field, FieldViewModel>();
        }
    }
}
