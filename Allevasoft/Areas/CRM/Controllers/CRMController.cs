using Allevasoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allevasoft.Areas.CRM.Controllers
{
    public class CRMController : Controller
    {
        // GET: CRM/CRM
        private readonly ICommonService _commonService;
        public CRMController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        #region Widget Section
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PartialViewResult CRMCalendar()
        {
            return PartialView("CRMCalendar");
        }
        public PartialViewResult CRMAppointment()
        {
            return PartialView("CRMAppointment");
        }
        public PartialViewResult CRMLeadStatus()
        {
            return PartialView("CRMLeadStatus");
        }
        public PartialViewResult CRMOpportunitySttatus()
        {
            return PartialView("CRMOpportunityStatus");
        }
        public PartialViewResult CRMClientStatus()
        {
            return PartialView("CRMClientStatus");
        }
        public PartialViewResult CRMDischargeStatus()
        {
            return PartialView("CRMDischargeStatus");
        }
        public PartialViewResult CRMReferalNotes()
        {
            return PartialView("CRMReferalNotes");
        }
        public PartialViewResult CRMBedStatus()
        {
            return PartialView("CRMBedStatus");

        }
        public PartialViewResult CRMMessages()
        {
            return PartialView("CRMMessages");
            
        }
        public PartialViewResult CRMNotificationsAlerts()
        {
            return PartialView("CRMNotificationsAlerts");

        }
        public JsonResult GetWidgetDetails(string actionParameter,string currentDate)
        {
            return Json( new {CRMDetails=_commonService.GetDashBoardDetails(actionParameter, currentDate) }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult DashBoard()
        {
            return View();
        }
       
        #region Referral
        public ActionResult ReferralCompany()
        {
            return View();
        }


        public JsonResult GetAllReferralCompany()
        {
            return Json(new { MSg = "Sucess", JsonRequestBehavior.AllowGet });
        }
        #endregion

    }
   
}