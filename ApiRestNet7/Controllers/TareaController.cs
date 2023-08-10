using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Referencias a usar
using Microsoft.EntityFrameworkCore;
using ApiRestNet7.Models;
using System.Security;

namespace ApiRestNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DbAngularContext _baseDatos;

        public TareaController(DbAngularContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> lista()
        {
            var listaTareas = await _baseDatos.Tareas.ToListAsync();

            return Ok(listaTareas);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> agregar([FromBody] Tarea request)
        {
            await _baseDatos.Tareas.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> eliminar(int id)
        {
            var tareaEliminar = await _baseDatos.Tareas.FindAsync(id);

            if (tareaEliminar == null)
            {
                return BadRequest("No existe la tarea");
            }
            else
            {
                _baseDatos.Tareas.Remove(tareaEliminar);
                await _baseDatos.SaveChangesAsync();
                return Ok();

            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> editar([FromBody] Tarea request)
        {
            var actualizarTarea = _baseDatos.Tareas.Update(request);

            if (actualizarTarea != null)
            {
                await _baseDatos.SaveChangesAsync();
                return Ok();
            }
            else
            {

                return BadRequest("No se puedo actualizar la tarea");
            }

        }


    }

}
