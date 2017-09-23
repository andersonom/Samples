using AutoMapper;
using SimpleLogin.Domain.Entities;
using SimpleLoginViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap< UserProfile,UserProfileViewModel > ();
        }

    }
}