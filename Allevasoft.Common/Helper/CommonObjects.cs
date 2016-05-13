using Allevasoft.Entities.PartialClass;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allevasoft.Common.Helper
{
    public class CommonObjects
    {

        /// <summary>
        /// Convert Existing session value into XMl
        /// </summary>
        /// <createdBy>Neeraj Sharma</createdBy>
        /// <On>May, 10 2016</On>
        /// <returns>XML</returns>
        public string GetCuntUserXml()
        {
            string msg;
            try
            {
                HttpContext currentContext = System.Web.HttpContext.Current;
                var currentUser = (LoggedUserInformationModel)HttpContext.Current.Session[SessionsNames.CurrentUser.ToString()];
                if (currentUser == null)
                {
                    currentUser = new LoggedUserInformationModel().GetAnonymousUser();
                }
                msg = ExtensionMethod.ConvertToXml<LoggedUserInformationModel>(currentUser);
            }
            catch (Exception)
            {
                msg = "";
            }

            return msg;
        }

        /// <summary>
        /// Convert Existing session value into Modal 
        /// </summary>
        /// <createdBy>Neeraj Sharma</createdBy>
        /// <On>May, 10 2016</On>
        /// <returns>Model</returns>
        public LoggedUserInformationModel GetCuntUserModel()
        {
            LoggedUserInformationModel currentUser = new LoggedUserInformationModel();

            HttpContext currentContext = System.Web.HttpContext.Current;
            currentUser = (LoggedUserInformationModel)HttpContext.Current.Session[SessionsNames.CurrentUser.ToString()];
            if (currentUser == null)
            {
                currentUser = new LoggedUserInformationModel().GetAnonymousUser();
            }
            return currentUser;
        }
    }
}
