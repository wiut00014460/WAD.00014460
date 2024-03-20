using static System.Runtime.InteropServices.JavaScript.JSType;
using WAD._00014460.DTOs;
using WAD._00014460.Models;
using AutoMapper;

namespace WAD._00014460.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();

        }
    }
}
