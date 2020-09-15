using System.Collections.Generic;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services
{
    public interface IInstructorService : IGenericService<Instructor>
    {
        Task<IEnumerable<Course>> GetCoursesByInstructor(int id);
    }
}
