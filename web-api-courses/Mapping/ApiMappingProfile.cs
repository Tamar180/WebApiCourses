using AutoMapper;
using web_api_courses.Entities;
using web_api_courses.Models;

namespace web_api_courses.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CoursePostModel, Course>();
            CreateMap<LecturePostModel ,Lecture>();
            CreateMap<PupilPostModel, Pupil>();
        }
    }
}
