using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadApi.Context;
using UniversidadApi.Models;

namespace UniversidadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LISTA Materia")]
        public IActionResult lista()
        {
            var materia = this._context.materias.ToList();
            return Ok(materia);
        }
        [HttpPost]
        [Route("CREAR-Materia")]
        public IActionResult CrearMateria([FromBody] Materia nuevoMateria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.materias.Add(nuevoMateria);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
        [HttpDelete("ELIMINAR/{Id_materia}")]
        public IActionResult EliminarMateria(int Id_materia)
        {
            try
            {

                var materia = _context.materias.Find(Id_materia);

                if (materia == null)
                {
                    return NotFound();
                }

                _context.materias.Remove(materia);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mesaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

    }
}
