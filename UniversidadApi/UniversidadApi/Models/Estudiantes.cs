using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversidadApi.Models
{
    public class Estudiantes
    {
        [Key]
        public int Id_estudiante { get; set; }
        public string nombre {get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string sexo { get; set;}

        [ForeignKey("Universidad")]
        public int Id_universidad { get; set; }
        public Universidad Universidad { get; set; }
    }
}
