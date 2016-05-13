using Allevasoft.Common.Helper;
using Allevasoft.Entities.Classes;
using Allevasoft.Entities.PartialClass;
using Allevasoft.Filters;
using Allevasoft.Models;
using Allevasoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allevasoft.Areas.CRM.Controllers
{
    [Authorize]
    public class LeadController : Controller
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        // GET: CRM/Lead
        public ActionResult QuickIntake()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        // [AntiforgeryValidate]
        public JsonResult SaveLeadInfo(LeadInfo leadInfo)
        {
            CommonObjects _objectCommon = new CommonObjects();
            LoggedUserInformationModel objectLoggedUserInformationModal = _objectCommon.GetCuntUserModel();

            leadInfo.Prefix = "Mr.";
            leadInfo.Gender = 1017;
            leadInfo.DateOfBirth = DateTime.UtcNow;         
            leadInfo.CreatedBy = objectLoggedUserInformationModal.LoginUserId;
            leadInfo.CreatedDate = DateTime.UtcNow;

            int newLeadId = _leadService.AddLead(leadInfo);
            string response = "";
            if (newLeadId > 0)
                response = "Success";
            else
                response = "Error";
            return Json(new { Message = response, Status = true }, JsonRequestBehavior.AllowGet);
        //public string Address1 { get; set; }
        //public string Address2 { get; set; }
        //public string City { get; set; }  
        //public string ContactFirstName { get; set; }
        //public string ContactLastName { get; set; }
        //public string ContactPhoneNumber { get; set; }
        //public Nullable<System.DateTime> LastContactDate { get; set; }
        //public string IsAuthorized { get; set; }
        //public string IsMoved { get; set; }
        //public Nullable<System.DateTime> MovedLeadClientDate { get; set; }
        
       
       // public Nullable<System.DateTime> ModifiedDate { get; set; }
       // public bool IsDeleted { get; set; }
       // public Nullable<System.DateTime> DeletedDate { get; set; }
     

    }
    }
}