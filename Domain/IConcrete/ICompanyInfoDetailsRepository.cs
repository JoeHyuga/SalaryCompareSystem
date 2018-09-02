using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IConcrete
{
    public interface ICompanyInfoDetailsRepository
    {
        /// <summary>
        /// 编辑详情
        /// </summary>
        bool EditCompanyInfoDetails(CompanyDetails entity);
        /// <summary>
        /// 获取详情
        /// </summary>
        CompanyDetails GetDetails(int Id);
    }
}
