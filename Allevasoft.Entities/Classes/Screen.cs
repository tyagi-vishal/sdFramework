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
    
    public partial class Screen
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public int ScreenType { get; set; }
        public string UpdateStoredProcedure { get; set; }
        public string Url { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string FormParameters { get; set; }
        public string PageTitle { get; set; }
        public string Active { get; set; }
        public string CanSetPermission { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string RecordDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string DeletedBy { get; set; }
    }
}