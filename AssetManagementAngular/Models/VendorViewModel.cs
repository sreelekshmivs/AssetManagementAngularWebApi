using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementAngular.Models
{
    public class VendorViewModel
    {
        public int vd_id { get; set; }
        public string vd_name { get; set; }
        public string vd_type { get; set; }
        public Nullable<int> vd_atype_id { get; set; }
        public string vd_atype { get; set; }
        
        public string vd_fromStr { get; set; }
  
        public string vd_toStr { get; set; }

        public string vd_addr { get; set; }
    }
}