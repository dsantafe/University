using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University.BL.Data;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class CoursesController : Controller
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

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            var courseService = new CourseService(new CourseRepository(UniversityContext));
            return View(await courseService.GetAll()); //SELECT * FROM Course
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseService = new CourseService(new CourseRepository(UniversityContext));
            Course course = await courseService.GetById(id.Value); //SELECT * FROM Course WHERE CourseID = id

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                //INSERT INTO Course VALUES(CourseID,Title,Credits)
                var courseService = new CourseService(new CourseRepository(UniversityContext));
                course = await courseService.Insert(course);

                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseService = new CourseService(new CourseRepository(UniversityContext));
            Course course = await courseService.GetById(id.Value); //SELECT * FROM Course WHERE CourseID = id
            
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                //UPDATE Course SET Title,Credits WHERE CourseID = CourseID
                var courseService = new CourseService(new CourseRepository(UniversityContext));
                course = await courseService.Update(course);

                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseService = new CourseService(new CourseRepository(UniversityContext));
            Course course = await courseService.GetById(id.Value); //SELECT * FROM Course WHERE CourseID = id

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //DELETE FROM Course WHERE CourseID = id
            var courseService = new CourseService(new CourseRepository(UniversityContext));
            await courseService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
