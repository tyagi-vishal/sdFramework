//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Allevasoft.Entities.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class LeadLevelOfCare
    {
        public long LeadCareId { get; set; }
        public Nullable<long> LeadId { get; set; }
        public Nullable<int> LevelOfCareId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    
        public virtual LeadInfo LeadInfo { get; set; }
    }
}
