using AutoMapper;
using SimpleLogin.Domain.Entities;
using SimpleLoginViewModels;


namespace SimpleLogin.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserProfileViewModel, UserProfile>();
        }

    }    
}