using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController: ControllerBase
    {

        public DbEscuelaApiContext Context { get; set; }

        public AlumnoController(DbEscuelaApiContext context)
        {
            this.Context = context;
        }




        //GET: /api/alumno/
        [HttpGet]
        public List<Alumno> Get()
        {
            List<Alumno> alumnos = Context.Alumnos.ToList();
            return alumnos;
        }

        //GET: /api/alumno/id
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            return Context.Alumnos.Find(id);
        }

        //POST: /api/alumno
        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            Context.Alumnos.Add(alumno);
            Context.SaveChanges();
            return Ok();
        }

        //PUT: /api/alumno
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        //DELETE: /api/alumno
        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            Alumno alumno = Context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }

            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();

            return alumno;
        }
        
    }
}
