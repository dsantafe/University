using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University.BL.Data;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class InstructorsController : Controller
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

        // GET: Instructors
        public async Task<ActionResult> Index()
        {
            var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
            return View(await instructorService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
                instructor = await instructorService.Insert(instructor);

                return RedirectToAction("Index", "Instructors");
            }

            return View(instructor);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
            var instructor = await instructorService.GetById(id.Value);

            return View(instructor);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
                instructor = await instructorService.Update(instructor);

                return RedirectToAction("Index", "Instructors");
            }

            return View(instructor);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
            await instructorService.Delete(id.Value);
            return RedirectToAction("Index", "Instructors");
        }

        public async Task<ActionResult> Details(int? id)
        {
            var instructorService = new InstructorService(new InstructorRepository(UniversityContext));
            var instructor = await instructorService.GetById(id.Value);

            return View(instructor);
        }
    }
}