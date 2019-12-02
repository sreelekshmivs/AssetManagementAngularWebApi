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
    public class Asset_defController : ApiController
    {
        private AssetMVCEntities3 db = new AssetMVCEntities3();

       /* // GET: api/Asset_def
        public IQueryable<Asset_def> GetAsset_def()
        {
            return db.Asset_def;
        }*/

        // GET: api/Asset_def/5
        [ResponseType(typeof(Asset_def))]
        public IHttpActionResult GetAsset_def(int id)
        {
            Asset_def asset_def = db.Asset_def.Find(id);
            if (asset_def == null)
            {
                return NotFound();
            }

            return Ok(asset_def);
        }
        public Asset_defController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<AssetDefinitionViewModel> GetAsset()
        {
            db.Configuration.ProxyCreationEnabled = true;

            List<Asset_def> assetlist = db.Asset_def.ToList();
                List<AssetDefinitionViewModel> avlist = assetlist.Select(x => new AssetDefinitionViewModel
                {
                    ad_id = Convert.ToInt32(x.ad_id),
                    ad_name = x.ad_name,
                    ad_type_id=x.ad_type_id,
                    ad_type = x.Asset_type.at_name,
                    ad_class = x.ad_class

                }).ToList();
                return avlist;
            
               
        }
        public List<AssetDefinitionViewModel> GetAsset_def(string name)
        {
            db.Configuration.ProxyCreationEnabled = true;

            List<Asset_def> assetlist = db.Asset_def.Where(x => x.ad_name.StartsWith(name)).ToList();
            List<AssetDefinitionViewModel> avlist = assetlist.Select(x => new AssetDefinitionViewModel
            {
                ad_id = Convert.ToInt32(x.ad_id),
                ad_name = x.ad_name,
                ad_type_id=x.ad_type_id,
                ad_type = x.Asset_type.at_name,
                ad_class = x.ad_class

            }).ToList();
            return avlist;
        }
        // PUT: api/Asset_def/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsset_def(int id, Asset_def asset_def)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != asset_def.ad_id)
            {
                return BadRequest();
            }

            db.Entry(asset_def).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asset_defExists(id))
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

        // POST: api/Asset_def
        [ResponseType(typeof(Asset_def))]
        public int PostAsset_def(Asset_def asset_def)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            Asset_def asset = new Asset_def();
            asset = db.Asset_def.Where(x => x.ad_name == asset_def.ad_name && x.ad_type_id == asset_def.ad_type_id).FirstOrDefault();
            if(asset==null)
            {
                db.Asset_def.Add(asset_def);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            

            //return CreatedAtRoute("DefaultApi", new { id = asset_def.ad_id }, asset_def);
        }

        // DELETE: api/Asset_def/5
        [ResponseType(typeof(Asset_def))]
        public IHttpActionResult DeleteAsset_def(int id)
        {
            Asset_def asset_def = db.Asset_def.Find(id);
            if (asset_def == null)
            {
                return NotFound();
            }

            db.Asset_def.Remove(asset_def);
            db.SaveChanges();

            return Ok(asset_def);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Asset_defExists(int id)
        {
            return db.Asset_def.Count(e => e.ad_id == id) > 0;
        }
    }
}