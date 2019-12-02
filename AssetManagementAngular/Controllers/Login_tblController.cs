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
using AssetManagementAngular.Models;

namespace AssetManagementAngular.Controllers
{
    public class Login_tblController : ApiController
    {
        private AssetMVCEntities3 db = new AssetMVCEntities3();

        // GET: api/Login_tbl
        public IQueryable<Login_tbl> GetLogin_tbl()
        {
            return db.Login_tbl;
        }
        public Login_tbl GetLogin_Tbl(string u_name,string p_word)
        {
            Login_tbl lo = db.Login_tbl.Where(x => x.u_name == u_name && x.p_word == p_word).FirstOrDefault();
            return lo;
        }
        // GET: api/Login_tbl/5
        [ResponseType(typeof(Login_tbl))]
        public IHttpActionResult GetLogin_tbl(int id)
        {
            Login_tbl login_tbl = db.Login_tbl.Find(id);
            if (login_tbl == null)
            {
                return NotFound();
            }

            return Ok(login_tbl);
        }

        // PUT: api/Login_tbl/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogin_tbl(int id, Login_tbl login_tbl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != login_tbl.l_id)
            {
                return BadRequest();
            }

            db.Entry(login_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Login_tblExists(id))
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

        // POST: api/Login_tbl
        [ResponseType(typeof(Login_tbl))]
        public IHttpActionResult PostLogin_tbl(Login_tbl login_tbl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Login_tbl.Add(login_tbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = login_tbl.l_id }, login_tbl);
        }

        // DELETE: api/Login_tbl/5
        [ResponseType(typeof(Login_tbl))]
        public IHttpActionResult DeleteLogin_tbl(int id)
        {
            Login_tbl login_tbl = db.Login_tbl.Find(id);
            if (login_tbl == null)
            {
                return NotFound();
            }

            db.Login_tbl.Remove(login_tbl);
            db.SaveChanges();

            return Ok(login_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Login_tblExists(int id)
        {
            return db.Login_tbl.Count(e => e.l_id == id) > 0;
        }
    }
}