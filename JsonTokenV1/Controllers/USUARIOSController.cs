using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JsonTokenV1.Datos;

namespace JsonTokenV1.Controllers
{
    public class USUARIOSController : ApiController
    {
        private UsuarioEntities db = new UsuarioEntities();

        [Authorize]
        //[HttpGet]
        // GET: api/USUARIOS
        public IQueryable<USUARIOS> GetUSUARIOS()
        {
            return db.USUARIOS;
        }

        // GET: api/USUARIOS/5
        [ResponseType(typeof(USUARIOS))]
        public async Task<IHttpActionResult> GetUSUARIOS(decimal id)
        {
            USUARIOS uSUARIOS = await db.USUARIOS.FindAsync(id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }

            return Ok(uSUARIOS);
        }

        // PUT: api/USUARIOS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUSUARIOS(decimal id, USUARIOS uSUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIOS.IDUSUARIO)
            {
                return BadRequest();
            }

            db.Entry(uSUARIOS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/USUARIOS
        [ResponseType(typeof(USUARIOS))]
        public async Task<IHttpActionResult> PostUSUARIOS(USUARIOS uSUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIOS.Add(uSUARIOS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (USUARIOSExists(uSUARIOS.IDUSUARIO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uSUARIOS.IDUSUARIO }, uSUARIOS);
        }

        // DELETE: api/USUARIOS/5
        [ResponseType(typeof(USUARIOS))]
        public async Task<IHttpActionResult> DeleteUSUARIOS(decimal id)
        {
            USUARIOS uSUARIOS = await db.USUARIOS.FindAsync(id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }

            db.USUARIOS.Remove(uSUARIOS);
            await db.SaveChangesAsync();

            return Ok(uSUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOSExists(decimal id)
        {
            return db.USUARIOS.Count(e => e.IDUSUARIO == id) > 0;
        }
    }
}