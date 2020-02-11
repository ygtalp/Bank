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
    public class HesapsController : ApiController
    {
        private ClientDBEntities db = new ClientDBEntities();

        // GET: api/Hesaps
        public IQueryable<Hesap> GetHesaps()
        {
            return db.Hesaps;
        }

        // GET: api/Hesaps/5
        [ResponseType(typeof(Hesap))]
        public IHttpActionResult GetHesap(int id)
        {
            Hesap hesap = db.Hesaps.Find(id);
            if (hesap == null)
            {
                return NotFound();
            }

            return Ok(hesap);
        }

        // PUT: api/Hesaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHesap(int id, Hesap hesap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hesap.HesapId)
            {
                return BadRequest();
            }

            db.Entry(hesap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HesapExists(id))
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

        // POST: api/Hesaps
        [ResponseType(typeof(Hesap))]
        public IHttpActionResult PostHesap(Hesap hesap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hesaps.Add(hesap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hesap.HesapId }, hesap);
        }

        // DELETE: api/Hesaps/5
        [ResponseType(typeof(Hesap))]
        public IHttpActionResult DeleteHesap(int id)
        {
            Hesap hesap = db.Hesaps.Find(id);
            if (hesap == null)
            {
                return NotFound();
            }

            db.Hesaps.Remove(hesap);
            db.SaveChanges();

            return Ok(hesap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HesapExists(int id)
        {
            return db.Hesaps.Count(e => e.HesapId == id) > 0;
        }
    }
}