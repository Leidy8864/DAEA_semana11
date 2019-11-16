using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure;

namespace Service
{
    public class StudentService
    {
        public List<Student> Get()
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(x => x.Activo == true).ToList();
            }
            return students;
        }

        public Student GetById(int StudentID)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(StudentID);
            }

            return student;
        }


        public List<Student> Busqueda(string query)
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(x => x.Activo == true && x.StudentName.Contains(query) || x.StudentLastName.Contains(query)).ToList();
            }
            return students;
        }


        public void Insert(Student student)
        {
            using (var context = new SchoolContext())
            {
                student.Activo = true;
                student.FechaCreacion = DateTime.Now;
                context.Students.Add(student);
                context.SaveChanges();

            }
        }

        public void Update(Student student, int StudentID)
        {
            using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(StudentID);
                Console.WriteLine(studentNew);
                studentNew.Codigo = student.Codigo;
                studentNew.StudentName = student.StudentName;
                studentNew.StudentLastName = student.StudentLastName;
                studentNew.StudentAddress = student.StudentAddress;
                studentNew.FechaModificacion = student.FechaModificacion;
                context.SaveChanges();

            }
        }

        public void Delete(int StudentID)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.Find(StudentID);
                student.Activo = false;
                //context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
