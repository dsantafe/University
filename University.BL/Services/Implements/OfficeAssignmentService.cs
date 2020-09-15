using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class OfficeAssignmentService : GenericService<OfficeAssignment>, IOfficeAssignmentService
    {
        public OfficeAssignmentService(IOfficeAssignmentRepository officeAssignmentRepository) 
            : base(officeAssignmentRepository)
        {

        }
    }
}
