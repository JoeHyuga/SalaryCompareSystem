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
    public class CompanyInfoController : ApiController
    {
        public ICompanyInfoRepository rep;

        public CompanyInfoController(ICompanyInfoRepository _rep)
        {
            rep = _rep;
        }

        [HttpGet]
        public ApiResult<DBNull, CompanyInfo> GetCompanyInfo()
        {
            var data=rep.GetCompanyInfo();
            var result = new ApiResult<DBNull, CompanyInfo>();
            result.rows = data;
            return result;
        }

        [HttpPost]
        public ApiResult<DBNull, DBNull> AddCompanyInfo()
        {
            string name= HttpContext.Current.Request["name"].ToString();
            string description = HttpContext.Current.Request["description"].ToString();
            string size= HttpContext.Current.Request["size"].ToString();
            string industry= HttpContext.Current.Request["industry"].ToString();
            string build= HttpContext.Current.Request["build"].ToString();
            string captial= HttpContext.Current.Request["captial"].ToString();
            string address= HttpContext.Current.Request["address"].ToString();
            CompanyInfo info = new CompanyInfo()
            {
                CompanyName = name,
                CompanyDescription = description,
                CompanySize = size,
                CompanyAddress = address,
                CompanyIndustry = industry,
                RegisteredCapital=captial,
                CompanyBuildDate=build
            };

            var result = new ApiResult<DBNull, DBNull>();
            result.success = rep.Add(info);

            return result;
        }
    }
}
