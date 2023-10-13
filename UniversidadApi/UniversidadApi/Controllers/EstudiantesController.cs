using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadApi.Context;
using UniversidadApi.Models;

namespace UniversidadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LISTA-LEER")]
        public IActionResult lista()
        {
            var estu = this._context.estudiantes.ToList();
            return Ok(estu);
        }

        [HttpPost]
        [Route("CREAR-Estudiante")]
        public IActionResult CrearEstudiante([FromBody] Estudiantes nuevoEstu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.estudiantes.Add(nuevoEstu);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

        [HttpDelete("ELIMINAR/{Id_estudiante}")]
        public IActionResult EliminarEstud(int Id_estudiante)
        {
            try
            {

                var estu = _context.estudiantes.Find(Id_estudiante);

                if (estu == null)
                {
                    return NotFound();
                }

                _context.estudiantes.Remove(estu);
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
