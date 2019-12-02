using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementAngular.Models
{
    public class PurchaseViewModel
    {
        public int pd_id { get; set; }
        public string pd_order_no { get; set; }
        public Nullable<int> pd_ad_id { get; set; }
        public string pd_ad { get; set; }
        public Nullable<int> pd_type_id { get; set; }
        public string pd_type { get; set; }
        public decimal pd_qty { get; set; }
        public Nullable<int> pd_vendor_id { get; set; }
        public string pd_vendor { get; set; }
        public string pd_dateStr { get; set; }
        public string pd_ddateStr { get; set; }
        public string pd_status { get; set; }
    }
}