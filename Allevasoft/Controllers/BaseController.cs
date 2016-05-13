using Allevasoft.Entities.Classes;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Allevasoft.Services;
using Allevasoft.Entities;

namespace Allevasoft.Controllers
{
    public class BaseController : Controller 
    {     
        /// <summary>
        /// return view as string 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new System.IO.StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        #region Custome Methods

        /// <summary>
        /// to return in json 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        [NonAction]
        public JsonResult ReturnJson<T>(T type)
        {
            JsonResult result = Json(type);
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        #endregion

        /// <summary>
        /// to rdirect on unauthorization
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Account", action = "Login" }));

        }

        /// <Summary>
        /// <Author>Sumit</Author>
        /// <CreatedOn>04/28/2016</CreatedOn>
        /// <Description>Handles all the exceptions ouccring in the application</Description>
        /// </Summary>
        /// <param name="objException"></param>        
        public void LogException(Exception objException)
        {
            System.Diagnostics.StackTrace objTrace = new System.Diagnostics.StackTrace(objException, true);
            String ErrorMessage = String.Empty;
            string CustomMessage = string.Empty;

            if (objTrace != null)            {
                
                String FileName = objTrace.GetFrame(0).GetFileName();
                ErrorMessage = "ControllerName = " + (FileName == null ? "" : FileName.Substring(FileName.LastIndexOf("\\") + 1))
                               + ", MethodName = " + objTrace.GetFrame(0).GetMethod().Name
                               + ", Line Number =" + objTrace.GetFrame(0).GetFileLineNumber()
                               + ", ColumnNumber = " + objTrace.GetFrame(0).GetFileColumnNumber()
                               + ", ErrorMessage:- " + objException.Message;
            }

           
            
            if (this.Request != null)
            {
                foreach (String item in this.Request.QueryString.AllKeys)
                    CustomMessage += "[" + item + " : " + Request.QueryString[item] + "], ";

                foreach (String item in this.Request.Form.AllKeys)
                    CustomMessage += "[" + item + " : " + Request.Form[item] + "], ";
            }

            LogExceptionIntoDatabase(objException, ErrorMessage, CustomMessage);
        }

        /// <Summary>
        /// <Author>Sumit</Author>
        /// <CreatedOn>04/28/2016</CreatedOn>
        /// <Description>Logs the exceptions into the database</Description>
        /// </Summary>
        /// <param name="objException"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="CustomMessage"></param>
        public void LogExceptionIntoDatabase(Exception objException, String ErrorMessage, String CustomMessage)
        {
            try
            {
               
                //ErrorLog errolog = new ErrorLog();
                //errolog.ExceptionType = exceptiontype;
                //errolog.ExceptionMessage = ErrorMessage;
                //errolog.CustomErrorMessage = CustomMessage;
                //errolog.CreatedDate = DateTime.Now;
                //errRepo.ErrorLogs.Add(errolog);
                //errRepo.SaveChanges();

            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// <Author>Sumit</Author>
        /// <CreatedOn>04/28/2016</CreatedOn>
        /// <Description>Logs the exception into the database </Description>
        /// </summary>
        /// <returns></returns>
        protected override void OnException(ExceptionContext filterContext)
        {
            LogException(filterContext.Exception);

            // Output a nice error page
            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                filterContext.ExceptionHandled = true;
                this.View("Error").ExecuteResult(this.ControllerContext);
            }
        }

    }
}
       
   