using System.Collections.Generic;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Repositories
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Task<IEnumerable<Course>> GetCoursesByInstructor(int id);
    }
}
