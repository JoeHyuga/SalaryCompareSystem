using Common.Model;
using Common.Strategy.CompanyCompareStrategy;
using Domain.Entity;
using Domain.IConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompanyCompareBll
    {
        public ChartModel CompanyCompare(string compareClass,List<CompanyDetails> list)
        {
            var template = CompareTemplate.CreateComparable(new BeforeTaxSalaryCompare());

            switch (compareClass)
            {
                case "AfterTaxSalaryCompare":
                    template = CompareTemplate.CreateComparable(new AfterTaxSalaryCompare());
                    break;
                case "BeforeTaxSalaryCompare":
                    template = CompareTemplate.CreateComparable(new BeforeTaxSalaryCompare());
                    break;
            }

            var result= template.Compare(list);
            return result;
        }
    }
}
