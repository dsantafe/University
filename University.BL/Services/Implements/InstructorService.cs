using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class InstructorService : GenericService<Instructor>, IInstructorService
    {
        public InstructorService(IInstructorRepository instructorRepository) : base(instructorRepository)
        {

        }
    }
}
