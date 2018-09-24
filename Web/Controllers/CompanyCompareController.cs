using BLL;
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
    public class CompanyCompareController : ApiController
    {
        public ICompanyInfoDetailsRepository rep { get; set; }
        CompanyCompareBll bll = new CompanyCompareBll();

        /// <summary>
        /// 比较公司数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<DBNull, DBNull> CompanyCompare()
        {
            var result = new ApiResult<DBNull, DBNull>();
            try
            {
                string compareClass = HttpContext.Current.Request["compareClass"];
                string Ids = HttpContext.Current.Request["Ids"];
                List<CompanyDetails> list = new List<CompanyDetails>();

                bll.CompanyCompare(compareClass, list);
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }

            return result;
        }
    }
}
