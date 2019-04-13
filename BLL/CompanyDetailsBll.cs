using Common;
using Common.Model;
using Common.Strategy.CompanyCompareStrategy;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompanyDetailsBll
    {
        public AfterTaxSalary AfterTaxSalary(CompanyDetails details)
        {
            return new Common.CommonMethod().AfterTaxSalary(details);
        }
    }
}
