using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Allevasoft.Entities.PartialClass
{
    public class LoggedUserInformationModel
    {

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        /// <value>
        /// The user ID.
        /// </value>

        public Guid UserId { get; set; }

        public string Language
        {
            get { return _language; }
            set
            {
                if (value == null)
                {
                    value = "es-ES";
                }
                _language = value;
            }
        }
        /// <summary>
        /// Gets or sets the login user ID.
        /// </summary>
        /// <value>
        /// The login user ID.
        /// </value>

        public int LoginUserId { get; set; }



        /// <summary>
        /// Gets or sets the company ID.
        /// </summary>
        /// <value>
        /// The company ID.
        /// </value>

        public int facilityId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>


        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                _lastName = value;
            }
        }



        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>

        public string Email
        {
            get { return _email; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                _email = value;
            }
        }
        public string RoleType { get; set; }

        public int? RoleTypeId { get; set; }

        public string Domain { get; set; }

        public string TimeZoneName
        {
            get { return _timezonename; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                _timezonename = value;
            }
        }

        /// <summary>
        /// Gets or sets the user ip.
        /// </summary>
        /// <value>
        /// The user ip.
        /// </value>

        public string UserIp
        {
            get
            {
                var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ip != null)
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
                else
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            set { }
        }

        public string Address1 { get; set; }

        public int ClientTimeOffset
        {
            get
            {
                if (HttpContext.Current.Session["G_CLIENT_TIME_ZONE_OFFSET"] == null)
                {
                    HttpContext.Current.Session["G_CLIENT_TIME_ZONE_OFFSET"] = -240;
                }
                return ((int)HttpContext.Current.Session["G_CLIENT_TIME_ZONE_OFFSET"]);
            }
            set
            {
            }
        }


        /// <summary>
        /// The _timezonename
        /// </summary>
        private string _timezonename;

        private string _email;

        /// <summary>
        /// The _first name
        /// </summary>
        private string _firstName;

        /// <summary>
        /// The _last name
        /// </summary>
        private string _lastName;

        private string _language;

        public LoggedUserInformationModel GetAnonymousUser()
        {

            return new LoggedUserInformationModel
            {
                Address1 = "",
                facilityId = -1,
                TimeZoneName = "",
                RoleTypeId=-1,
                Domain = "/",
                Email = "",
                FirstName = "",
                LastName = "",
                UserId = new Guid()
            };
        }
    }
}