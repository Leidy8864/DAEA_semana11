using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();

        // GET: Student
        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult searchStudent(string query)
        {
            var response = Task.Run(() => proxy.SearchStudentsAsync(query));
            string message = response.Result.Mensaje;
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult detailStudent(int Id)
        {
            var response = Task.Run(() => proxy.GetStudentAsync(Id));
            return Json(response.Result.objeto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(StudentModel std)
        {
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public ActionResult updateStudent(StudentModel student)
        {
            var response = Task.Run(() => proxy.UpdateAsync(student));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult deleteStudent(int id)
        {
            var response = Task.Run(() => proxy.DeleteStudentAsync(id));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}