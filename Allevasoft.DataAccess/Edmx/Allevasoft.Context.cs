﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Allevasoft.DataAccess.Edmx
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Allevasoft.DataAccess.Repository;
    using Allevasoft.Entities.Classes;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AllevasoftEntities : DbContext,IDbContext
    {
        public AllevasoftEntities()
            : base("name=AllevasoftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<LogException> LogExceptions { get; set; }
        public virtual DbSet<LogOperation> LogOperations { get; set; }
        public virtual DbSet<LogProperty> LogProperties { get; set; }
        public virtual DbSet<LogPropertyChanx> LogPropertyChanges { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogType> LogTypes { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<LogInfo> LogInfoes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<BillingCompany> BillingCompanies { get; set; }
        public virtual DbSet<BillingCompanyContact> BillingCompanyContacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<GlobalCodeCategory> GlobalCodeCategories { get; set; }
        public virtual DbSet<GlobalCode> GlobalCodes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<RehabCompany> RehabCompanies { get; set; }
        public virtual DbSet<RehabFacility> RehabFacilities { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<ScreenType> ScreenTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<SubMenu> SubMenus { get; set; }
        public virtual DbSet<ReferralCompany> ReferralCompanies { get; set; }
        public virtual DbSet<ReferralContact> ReferralContacts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LeadBillingInfo> LeadBillingInfoes { get; set; }
        public virtual DbSet<LeadCareTreatment> LeadCareTreatments { get; set; }
        public virtual DbSet<LeadInfo> LeadInfoes { get; set; }
        public virtual DbSet<LeadIntakeStatu> LeadIntakeStatus { get; set; }
        public virtual DbSet<LeadLevelOfCare> LeadLevelOfCares { get; set; }
        public virtual DbSet<LeadEmergencyContact> LeadEmergencyContacts { get; set; }
    
        public virtual ObjectResult<ssp_GetAllMenu_Result> ssp_GetAllMenu()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllMenu_Result>("ssp_GetAllMenu");
        }
    
        public virtual ObjectResult<ssp_GetCRMDashbordDatails_Result> ssp_GetCRMDashbordDatails(string actionparameter, string appointmentDateFilter)
        {
            var actionparameterParameter = actionparameter != null ?
                new ObjectParameter("actionparameter", actionparameter) :
                new ObjectParameter("actionparameter", typeof(string));
    
            var appointmentDateFilterParameter = appointmentDateFilter != null ?
                new ObjectParameter("appointmentDateFilter", appointmentDateFilter) :
                new ObjectParameter("appointmentDateFilter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetCRMDashbordDatails_Result>("ssp_GetCRMDashbordDatails", actionparameterParameter, appointmentDateFilterParameter);
        }
    
        public virtual int ssp_InsertReferralCompany(string referralCompanyName, string address1, string address2, string city, Nullable<int> stateId, Nullable<int> countryId, string postalCode, string mobileNumber, string officeNumber, string otherNumber, string fax, string emailAddress, string website, Nullable<int> referralTypeId, Nullable<int> referralCategoryId, string reason, string facebookProfileURL, string twitterProfileURL, string linkedinProfileURL, string uploadDocumentName, string documentExtension, string documentFilePath, Nullable<int> createdBy)
        {
            var referralCompanyNameParameter = referralCompanyName != null ?
                new ObjectParameter("ReferralCompanyName", referralCompanyName) :
                new ObjectParameter("ReferralCompanyName", typeof(string));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("Address1", address1) :
                new ObjectParameter("Address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("Address2", address2) :
                new ObjectParameter("Address2", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            var mobileNumberParameter = mobileNumber != null ?
                new ObjectParameter("MobileNumber", mobileNumber) :
                new ObjectParameter("MobileNumber", typeof(string));
    
            var officeNumberParameter = officeNumber != null ?
                new ObjectParameter("OfficeNumber", officeNumber) :
                new ObjectParameter("OfficeNumber", typeof(string));
    
            var otherNumberParameter = otherNumber != null ?
                new ObjectParameter("OtherNumber", otherNumber) :
                new ObjectParameter("OtherNumber", typeof(string));
    
            var faxParameter = fax != null ?
                new ObjectParameter("Fax", fax) :
                new ObjectParameter("Fax", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var websiteParameter = website != null ?
                new ObjectParameter("Website", website) :
                new ObjectParameter("Website", typeof(string));
    
            var referralTypeIdParameter = referralTypeId.HasValue ?
                new ObjectParameter("ReferralTypeId", referralTypeId) :
                new ObjectParameter("ReferralTypeId", typeof(int));
    
            var referralCategoryIdParameter = referralCategoryId.HasValue ?
                new ObjectParameter("ReferralCategoryId", referralCategoryId) :
                new ObjectParameter("ReferralCategoryId", typeof(int));
    
            var reasonParameter = reason != null ?
                new ObjectParameter("Reason", reason) :
                new ObjectParameter("Reason", typeof(string));
    
            var facebookProfileURLParameter = facebookProfileURL != null ?
                new ObjectParameter("FacebookProfileURL", facebookProfileURL) :
                new ObjectParameter("FacebookProfileURL", typeof(string));
    
            var twitterProfileURLParameter = twitterProfileURL != null ?
                new ObjectParameter("TwitterProfileURL", twitterProfileURL) :
                new ObjectParameter("TwitterProfileURL", typeof(string));
    
            var linkedinProfileURLParameter = linkedinProfileURL != null ?
                new ObjectParameter("LinkedinProfileURL", linkedinProfileURL) :
                new ObjectParameter("LinkedinProfileURL", typeof(string));
    
            var uploadDocumentNameParameter = uploadDocumentName != null ?
                new ObjectParameter("UploadDocumentName", uploadDocumentName) :
                new ObjectParameter("UploadDocumentName", typeof(string));
    
            var documentExtensionParameter = documentExtension != null ?
                new ObjectParameter("DocumentExtension", documentExtension) :
                new ObjectParameter("DocumentExtension", typeof(string));
    
            var documentFilePathParameter = documentFilePath != null ?
                new ObjectParameter("DocumentFilePath", documentFilePath) :
                new ObjectParameter("DocumentFilePath", typeof(string));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ssp_InsertReferralCompany", referralCompanyNameParameter, address1Parameter, address2Parameter, cityParameter, stateIdParameter, countryIdParameter, postalCodeParameter, mobileNumberParameter, officeNumberParameter, otherNumberParameter, faxParameter, emailAddressParameter, websiteParameter, referralTypeIdParameter, referralCategoryIdParameter, reasonParameter, facebookProfileURLParameter, twitterProfileURLParameter, linkedinProfileURLParameter, uploadDocumentNameParameter, documentExtensionParameter, documentFilePathParameter, createdByParameter);
        }
    
        public virtual int ssp_UpdateReferralCompany(Nullable<int> referralCompanyId, string referralCompanyName, string address1, string address2, string city, Nullable<int> stateId, Nullable<int> countryId, string postalCode, string mobileNumber, string officeNumber, string otherNumber, string fax, string emailAddress, string website, Nullable<int> referralTypeId, Nullable<int> referralCategoryId, string reason, string facebookProfileURL, string twitterProfileURL, string linkedinProfileURL, string uploadDocumentName, string documentExtension, string documentFilePath, Nullable<int> modifiedBy)
        {
            var referralCompanyIdParameter = referralCompanyId.HasValue ?
                new ObjectParameter("ReferralCompanyId", referralCompanyId) :
                new ObjectParameter("ReferralCompanyId", typeof(int));
    
            var referralCompanyNameParameter = referralCompanyName != null ?
                new ObjectParameter("ReferralCompanyName", referralCompanyName) :
                new ObjectParameter("ReferralCompanyName", typeof(string));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("Address1", address1) :
                new ObjectParameter("Address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("Address2", address2) :
                new ObjectParameter("Address2", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            var mobileNumberParameter = mobileNumber != null ?
                new ObjectParameter("MobileNumber", mobileNumber) :
                new ObjectParameter("MobileNumber", typeof(string));
    
            var officeNumberParameter = officeNumber != null ?
                new ObjectParameter("OfficeNumber", officeNumber) :
                new ObjectParameter("OfficeNumber", typeof(string));
    
            var otherNumberParameter = otherNumber != null ?
                new ObjectParameter("OtherNumber", otherNumber) :
                new ObjectParameter("OtherNumber", typeof(string));
    
            var faxParameter = fax != null ?
                new ObjectParameter("Fax", fax) :
                new ObjectParameter("Fax", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var websiteParameter = website != null ?
                new ObjectParameter("Website", website) :
                new ObjectParameter("Website", typeof(string));
    
            var referralTypeIdParameter = referralTypeId.HasValue ?
                new ObjectParameter("ReferralTypeId", referralTypeId) :
                new ObjectParameter("ReferralTypeId", typeof(int));
    
            var referralCategoryIdParameter = referralCategoryId.HasValue ?
                new ObjectParameter("ReferralCategoryId", referralCategoryId) :
                new ObjectParameter("ReferralCategoryId", typeof(int));
    
            var reasonParameter = reason != null ?
                new ObjectParameter("Reason", reason) :
                new ObjectParameter("Reason", typeof(string));
    
            var facebookProfileURLParameter = facebookProfileURL != null ?
                new ObjectParameter("FacebookProfileURL", facebookProfileURL) :
                new ObjectParameter("FacebookProfileURL", typeof(string));
    
            var twitterProfileURLParameter = twitterProfileURL != null ?
                new ObjectParameter("TwitterProfileURL", twitterProfileURL) :
                new ObjectParameter("TwitterProfileURL", typeof(string));
    
            var linkedinProfileURLParameter = linkedinProfileURL != null ?
                new ObjectParameter("LinkedinProfileURL", linkedinProfileURL) :
                new ObjectParameter("LinkedinProfileURL", typeof(string));
    
            var uploadDocumentNameParameter = uploadDocumentName != null ?
                new ObjectParameter("UploadDocumentName", uploadDocumentName) :
                new ObjectParameter("UploadDocumentName", typeof(string));
    
            var documentExtensionParameter = documentExtension != null ?
                new ObjectParameter("DocumentExtension", documentExtension) :
                new ObjectParameter("DocumentExtension", typeof(string));
    
            var documentFilePathParameter = documentFilePath != null ?
                new ObjectParameter("DocumentFilePath", documentFilePath) :
                new ObjectParameter("DocumentFilePath", typeof(string));
    
            var modifiedByParameter = modifiedBy.HasValue ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ssp_UpdateReferralCompany", referralCompanyIdParameter, referralCompanyNameParameter, address1Parameter, address2Parameter, cityParameter, stateIdParameter, countryIdParameter, postalCodeParameter, mobileNumberParameter, officeNumberParameter, otherNumberParameter, faxParameter, emailAddressParameter, websiteParameter, referralTypeIdParameter, referralCategoryIdParameter, reasonParameter, facebookProfileURLParameter, twitterProfileURLParameter, linkedinProfileURLParameter, uploadDocumentNameParameter, documentExtensionParameter, documentFilePathParameter, modifiedByParameter);
        }
    
        public virtual int Ssp_InsertUpdateRehabUsers(string aCTION, string dATAXML, string cREDXML, ObjectParameter output, Nullable<long> lONGVALUE1, Nullable<long> lONGVALUE2, Nullable<bool> bITVALUE1, Nullable<bool> bITVALUE2, string sTRINGVALUE1, string sTRINGVALUE2)
        {
            var aCTIONParameter = aCTION != null ?
                new ObjectParameter("ACTION", aCTION) :
                new ObjectParameter("ACTION", typeof(string));
    
            var dATAXMLParameter = dATAXML != null ?
                new ObjectParameter("DATAXML", dATAXML) :
                new ObjectParameter("DATAXML", typeof(string));
    
            var cREDXMLParameter = cREDXML != null ?
                new ObjectParameter("CREDXML", cREDXML) :
                new ObjectParameter("CREDXML", typeof(string));
    
            var lONGVALUE1Parameter = lONGVALUE1.HasValue ?
                new ObjectParameter("LONGVALUE1", lONGVALUE1) :
                new ObjectParameter("LONGVALUE1", typeof(long));
    
            var lONGVALUE2Parameter = lONGVALUE2.HasValue ?
                new ObjectParameter("LONGVALUE2", lONGVALUE2) :
                new ObjectParameter("LONGVALUE2", typeof(long));
    
            var bITVALUE1Parameter = bITVALUE1.HasValue ?
                new ObjectParameter("BITVALUE1", bITVALUE1) :
                new ObjectParameter("BITVALUE1", typeof(bool));
    
            var bITVALUE2Parameter = bITVALUE2.HasValue ?
                new ObjectParameter("BITVALUE2", bITVALUE2) :
                new ObjectParameter("BITVALUE2", typeof(bool));
    
            var sTRINGVALUE1Parameter = sTRINGVALUE1 != null ?
                new ObjectParameter("STRINGVALUE1", sTRINGVALUE1) :
                new ObjectParameter("STRINGVALUE1", typeof(string));
    
            var sTRINGVALUE2Parameter = sTRINGVALUE2 != null ?
                new ObjectParameter("STRINGVALUE2", sTRINGVALUE2) :
                new ObjectParameter("STRINGVALUE2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Ssp_InsertUpdateRehabUsers", aCTIONParameter, dATAXMLParameter, cREDXMLParameter, output, lONGVALUE1Parameter, lONGVALUE2Parameter, bITVALUE1Parameter, bITVALUE2Parameter, sTRINGVALUE1Parameter, sTRINGVALUE2Parameter);
        }
    
        public virtual ObjectResult<ssp_GetAllStates_Result> ssp_GetAllStates(Nullable<int> countryId)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllStates_Result>("ssp_GetAllStates", countryIdParameter);
        }
    
        public virtual ObjectResult<ssp_GetAllReferralCategory_Result> ssp_GetAllReferralCategory(Nullable<int> globalCodeId)
        {
            var globalCodeIdParameter = globalCodeId.HasValue ?
                new ObjectParameter("GlobalCodeId", globalCodeId) :
                new ObjectParameter("GlobalCodeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllReferralCategory_Result>("ssp_GetAllReferralCategory", globalCodeIdParameter);
        }
    
        public virtual ObjectResult<ssp_GetAllReferralCompanies_Result> ssp_GetAllReferralCompanies()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllReferralCompanies_Result>("ssp_GetAllReferralCompanies");
        }
    
        public virtual ObjectResult<ssp_GetAllReferralCompanyById_Result> ssp_GetAllReferralCompanyById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllReferralCompanyById_Result>("ssp_GetAllReferralCompanyById", idParameter);
        }
    
        public virtual ObjectResult<ssp_GetAllReferralContact_Result> ssp_GetAllReferralContact()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllReferralContact_Result>("ssp_GetAllReferralContact");
        }
    
        public virtual ObjectResult<ssp_GetAllReferralContactById_Result> ssp_GetAllReferralContactById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllReferralContactById_Result>("ssp_GetAllReferralContactById", idParameter);
        }
    
        public virtual ObjectResult<ssp_GetAllReferralSource_Result> ssp_GetAllReferralSource()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ssp_GetAllReferralSource_Result>("ssp_GetAllReferralSource");
        }
    }
}
