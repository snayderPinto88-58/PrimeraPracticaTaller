using System.ComponentModel.DataAnnotations;

namespace UniversidadApi.Models
{
    public class Universidad
    {
        [Key]
        public int Id_universidad { get; set; }
        public string nombre { get; set; }
        
    }
}
