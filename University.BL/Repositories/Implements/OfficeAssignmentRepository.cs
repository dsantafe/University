using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class OfficeAssignmentRepository : GenericRepository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        private readonly UniversityContext universityContext;
        public OfficeAssignmentRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public new async Task<IEnumerable<OfficeAssignment>> GetAll()
        {
            var officeAssignments = universityContext.OfficeAssignments.Include("Instructor");

            return await officeAssignments.ToListAsync();
        }
    }
}
