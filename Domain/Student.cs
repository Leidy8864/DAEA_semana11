using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Student
    {
        [Key]
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
