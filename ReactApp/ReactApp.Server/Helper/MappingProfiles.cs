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
            CreateMap<StudentDto, Student>();

            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();

            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();

            CreateMap<TheoryExam, TheoryExamDto>();
            CreateMap<TheoryExamDto, TheoryExam>();

            CreateMap<PracticalExam, PracticalExamDto>();
            CreateMap<PracticalExamDto, PracticalExam>();

            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }
    }
}
