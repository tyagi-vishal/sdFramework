using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allevasoft.Common
{
    public enum UserLoginMessage
    {
        NotExits = 0,
        InActive = 1,
        IsDeleted = 2,
        ValidUser = 3
    }
    public enum GenderType
    {
        Male = 1,
        Female = 2
    }
    public enum RelationshipStatus
    {
        Single = 1,
        Married = 2
    }

    public struct SiteMessages
    {
        public static string AddUser = "User Added Successfully";
        
    }

    public enum SessionsNames
    {
        CurrentUser,
        CurrentDomain,
        IsSecurityQuestionVerification
    }


    //All Controller page urls    
    public struct PageUrls
    {
        public static string userListGrid = "SettingsAPI/GetUserList";
    }
     
}

