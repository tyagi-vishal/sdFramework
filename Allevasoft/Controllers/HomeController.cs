using System.Linq;
using System.Web.Mvc;
using Allevasoft.Services;
using System.Web.Configuration;
using Allevasoft.Common.Helper;
using Allevasoft.Entities.PartialClass;

namespace Allevasoft.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICommonService _commonService;
        CommonObjects _objectCommon = null;
        public HomeController()
        {

        }

        //Parameterised contructor for call Home Controller
        public HomeController(ICommonService commonService)
        {
            _commonService = commonService;
        }


        //Used for render dashboard view
        public ActionResult Dashboard()
        {
            return View();
        }

        #region Menu_Binding

        //Used for get list of all menus and submenus item from database  
        public ActionResult GetAllMenus()
        {
            return Json(_commonService.GetAllMenu().ToList(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// To view audit log 
        /// </summary>
        /// <returns></returns>
        public ActionResult AuditLog()
        {
            ViewBag.WebServiceURL = WebConfigurationManager.AppSettings["WebServiceURL"] + "HomeAPI/GetLogList";
            //string cookieToken, formToken;
            //AntiForgery.GetTokens(null, out cookieToken, out formToken);
            //ViewBag.Token= cookieToken + ":" + formToken;
            return View();
        }
        #endregion


        /// <summary>
        /// This is get the logged user information, Like image, name and Role
        /// </summary>
        /// <AddedBy>Neeraj Sharma</AddedBy>
        /// <on>May, 11 2016</on>
        /// <returns>Model to view</returns>
        [ChildActionOnly]
        public ActionResult LoadloggedUserInfo()
        {
            _objectCommon = new CommonObjects();
             LoggedUserInformationModel objectLoggedUserInformationModal = _objectCommon.GetCuntUserModel();
            
            return View("_LoggedUserInfo", objectLoggedUserInformationModal);
        }

        #region Get_Countries
        public JsonResult GetAllCountries()
        {
            return Json(_commonService.GetAllCountries().ToList(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get_State

        public JsonResult GetAllStates(int CountryId)
        {
            return Json(_commonService.GetAllStates(CountryId).ToList(), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}