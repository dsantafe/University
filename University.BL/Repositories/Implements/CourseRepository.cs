using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;
using System.Linq;
using System.Data.Entity;

namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly UniversityContext universityContext;
        public CourseRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.CourseInstructors.Where(x => x.CourseID == id).AnyAsync();
            return flag;
        }
    }
}
