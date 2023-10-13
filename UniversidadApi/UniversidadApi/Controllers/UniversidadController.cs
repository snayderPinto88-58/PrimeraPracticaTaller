using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadApi.Context;
using UniversidadApi.Models;

namespace UniversidadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UniversidadController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route ("LISTA-LEER")]
        public IActionResult lista() 
        {
            var uni= this._context.universidad.ToList();
            return Ok(uni);
        }


        [HttpPost]
        [Route("CREAR-UNIVERSIDAD")]
        public IActionResult CrearUniversidad([FromBody] Universidad nuevaUniversidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.universidad.Add(nuevaUniversidad);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }


        [HttpPut("EDITAR/{Id_universidad}")]
        public IActionResult EditarUniversidad(int Id_universidad, [FromBody] Universidad universidadActualizada)
        {
            try
            {
                var universidadExistente = _context.universidad.Find(Id_universidad);

                if (universidadExistente == null)
                {
                    return NotFound(); 
                }

                if (ModelState.IsValid)
                {
                    universidadExistente.nombre = universidadActualizada.nombre;

                    _context.SaveChanges();                   
                }
                return Ok(new { mensaje = "Edición exitosa" });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpDelete("ELIMINAR/{Id_universidad}")]
        public IActionResult EliminarUniversidad(int Id_universidad)
        {
            try
            {
                
                var universidad = _context.universidad.Find(Id_universidad);

                if (universidad == null)
                {
                    return NotFound(); 
                }

                _context.universidad.Remove(universidad);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mesaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }


        [HttpGet("buscar/{Id_universidad}")]
        public IActionResult BuscarUniversidad(int Id_universidad)
        {
            try
            {
                var universidad = _context.universidad.Find(Id_universidad);

                if (universidad == null)
                {
                    return NotFound(); 
                }

                return Ok(universidad); 
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }



    }
}
