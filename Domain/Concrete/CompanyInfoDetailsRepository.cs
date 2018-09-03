using Domain.IConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Concrete
{
    public class CompanyInfoDetailsRepository : ICompanyInfoDetailsRepository
    {
        EFDbContext db = new EFDbContext();
        public bool EditCompanyInfoDetails(CompanyDetails details)
        {
            var entity = GetDetails(details.CompanyId);
            if (entity == null)
            {
                db.dbCompanyDetails.Add(details);
            }
            else
            {
                entity.BaseSalary = details.BaseSalary;
                entity.Salary = details.Salary;
                entity.MealAllowance = details.MealAllowance;
                entity.TelAllowance = details.TelAllowance;
                entity.HousingAllowance = details.HousingAllowance;
                entity.FestivalAllowance = details.FestivalAllowance;
                entity.YearAward = details.YearAward;
                entity.RaiseSalaryTimes = details.RaiseSalaryTimes;
            }

            var i = db.SaveChanges();

            return i > 0 ? true : false;
        }

        public CompanyDetails GetDetails(int CompanyId)
        {
            var entity = db.dbCompanyDetails.Where(p => p.CompanyId == CompanyId).FirstOrDefault();
            return entity;
        }
    }
}
