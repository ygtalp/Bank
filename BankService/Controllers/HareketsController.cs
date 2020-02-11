using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess;

namespace BankService.Controllers
{
    public class HareketsController : ApiController
    {
        private ClientDBEntities db = new ClientDBEntities();

        // GET: api/Harekets
        public IQueryable<Hareket> GetHarekets()
        {
            return db.Harekets;
        }

        // GET: api/Harekets/5
        [ResponseType(typeof(Hareket))]
        public IHttpActionResult GetHareket(int id)
        {
            Hareket hareket = db.Harekets.Find(id);
            if (hareket == null)
            {
                return NotFound();
            }

            return Ok(hareket);
        }

        // PUT: api/Harekets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHareket(int id, Hareket hareket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hareket.Id)
            {
                return BadRequest();
            }

            db.Entry(hareket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HareketExists(id))
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

        // POST: api/Harekets
        [ResponseType(typeof(Hareket))]
        public IHttpActionResult PostHareket(Hareket hareket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Harekets.Add(hareket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hareket.Id }, hareket);
        }

        // DELETE: api/Harekets/5
        [ResponseType(typeof(Hareket))]
        public IHttpActionResult DeleteHareket(int id)
        {
            Hareket hareket = db.Harekets.Find(id);
            if (hareket == null)
            {
                return NotFound();
            }

            db.Harekets.Remove(hareket);
            db.SaveChanges();

            return Ok(hareket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HareketExists(int id)
        {
            return db.Harekets.Count(e => e.Id == id) > 0;
        }
    }
}