using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadApi.Context;
using UniversidadApi.Models;

namespace UniversidadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LISTA-LEER")]
        public IActionResult lista()
        {
            var docentes = this._context.docentes.ToList();
            return Ok(docentes);
        }

        [HttpPost]
        [Route("CREAR-Docente")]
        public IActionResult CrearDocente([FromBody] Docentes nuevoDocente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.docentes.Add(nuevoDocente);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

        [HttpDelete("ELIMINAR/{Id_docente}")]
        public IActionResult EliminarDocente(int Id_docente)
        {
            try
            {

                var doce = _context.docentes.Find(Id_docente);

                if (doce == null)
                {
                    return NotFound();
                }

                _context.docentes.Remove(doce);
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
