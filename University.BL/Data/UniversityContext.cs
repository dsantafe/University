using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityContext : IdentityDbContext<ApplicationUser>
    {
        public UniversityContext() : base("UniversityContext")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }

        public static UniversityContext Create()
        {
            return new UniversityContext();
        }
    }
}
