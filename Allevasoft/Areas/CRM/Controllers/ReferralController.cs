using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Allevasoft.Services;
using Allevasoft.Entities.Classes;

namespace Allevasoft.Areas.CRM.Controllers
{
    public class ReferralController : Controller
    {

        private readonly IReferralService _referralService;

        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;
        }
        

        // GET: CRM/Referral
        #region Referral_Companies

        public ActionResult Referral()
        {
            return View();
        }
        //List of Referral Type
        public JsonResult GetAllReferralType()
        {
            return Json(_referralService.GetAllReferralType().ToList(), JsonRequestBehavior.AllowGet);
        }

        //List of Referral Category
        public JsonResult GetAllReferralCategory(int TypeId)
        {
            return Json(_referralService.GetAllReferralCategory(TypeId).ToList(), JsonRequestBehavior.AllowGet);
        }

        //List of all Referral Company
        public JsonResult GetAllReferralCompany()
        {
            return Json(_referralService.GetAllReferralCompanies().ToList(), JsonRequestBehavior.AllowGet);
        }

        //List of all Referral Company By Id
        public JsonResult GetAllReferralCompanyById(int Id)
        {
            return Json(_referralService.GetAllReferralCompanyById(Id).ToList(), JsonRequestBehavior.AllowGet);
        }

        //List of all Referral Contact

        public JsonResult GetAllReferralContact()
        {
            return Json(_referralService.GetAllReferralContact().ToList(), JsonRequestBehavior.AllowGet);
        }

        //List of all Referral Contact By Id
        public JsonResult GetAllReferralContactById(int Id)
        {
            return Json(_referralService.GetAllReferralContactById(Id).ToList(), JsonRequestBehavior.AllowGet);
        }

        //Insert Referral Company
        public JsonResult InsertReferralCompany(ReferralCompany referralData)
        {
            return Json(_referralService.AddReferralCompany(referralData), JsonRequestBehavior.AllowGet);
        }

        //Update Referral Company
        public JsonResult UpdateReferralCompany(ReferralCompany referralData)
        {
            _referralService.UpdateReferralCompany(referralData);
            return Json(new { Msg = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Referral_Contact
        public ActionResult ReferralContact()
        {
            return View();
        }
        #endregion
    }
}