﻿using System;
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
        public ChartModel CompanyCompare(List<CompanyDetails> details, List<CompanyInfo> infos)
        {
            var model = new ChartModel();
            model.title = "before";
            model.xName = "m";
            model.xData = new string[] { "S","Base","meal"};
            model.yName = "项目";
            var serieslist = new List<series>();
            foreach (CompanyDetails detail in details)
            {
                var s = new series();
                s.name = infos.Where(p => p.Id == detail.CompanyId).ToList()[0].CompanyName;
                s.type = "bar";
                s.data = new string[] { detail.Salary, detail.BaseSalary, detail.MealAllowance };
                serieslist.Add(s);
            }
            model.series =serieslist;
            return model;
        }
    }
}
