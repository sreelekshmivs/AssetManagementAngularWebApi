using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementAngular.Models
{
    public class AssetDefinitionViewModel
    {
        public int ad_id { get; set; }
        public string ad_name { get; set; }
        public Nullable<int> ad_type_id { get; set; }
        public string ad_type{ get; set; }
        public string ad_class { get; set; }
    }
}