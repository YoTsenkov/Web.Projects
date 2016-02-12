﻿namespace ColorCraft.Services.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using ColorCraft.Data;
    using ColorCraft.Models;

    public class ColorsController : ApiController
    {
        private ColorDbContext db = new ColorDbContext();

        // GET: api/Colors
        public IQueryable<Color> GetColors()
        {
            return db.Colors;
        }

        // GET: api/Colors/5
        [ResponseType(typeof(Color))]
        public IHttpActionResult GetColor(int id)
        {
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }

        // PUT: api/Colors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColor(int id, Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != color.Id)
            {
                return BadRequest();
            }

            db.Entry(color).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Colors
        [ResponseType(typeof(Color))]
        public IHttpActionResult PostColor(Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Colors.Add(color);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = color.Id }, color);
        }

        // DELETE: api/Colors/5
        [ResponseType(typeof(Color))]
        public IHttpActionResult DeleteColor(int id)
        {
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return NotFound();
            }

            db.Colors.Remove(color);
            db.SaveChanges();

            return Ok(color);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorExists(int id)
        {
            return db.Colors.Count(e => e.Id == id) > 0;
        }
    }
}