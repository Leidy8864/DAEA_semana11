using Service;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();

        // GET: Student
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.StundentID,
                             StudentAddress = c.StudentAddress,
                             StudentName = c.StudentName
                         }).ToList();
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Busqueda(string NombreApellido)
        {

            return Json(service.Busqueda(NombreApellido), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult EstudentDetail(int Id)
        {

            return Json(service.GetById(Id), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CreateStudent(Student std)
        {
            std.FechaCreacion = DateTime.Today;
            service.Insert(std);
            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }


        [HttpPost]
        public ActionResult UpdateStudent(Student std, int Id)
        {
            std.FechaModificacion = DateTime.Today;
            service.Update(std, Id);
            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }

        [HttpPost]
        public ActionResult DeleteStudent(int Id)
        {
            service.Delete(Id);
            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }
    }
}