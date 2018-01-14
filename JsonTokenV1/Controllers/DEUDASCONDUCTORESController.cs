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
using JsonTokenV1.DataMML;

namespace JsonTokenV1.Controllers
{
    public class DEUDASCONDUCTORESController : ApiController
    {
        private DeudasMmlEntities db = new DeudasMmlEntities();

        // GET: api/DEUDASCONDUCTORES
        public IQueryable<DEUDASCONDUCTORES> GetDEUDASCONDUCTORES()
        {
            return db.DEUDASCONDUCTORES;
        }

        // GET: api/DEUDASCONDUCTORES/5
        [ResponseType(typeof(DEUDASCONDUCTORES))]
        public async Task<IHttpActionResult> GetDEUDASCONDUCTORES(string id)
        {
            DEUDASCONDUCTORES dEUDASCONDUCTORES = await db.DEUDASCONDUCTORES.FindAsync(id);
            if (dEUDASCONDUCTORES == null)
            {
                return NotFound();
            }

            return Ok(dEUDASCONDUCTORES);
        }

        // PUT: api/DEUDASCONDUCTORES/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDEUDASCONDUCTORES(string id, DEUDASCONDUCTORES dEUDASCONDUCTORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dEUDASCONDUCTORES.COD_PUESTO)
            {
                return BadRequest();
            }

            db.Entry(dEUDASCONDUCTORES).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEUDASCONDUCTORESExists(id))
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

        // POST: api/DEUDASCONDUCTORES
        [ResponseType(typeof(DEUDASCONDUCTORES))]
        public async Task<IHttpActionResult> PostDEUDASCONDUCTORES(DEUDASCONDUCTORES dEUDASCONDUCTORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DEUDASCONDUCTORES.Add(dEUDASCONDUCTORES);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DEUDASCONDUCTORESExists(dEUDASCONDUCTORES.COD_PUESTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dEUDASCONDUCTORES.COD_PUESTO }, dEUDASCONDUCTORES);
        }

        // DELETE: api/DEUDASCONDUCTORES/5
        [ResponseType(typeof(DEUDASCONDUCTORES))]
        public async Task<IHttpActionResult> DeleteDEUDASCONDUCTORES(string id)
        {
            DEUDASCONDUCTORES dEUDASCONDUCTORES = await db.DEUDASCONDUCTORES.FindAsync(id);
            if (dEUDASCONDUCTORES == null)
            {
                return NotFound();
            }

            db.DEUDASCONDUCTORES.Remove(dEUDASCONDUCTORES);
            await db.SaveChangesAsync();

            return Ok(dEUDASCONDUCTORES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DEUDASCONDUCTORESExists(string id)
        {
            return db.DEUDASCONDUCTORES.Count(e => e.COD_PUESTO == id) > 0;
        }
    }
}