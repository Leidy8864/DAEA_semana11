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

        public Student GetById(int ID)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {

                student = context.Students.Find(ID);

            }

            return student;
        }


        public List<Student> Busqueda(string NombreApellido)
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(x => x.Activo == true && x.StudentName.Contains(NombreApellido) || x.Activo == true && x.LastName.Contains(NombreApellido)).ToList();
            }

            return students;
        }


        public void Insert(Student student)
        {
            using (var context = new SchoolContext())
            {
                student.Activo = true;
                context.Students.Add(student);
                context.SaveChanges();

            }
        }

        public void Update(Student studentNew, int ID)
        {
            using (var context = new SchoolContext())
            {

                var student = context.Students.Find(ID);

                student.FechaModificacion = studentNew.FechaModificacion;
                student.StudentName = studentNew.StudentName;
                student.LastName = studentNew.LastName;
                student.StudentAddress = studentNew.StudentAddress;

                context.SaveChanges();

            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {

                var student = context.Students.Find(ID);
                student.Activo = false;
                //context.Students.Remove(student);
                context.SaveChanges();

            }
        }
    }
}
