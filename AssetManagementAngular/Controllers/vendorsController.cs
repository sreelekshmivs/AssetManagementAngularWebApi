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
    public class vendorsController : ApiController
    {
        private AssetMVCEntities3 db = new AssetMVCEntities3();

        //// GET: api/vendors
        //public IQueryable<vendor> Getvendors()
        //{
        //    return db.vendors;
        //}

        // GET: api/vendors/5
        [ResponseType(typeof(vendor))]
        public IHttpActionResult Getvendor(int id)
        {
            vendor vendor = db.vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }
        public vendorsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<VendorViewModel> GetAsset()
        {
            db.Configuration.ProxyCreationEnabled = true;

            List<vendor> vdlist = db.vendors.ToList();
            List<VendorViewModel> avlist = vdlist.Select(x => new VendorViewModel
            {
                vd_id = Convert.ToInt32(x.vd_id),
                vd_name = x.vd_name,
                vd_type=x.vd_type,
                vd_atype_id=x.vd_atype_id,
                vd_atype = x.Asset_type.at_name,
                vd_fromStr = x.vd_fromStr,
                vd_toStr=x.vd_toStr,
                vd_addr=x.vd_addr


            }).ToList();
            return avlist;


        }
        public List<vendor> Getvendor(string name)
        {
            List<vendor> vlist = db.vendors.Where(x => x.vd_name.StartsWith(name)).ToList();
            return vlist;
        }
        // PUT: api/vendors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvendor(int id, vendor vendor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != vendor.vd_id)
            {
                return BadRequest();
            }

            db.Entry(vendor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vendorExists(id))
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

        // POST: api/vendors
        [ResponseType(typeof(vendor))]
        public int Postvendor(vendor vendor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            vendor vd = new vendor();
            vd = db.vendors.Where(x => x.vd_name == vendor.vd_name && x.vd_atype_id == vendor.vd_atype_id).FirstOrDefault();
            if(vd==null)
            {
                db.vendors.Add(vendor);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }


            //return CreatedAtRoute("DefaultApi", new { id = vendor.vd_id }, vendor);
        }

        // DELETE: api/vendors/5
        [ResponseType(typeof(vendor))]
        public IHttpActionResult Deletevendor(int id)
        {
            vendor vendor = db.vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }

            db.vendors.Remove(vendor);
            db.SaveChanges();

            return Ok(vendor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vendorExists(int id)
        {
            return db.vendors.Count(e => e.vd_id == id) > 0;
        }
    }
}