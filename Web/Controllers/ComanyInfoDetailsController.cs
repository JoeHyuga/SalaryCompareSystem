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
    public class ComanyInfoDetailsController : ApiController
    {
        public ICompanyInfoDetailsRepository rep { get; set; }
        CompanyDetailsBll bll = new CompanyDetailsBll();

        [HttpPost]
        public ApiResult<DBNull, DBNull> CompanyInfoDetailsEdit()
        {
            var result = new ApiResult<DBNull, DBNull>();
            try
            {
                var bsalary = HttpContext.Current.Request["bsalary"];
                var salary = HttpContext.Current.Request["salary"];
                var meal = HttpContext.Current.Request["meal"];
                var tel = HttpContext.Current.Request["tel"];
                var transport = HttpContext.Current.Request["transport"];
                var housing = HttpContext.Current.Request["housing"];
                var festival = HttpContext.Current.Request["festival"];
                var yearaward = HttpContext.Current.Request["yearaward"];
                var changetimes = HttpContext.Current.Request["changetimes"];
                var id = HttpContext.Current.Request["Id"];
                var details = new CompanyDetails()
                {
                    CompanyId=Convert.ToInt32(id),
                    BaseSalary = bsalary,
                    Salary=salary,
                    MealAllowance=meal,
                    TelAllowance=tel,
                    TransportAllowance=transport,
                    HousingAllowance=housing,
                    FestivalAllowance=festival,
                    YearAward=yearaward,
                    RaiseSalaryTimes=changetimes
                };

                result.success=rep.EditCompanyInfoDetails(details);
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        public ApiResult<CompanyDetails, DBNull> GetDetails()
        {
            var result = new ApiResult<CompanyDetails, DBNull>();
            try
            {
                var Id = HttpContext.Current.Request["Id"];
                var details = rep.GetDetails(Convert.ToInt32(Id));
                result.obj = details;
                result.success = true;
            }
            catch (Exception ex)
            { result.message = ex.Message; }

            return result;
        }
        /// <summary>
        /// 计算税后工资
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<AfterTaxSalary, DBNull> AfterTaxSalary()
        {
            var result = new ApiResult<AfterTaxSalary, DBNull>();
            try
            {
                var Id = HttpContext.Current.Request["Id"];
                var details = rep.GetDetails(Convert.ToInt32(Id));
                result.obj = bll.AfterTaxSalary(details);
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
