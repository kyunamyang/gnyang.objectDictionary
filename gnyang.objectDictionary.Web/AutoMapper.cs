using AutoMapper;
using gnyang.objectDictionary.Entity;
using gnyang.objectDictionary.ViewModel;

namespace gnyang.objectDictionary.Web
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
            CreateMap<Field, FieldViewModel>().ReverseMap();
            CreateMap<Source, SourceViewModel>().ReverseMap();

            //CreateMap<ModelViewModel, CodeViewModel>().ReverseMap();
        }
    }
}
