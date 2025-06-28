using AutoMapper;
using ProgrammingClub.Models.CreateOrUpdateModels;
using ProgrammingClub.Models;

namespace ProgrammingClub
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap < Member, UpdateMemberPartially>().ReverseMap();  
            
        }
    }
}
