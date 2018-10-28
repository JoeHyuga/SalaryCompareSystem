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
        public List<ChartModel> CompanyCompare(List<CompanyDetails> list)
        {
            List<ChartModel> modelList = new List<ChartModel>();
            var yearData =new int[list.Count];
            var salaryData = new int[list.Count];
            var mealData = new int[list.Count];

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
