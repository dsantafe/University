using AutoMapper;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();
                cfg.CreateMap<Instructor, InstructorDTO>();
                cfg.CreateMap<InstructorDTO, Instructor>();

                cfg.CreateMap<OfficeAssignment, OfficeAssignmentDTO>();
                cfg.CreateMap<OfficeAssignmentDTO, OfficeAssignment>();
            });
        }
    }
}
