using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityContext universityContext) : base(universityContext) { }
    }
}
