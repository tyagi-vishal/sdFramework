using Allevasoft.Entities.Classes;
using Allevasoft.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AllevasoftWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:64041", headers: "*", methods: "*")]
    public class HomeAPIController : ApiController
    {

       // private readonly ICommonService _commonService;
       // private readonly ILeadService _leadService;

        public HomeAPIController() {
           // _commonService = new CommonService();
           // _leadService = new LeadService();
        }
        //public HomeAPIController(ICommonService commonService, ILeadService leadService)
        //{
        //    _commonService = commonService;
        //    _leadService = leadService;
        //}

        // get data for audit log API call

        #region Audit Log        
        [HttpPost]
        [ActionName("GetLogList")]
        public dynamic GetLogList(JObject Obj)
        {
            CommonService objC = new CommonService();

            LogInfoListFilters filter = Obj.ToObject<LogInfoListFilters>();
            int total;
            LogInfoReturnVal Lg = new LogInfoReturnVal();
            Lg.LogsData = objC.GetAllLogList(filter.limit, filter.offset, filter.order, filter.sort, filter.SearchText, filter.ModuleName, filter.FieldName, filter.ModifiedBy, out total);
            var result = new
            {
                total = total,
                rows = Lg.LogsData,
            };
            return result;
        }
        #endregion

        #region Lead

        //[HttpPost]
        //[ActionName("GetLeadList")]
        //public dynamic GetLeadList(JObject Obj)
        //{
        //    LeadInfoListFilters filter = Obj.ToObject<LeadInfoListFilters>();
        //    int total;
        //    LeadInfoReturnVal Lg = new LeadInfoReturnVal();
        //    Lg.LeadData = _leadService.GetLeadsList(filter.limit, filter.offset, filter.order, filter.sort, filter.SearchText,filter.FirstName,filter.LastName, out total);
        //    var result = new
        //    {
        //        total = total,
        //        rows = Lg.LeadData,
        //    };
        //    return result;
        //}

        #endregion
    }
}