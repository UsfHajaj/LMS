using AutoMapper;
using LMS.DTOs;
using LMS.Models.Auth;
using LMS.Models.Courses;
using LMS.Models.Interaction;
using LMS.Models.Social;

namespace LMS.Extensions
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FirstName + " " + src.Instructor.LastName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();

            CreateMap<StudentRegisterDto, Student>()
                .IncludeBase<RegisterModelDto,AppUser>();
            CreateMap<InstructorRegisterDto, Instructor>()
                .IncludeBase<RegisterModelDto, AppUser>();

            CreateMap<RegisterModelDto,AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));


            CreateMap<EnrollmentDto, Enrollment>();
            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FirstName + " " + src.Student.LastName))
                .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));
            CreateMap<Enrollment, UpdateEnrollmentDto>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(dest => dest.ProgressPercentage, opt => opt.MapFrom(src => src.ProgressPercentage));
            CreateMap<UpdateEnrollmentDto, Enrollment>();

            CreateMap<commentDto, Comment>();
            CreateMap<Comment, commentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName ));

            CreateMap<EditCommentDto, Comment>();
            CreateMap<Comment, EditCommentDto>();

            CreateMap<DiscussionDto, Discussion>();
            CreateMap<Discussion, DiscussionDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName ))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Title));

            CreateMap<EditDiscussionDto, Discussion>();
            CreateMap<Discussion, EditDiscussionDto>();
        }
    }
}
