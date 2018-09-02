using Common;
using Domain.Entity;
using Domain.IConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class ComanyInfoDetailsController : ApiController
    {
        public ICompanyInfoDetailsRepository rep { get; set; }

        public ICompanyInfoRepository repInfo { get; set; }

        [HttpPost]
        public ApiResult<DBNull, DBNull> CompanyInfoDetailsEdit()
        {
            var result = new ApiResult<DBNull, DBNull>();
            try
            {

            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        public ApiResult<CompanyDetails, CompanyInfo> GetDetails()
        {
            var result = new ApiResult<CompanyDetails, CompanyInfo>();
            try
            {
                var Id = HttpContext.Current.Request["Id"];
                var details = rep.GetDetails(Convert.ToInt32(Id));
                var info = new List<CompanyInfo>() { repInfo.GetCompanyInfo(Convert.ToInt32(Id)) } ;

                result.obj = details;
                result.rows = info;
                result.success = true;
            }
            catch (Exception ex)
            { result.message = ex.Message; }

            return result;
        }
    }
}
