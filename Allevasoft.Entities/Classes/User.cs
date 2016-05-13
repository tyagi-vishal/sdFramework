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
    
    public partial class User
    {
        public int UserId { get; set; }
        public System.Guid AspNetUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> Prefix { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> Suffix { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> Position { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> TimeZoneId { get; set; }
        public string UserName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Role Role { get; set; }
    }
}