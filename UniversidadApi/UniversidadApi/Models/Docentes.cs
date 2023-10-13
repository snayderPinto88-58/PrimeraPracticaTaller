using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversidadApi.Models
{
    public class Docentes
    {
        [Key]
        public int Id_docente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string ubicacion { get; set; }
        public string sexo { get; set; }
        public string ci { get; set; }

        [ForeignKey("Universidad")] 
        public int Id_universidad { get; set; }
        public Universidad Universidad { get; set; }
    }
}
