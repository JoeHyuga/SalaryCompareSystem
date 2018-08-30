using BLL;
using Common;
using Common.Model;
using Domain.Entity;
using Domain.IConcrete;
using Newtonsoft.Json;
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
        public ICompanyInfoRepository rep { get; set; }

        [HttpGet]
        public ApiResult<DBNull, CompanyInfo> GetCompanyInfoes()
        {
            var result = new ApiResult<DBNull, CompanyInfo>();
            try
            {
                result.rows = rep.GetCompanyInfo();
                result.success = true;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        public ApiResult<CompanyInfo, DBNull> GetCompanyInfo()
        {
            var result = new ApiResult<CompanyInfo, DBNull>();
            try
            {
                string Id = HttpContext.Current.Request["Id"].ToString();
                var obj = rep.GetCompanyInfo(Convert.ToInt32(Id));
                result.obj = obj;
                result.success = true;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }

            return result;
        }

        [HttpPost]
        public ApiResult<DBNull, DBNull> AddCompanyInfo()
        {
            string id = HttpContext.Current.Request["id"].ToString();
            int iid = string.IsNullOrEmpty(id) ? -1 : Convert.ToInt32(id);
            string name = HttpContext.Current.Request["name"].ToString();
            string description = HttpContext.Current.Request["description"].ToString();
            string size = HttpContext.Current.Request["size"].ToString();
            string industry = HttpContext.Current.Request["industry"].ToString();
            string build = HttpContext.Current.Request["build"].ToString();
            string captial = HttpContext.Current.Request["captial"].ToString();
            string address = HttpContext.Current.Request["address"].ToString();
            string location = HttpContext.Current.Request["xy"].ToString();
            CompanyInfo info = new CompanyInfo()
            {
                Id = iid,
                CompanyName = name,
                CompanyDescription = description,
                CompanySize = size,
                CompanyAddress = address,
                CompanyIndustry = industry,
                RegisteredCapital = captial,
                CompanyBuildDate = build,
                CompanyLocation=location
            };

            var result = new ApiResult<DBNull, DBNull>();
            result.success = rep.Add(info);

            return result;
        }

        [HttpPost]
        public ApiResult<DBNull, DBNull> DeleteCompanyInfo()
        {
            var result = new ApiResult<DBNull, DBNull>();
            try
            {
                string Ids = HttpContext.Current.Request["Ids"].ToString();
                var arryId = Ids.Split(',');
                var bresult = true;
                for (int i = 0; i < arryId.Length; i++)
                {
                    bresult = bresult & rep.Delete(Convert.ToInt32(arryId[i]));
                }
                result.success = bresult;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        public ApiResult<DBNull, DBNull> UpdateCompanyInfo()
        {
            var result = new ApiResult<DBNull, DBNull>();
            return result;
        }

        [HttpPost]
        public ApiResult<DBNull, Result> SearchAddress()
        {
            var result = new ApiResult<DBNull, Result>();
            try
            {
                string keywords = HttpContext.Current.Request["keywords"].ToString();
                if (string.IsNullOrEmpty(keywords))
                {
                    result.success = false;
                    result.message = "地址不能为空";
                }
                else
                {
                    var map=CompanyBll.SearchAddress(keywords);
                    if (map.status == "0")
                    {
                        result.rows = map.list;
                        result.success = true;
                    }
                    else
                    {
                        result.success = false;
                        result.message = map.message;
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
            }
            return result;
        }
    }
}
