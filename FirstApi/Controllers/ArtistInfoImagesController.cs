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
    public class ArtistInfoImagesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ArtistInfoImages
        public IQueryable<ArtistInfoImage> GetArtistInfoImages()
        {
            return db.ArtistInfoImages;
        }

        // GET: api/ArtistInfoImages/5
        [ResponseType(typeof(ArtistInfoImage))]
        public IHttpActionResult GetArtistInfoImage(int id)
        {
            ArtistInfoImage artistInfoImage = db.ArtistInfoImages.Find(id);
            if (artistInfoImage == null)
            {
                return NotFound();
            }

            return Ok(artistInfoImage);
        }

        // PUT: api/ArtistInfoImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtistInfoImage(int id, ArtistInfoImage artistInfoImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artistInfoImage.id)
            {
                return BadRequest();
            }

            db.Entry(artistInfoImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistInfoImageExists(id))
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

        // POST: api/ArtistInfoImages
        [ResponseType(typeof(ArtistInfoImage))]
        public IHttpActionResult PostArtistInfoImage(ArtistInfoImage artistInfoImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArtistInfoImages.Add(artistInfoImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = artistInfoImage.id }, artistInfoImage);
        }

        // DELETE: api/ArtistInfoImages/5
        [ResponseType(typeof(ArtistInfoImage))]
        public IHttpActionResult DeleteArtistInfoImage(int id)
        {
            ArtistInfoImage artistInfoImage = db.ArtistInfoImages.Find(id);
            if (artistInfoImage == null)
            {
                return NotFound();
            }

            db.ArtistInfoImages.Remove(artistInfoImage);
            db.SaveChanges();

            return Ok(artistInfoImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistInfoImageExists(int id)
        {
            return db.ArtistInfoImages.Count(e => e.id == id) > 0;
        }
    }
}