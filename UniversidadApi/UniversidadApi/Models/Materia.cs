using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversidadApi.Models
{
    public class Materiacs
    {
        [Key]
        public int Id_materia { get; set; }
        public string nombreMateria { get; set; }

        [ForeignKey("Docentes")]
        public int Id_docente { get; set; }
        public Docentes Docentes { get; set; }
    }
}
