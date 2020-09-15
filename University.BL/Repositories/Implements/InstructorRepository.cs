using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly UniversityContext universityContext;

        public InstructorRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructor(int id)
        {
            //var courses = universityContext.CourseInstructors
            //                    .Include("Course")
            //                    .Where(x => x.InstructorID == id)
            //                    .Select(x => x.Course);

            var courses = (from courseInstructors in universityContext.CourseInstructors
                           join course in universityContext.Courses on courseInstructors.CourseID
                           equals course.CourseID
                           where courseInstructors.InstructorID == id
                           select course);

            return await courses.ToListAsync();
        }
    }
}
