using AutoMapper;
using FreeCourserServices.Catalog.Dtos;
using FreeCourserServices.Catalog.Dtos.RequestDtos.Course;
using FreeCourserServices.Catalog.Model;

namespace FreeCourserServices.Catalog.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Feature,FeatureDto>().ReverseMap();
            
            CreateMap<Course,CourseCreateDto>().ReverseMap();
            CreateMap<Course,CourseUpdateDto>().ReverseMap();
        }
    }
}