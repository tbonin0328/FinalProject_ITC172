//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject_ITC172.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CommunityService
    {
        public CommunityService()
        {
            this.ServiceGrants = new HashSet<ServiceGrant>();
        }
    
        public int ServiceKey { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public Nullable<decimal> ServiceMaximum { get; set; }
        public Nullable<decimal> ServiceLifetimeMaximum { get; set; }
    
        public virtual ICollection<ServiceGrant> ServiceGrants { get; set; }
    }
}
