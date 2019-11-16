using System;

namespace MVCAJAX.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }

        public string Codigo { get; set; }

        public string StudentName { get; set; }

        public string StudentLastName { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string StudentAddress { get; set; }

        public bool? Activo { get; set; }
    }
}