using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        private UniversityContext _universityContext;

        public UniversityContext UniversityContext
        {
            get
            {
                return _universityContext ?? HttpContext.GetOwinContext().Get<UniversityContext>();
            }
            private set
            {
                _universityContext = value;
            }
        }

        private IMapper mapper;

        public OfficeAssignmentsController()
        {
            this.mapper = MvcApplication.MapperConfiguration.CreateMapper();
        }

        // GET: OfficeAssignments
        public async Task<ActionResult> Index()
        {
            var officeAssignmentService = new OfficeAssignmentService(new OfficeAssignmentRepository(UniversityContext));

            var officeAssignments = await officeAssignmentService.GetAll();
            var officeAssignmentsDTO = officeAssignments.Select(x => mapper.Map<OfficeAssignmentDTO>(x));

            return View(officeAssignmentsDTO);
        }

        public async Task<ActionResult> Create()
        {
            var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
            var instructors = await instructorService.GetAll();
            var instructorsDTO = instructors.Select(x => mapper.Map<InstructorDTO>(x));

            ViewData["Instructors"] = new SelectList(instructorsDTO, "ID", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OfficeAssignmentDTO officeAssignmentDTO)
        {
            var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
            var instructors = await instructorService.GetAll();
            var instructorsDTO = instructors.Select(x => mapper.Map<InstructorDTO>(x));

            ViewData["Instructors"] = new SelectList(instructorsDTO, "ID", "FullName", officeAssignmentDTO.InstructorID);

            if (ModelState.IsValid)
            {
                var officeAssignmentService = new OfficeAssignmentService(new OfficeAssignmentRepository(UniversityContext));
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);
                officeAssignment = await officeAssignmentService.Insert(officeAssignment);

                return RedirectToAction("Index", "OfficeAssignments");
            }

            return View(officeAssignmentDTO);
        }
    }
}