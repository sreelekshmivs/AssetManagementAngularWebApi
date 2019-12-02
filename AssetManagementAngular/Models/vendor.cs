//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssetManagementAngular.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vendor()
        {
            this.Asset_master = new HashSet<Asset_master>();
            this.Purchase_order = new HashSet<Purchase_order>();
        }
    
        public int vd_id { get; set; }
        public string vd_name { get; set; }
        public string vd_type { get; set; }
        public Nullable<int> vd_atype_id { get; set; }
        public DateTime vd_from { get; set; }
        public string vd_fromStr
        {
            get
            {
                return vd_from.ToString("yyyy-MM-dd");
            }
        }

        public DateTime vd_to { get; set; }
        public string vd_toStr
        {
            get
            {
                return vd_to.ToString("yyyy-MM-dd");
            }
        }
        public string vd_addr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_master> Asset_master { get; set; }
        public virtual Asset_type Asset_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase_order> Purchase_order { get; set; }
    }
}