using AutoMapper;
using Q10.StudentManagement.Student.Application.Dtos;
namespace Q10.StudentManagement.Student.Infrastructure.Mapping
{
    public class StudentMapping : Profile
    {
        public StudentMapping() 
        {
            CreateMap<Domain.Entities.Student, StudentDto>().ReverseMap();
        }
    }
}
