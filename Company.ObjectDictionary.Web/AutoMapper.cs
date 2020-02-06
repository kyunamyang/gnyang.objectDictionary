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
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
            CreateMap<Field, FieldViewModel>().ReverseMap();
        }
    }
}
