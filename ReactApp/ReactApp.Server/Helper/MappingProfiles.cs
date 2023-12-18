using API.Server.Dto;
using API.Server.Models;
using AutoMapper;

namespace API.Server.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
