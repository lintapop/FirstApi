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
using FirstApi.Models;

namespace FirstApi.Controllers
{
    public class ArtistInfoesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ArtistInfoes
        public IQueryable<ArtistInfo> GetArtistInfos()
        {
            return db.ArtistInfos;
        }

        // GET: api/ArtistInfoes/5
        [ResponseType(typeof(ArtistInfo))]
        public IHttpActionResult GetArtistInfo(int id)
        {
            ArtistInfo artistInfo = db.ArtistInfos.Find(id);
            if (artistInfo == null)
            {
                return NotFound();
            }

            return Ok(artistInfo);
        }

        // PUT: api/ArtistInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtistInfo(int id, ArtistInfo artistInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artistInfo.id)
            {
                return BadRequest();
            }

            db.Entry(artistInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistInfoExists(id))
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

        // POST: api/ArtistInfoes
        [HttpPost]
        [ResponseType(typeof(ArtistInfo))]
        [Route("AddArtistInfo")]
        public IHttpActionResult PostArtistInfo(ArtistInfo artistInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArtistInfos.Add(artistInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                id = artistInfo.id
            }, artistInfo);
        }

        // DELETE: api/ArtistInfoes/5
        [ResponseType(typeof(ArtistInfo))]
        public IHttpActionResult DeleteArtistInfo(int id)
        {
            ArtistInfo artistInfo = db.ArtistInfos.Find(id);
            if (artistInfo == null)
            {
                return NotFound();
            }

            db.ArtistInfos.Remove(artistInfo);
            db.SaveChanges();

            return Ok(artistInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistInfoExists(int id)
        {
            return db.ArtistInfos.Count(e => e.id == id) > 0;
        }
    }
}