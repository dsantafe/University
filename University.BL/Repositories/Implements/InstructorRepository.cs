using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(UniversityContext universityContext) : base(universityContext)
        {

        }
    }
}
