using System.Collections.Generic;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class InstructorService : GenericService<Instructor>, IInstructorService
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository) : base(instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructor(int id)
        {
            return await instructorRepository.GetCoursesByInstructor(id);
        }
    }
}
