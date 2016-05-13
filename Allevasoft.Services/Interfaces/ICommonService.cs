using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allevasoft.Entities.Classes;
using Allevasoft.Entities;

namespace Allevasoft.Services
{
    public interface ICommonService
    {
        long LogError(ErrorLog _error);
        List<ssp_GetAllMenu_Result> GetAllMenu();
        CRMDeatials GetDashBoardDetails(string actionParameter,string currentDate);

        List<LogInfo> GetAllLogList(int limit, int offset, string order, string sort, string SearchText, string ModuleName, string FieldName, string ModifiedBy, out int total);

        List<ssp_GetAllStates_Result> GetAllStates(int CountryId);

        List<Country> GetAllCountries();
    }
}
