using BLL;
using Common;
using Common.Model;
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
        public ICompanyInfoRepository inforep { get; set; }
        CompanyCompareBll bll = new CompanyCompareBll();

        /// <summary>
        /// 比较公司数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<ChartModel, DBNull> CompanyCompare()
        {
            var result = new ApiResult<ChartModel, DBNull>();
            try
            {
                string compareClass = HttpContext.Current.Request["compareClass"];
                string Ids = HttpContext.Current.Request["Ids"];
                var detaillist = new List<CompanyDetails>();
                var infolist = new List<CompanyInfo>();
                var arryId = Ids.Split(',');

                foreach (string Id in arryId)
                {
                    detaillist.Add(rep.GetDetails(Convert.ToInt32(Id)));
                    infolist.Add(inforep.GetCompanyInfo(Convert.ToInt32(Id)));
                }

                result.obj = bll.CompanyCompare(compareClass, detaillist, infolist);
                result.success = true;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }

            return result;
        }
    }
}
