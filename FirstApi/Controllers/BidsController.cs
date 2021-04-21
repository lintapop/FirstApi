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
    public class BidsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Bids
        public IQueryable<Bid> GetBids()
        {
            return db.Bids;
        }

        // GET: api/Bids/5
        [ResponseType(typeof(Bid))]
        public IHttpActionResult GetBid(int id)
        {
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }

        // PUT: api/Bids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBid(int id, Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bid.Id)
            {
                return BadRequest();
            }

            db.Entry(bid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(id))
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

        // POST: api/Bids
        [ResponseType(typeof(Bid))]
        public IHttpActionResult PostBid(Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bids.Add(bid);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bid.Id }, bid);
        }

        // DELETE: api/Bids/5
        [ResponseType(typeof(Bid))]
        public IHttpActionResult DeleteBid(int id)
        {
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return NotFound();
            }

            db.Bids.Remove(bid);
            db.SaveChanges();

            return Ok(bid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BidExists(int id)
        {
            return db.Bids.Count(e => e.Id == id) > 0;
        }
    }
}