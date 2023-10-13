using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadApi.Context;
using UniversidadApi.Models;

namespace UniversidadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RelacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista docente y a q universidad pertenece")]
        public IActionResult LeerInformaciondeDocentes()
        {
            try
            {
                var query = _context.docentes.Include(d => d.Universidad).ToList();
                return Ok(query);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpGet]
        [Route("lista estudiantes y a q universidad pertenece")]
        public IActionResult LeerInformacionEstudiantes()
        {
            try
            {
                var query = _context.estudiantes.Include(d => d.Universidad).ToList();
                return Ok(query);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        [HttpGet]
        [Route("consulta nombre de estudiante y a q uni pertenece")]
        public IActionResult consulta1() 
        {
            var query = from estudiante in _context.estudiantes
                        join universidad in _context.universidad
                        on estudiante.Id_universidad equals universidad.Id_universidad
                        select new
                        {
                            NombreEstudiante = estudiante.nombre,
                            NombreUniversidad=universidad.nombre,
                        };

            var resultados = query.ToList();
            return Ok(resultados);
        }


        [HttpGet]
        [Route("consulta nombre de docente y a q uni pertenece")]
        public IActionResult consulta2()
        {
            var query = from docentes in _context.docentes
                        join universidad in _context.universidad
                        on docentes.Id_universidad equals universidad.Id_universidad
                        select new
                        {
                            NombreEstudiante = docentes.nombre,
                            NombreUniversidad = universidad.nombre,
                        };

            var resultados = query.ToList();
            return Ok(resultados);
        }
    }
}
