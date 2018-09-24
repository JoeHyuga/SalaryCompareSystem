using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Common.Model;

namespace Common.Strategy.CompanyCompareStrategy
{
    public class BeforeTaxSalaryCompare : ICompanyCompare
    {
        public List<ChartBarModel> CompanyCompare(List<CompanyDetails> list)
        {
            List<ChartBarModel> modelList = new List<ChartBarModel>();
            var yearData =new int[modelList.Count];
            var salaryData = new int[modelList.Count];
            var mealData = new int[modelList.Count];

            for (int i = 0; i < list.Count; i++)
            {
                yearData[i] = Convert.ToInt32(list[i].YearAward);
                salaryData[i]= Convert.ToInt32(list[i].Salary);
                mealData[i] = Convert.ToInt32(list[i].MealAllowance);
            }
            modelList.Add(new ChartBarModel()
            {
                name = "年终奖",
                type = "bar",
                barGap = 0,
                data = yearData
            });

            modelList.Add(new ChartBarModel()
            {
                name = "工资",
                type = "bar",
                barGap = 0,
                data = salaryData
            });

            modelList.Add(new ChartBarModel()
            {
                name = "餐补",
                type = "bar",
                barGap = 0,
                data = mealData
            });

            return modelList;
        }
    }
}
