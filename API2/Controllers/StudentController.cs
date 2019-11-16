using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using API2.Models;
using API2.Repository;
using Domain;
using Service;

namespace API2.Controllers
{
    public class StudentController : ApiController
    {
        StudentService Service;

        public StudentController()
        {
            Service = new StudentService();
        }

        [HttpGet]
        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            List<Student> prodList = Service.Get();
            List<StudentModel> Students = new List<StudentModel>();
            foreach (var item in prodList)
            {
                Students.Add(mapObj.Translate(item));
            }
            return Json<List<StudentModel>>(Students);
        }

        [HttpGet]
        public JsonResult<StudentModel> GetStudent(int id)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            Student dalStudent = Service.GetById(id);
            StudentModel Students = new StudentModel();
            Students = mapObj.Translate(dalStudent);
            return Json<StudentModel>(Students);
        }

        [HttpPost]
        public bool InsertStudents(StudentModel Student)
        {
            bool status = false;
            Student.Activo = true;
            Student.FechaCreacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
                Student StudentObj = new Student();
                StudentObj = mapObj.Translate(Student);
                Service.Insert(StudentObj);
                status = true;
            }
            return status;
        }

        [HttpPut]
        public bool UpdateStudents(StudentModel student)
        {
            bool status = false;
            EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
            Student StudentObj = new Student();
            student.FechaModificacion = DateTime.Now;
            StudentObj = mapObj.Translate(student);
            Service.Update(StudentObj, student.StudentID);
            status = true;
            return status;
        }

        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            bool status = false;
            Service.Delete(id);
            status = true;
            return status;
        }

        [HttpGet]
        public JsonResult<List<StudentModel>> SearchStudents(string query)
        {
            List<StudentModel> Students = new List<StudentModel>();
            if (query is null)
            {
                return Json<List<StudentModel>>(Students);
            }
            else
            {
                EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
                List<Student> students = Service.Busqueda(query);
                foreach (var item in students)
                {
                    Students.Add(mapObj.Translate(item));
                }
                return Json<List<StudentModel>>(Students);

            }
        }
    }
}
