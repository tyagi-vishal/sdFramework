using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Allevasoft.Models;
using Allevasoft.Filters;
using Allevasoft.Services;
using Allevasoft.Entities.PartialClass;
using Allevasoft.Common;
using Allevasoft.Common.Helper;

namespace Allevasoft.Controllers
{
    [AllowAnonymous]

    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private UserService _userService = null;
        public AccountController()
        {

        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        #region Login Section
        /// <summary>
        /// This method is used to return login view
        /// </summary>
        /// <returns>View</returns>
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            //string returnUrl
            //ViewBag.ReturnUrl = returnUrl;
            if (User.Identity.IsAuthenticated == true)
            {
             return RedirectToAction("DashBoard", "CRM",new {area="CRM"});
            }
            ViewBag.Title = "Login";
            return View();
        }
        /// <summary>
        /// For Authenticating Client
        /// </summary>
        /// <param name="Modal"></param>
        /// <modifiedBy>Neeraj Sharma</modifiedBy>
        /// <On>May 10, 2016</On>
        /// <returns>Json(new { Message = result, Status = true }, JsonRequestBehavior.AllowGet);</returns>
        [HttpPost]
        [Authorize]
        [AntiforgeryValidate]
        public JsonResult Authenticate(LoginViewModel Modal)
        {
            string userName = string.Empty;
            string res = LoginAPI(Modal).Result;
            if (res == "Success")
            {
                _userService = new UserService();
                var GetLoginuserDetails = _userService.GetLoggedUserInformation(Modal.UserName.Trim());
                HttpContext currentContext = System.Web.HttpContext.Current;
                currentContext.Session[SessionsNames.CurrentUser.ToString()] = GetLoginuserDetails; 
                
            }
            return Json(new { Message = res, Status = true }, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// This method is called by Authenticate(LoginViewModel Modal)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>return status</returns>
        //
        // POST: /Account/Login
        [HttpPost]

        public async Task<string> LoginAPI(LoginViewModel model)

        {
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);

            switch (result)
            {

                case SignInStatus.Success:
                    return "Success";
                case SignInStatus.LockedOut:
                    return "LockedOut";
                case SignInStatus.RequiresVerification:
                    return "RequiresVerification";
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return "Error";
            }
        }

        #endregion
        #region For Registering user

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //  var userUpdateRecord =

                    // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion
        #region For Email Confirmation
        /// <summary>
        /// Confirm Email
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns>View(result.Succeeded ? "ConfirmEmail" : "Error");</returns>
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        #endregion
        #region For Forgot Password

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ForgotPassword(ForgotPasswordViewModel Modal)
        {
            var result = Task.Run(() => { return ForgotPasswordMail(Modal); });
            //return Json(new { Message = "Success", Status = true }, JsonRequestBehavior.AllowGet);
            return Json(new { Message = "Success", Status = true }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        ///  For send mail link to user to reset password
        /// </summary>
        /// <param name="model">ForgotPasswordViewModel</param>
        /// <returns>Json(new { Message = "Success", Status = true }, JsonRequestBehavior.AllowGet);</returns>
        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        public async Task<ActionResult> ForgotPasswordMail(ForgotPasswordViewModel model)
        {

            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                //return View("ForgotPasswordConfirmation");
                return Json(new { Message = "NotRegistered", Status = true }, JsonRequestBehavior.AllowGet);
            }

            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            // Send an email with this link
            string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
            return Json(new { Message = "Success", Status = true }, JsonRequestBehavior.AllowGet);

            // If we got this far, something failed, redisplay form
            // return View();
        }
        /// <summary>
        /// for Confirmation of Forgot Password
        /// </summary>
        /// <returns>View</returns>
        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        /// <summary>
        /// Reset Password View
        /// </summary>
        /// <param name="code"></param>
        /// <returns>code == null ? View("Error") : View()</returns>
        //
        // GET: /Account/ResetPassword
        [Authorize]
        public ActionResult ResetPassword(string code)
        {
            ViewBag.Code = code;
            return code == null ? View("Error") : View();
        }
        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="model">ResetPasswordViewModel</param>
        /// <returns> diffren status ...not register, success,Failed</returns>
        //
        // POST: /Account/ResetPassword
        [HttpPost]

        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Json(new { Message = "Not Register", Status = true }, JsonRequestBehavior.AllowGet);
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Json(new { Message = "Success", Status = true }, JsonRequestBehavior.AllowGet);
            }
            AddErrors(result);
            return Json(new { Message = "Failed", Status = true }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Reset Password Confirmation View
        /// </summary>
        /// <returns>View</returns>
        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #endregion
        #region Log Out
        /// <summary>
        /// LogOff user
        /// </summary>
        /// <returns>RedirectToAction("Login")</returns>
        //
        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

        #endregion
        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }


        #endregion
    }
}