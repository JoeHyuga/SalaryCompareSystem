using Domain.IConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Concrete
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        EFDbContext db = new EFDbContext();

        public bool Add(CompanyInfo company)
        {
            db.CompanyInfo.Add(company);
            var i= db.SaveChanges();

            return i > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            var entity = GetCompanyInfo(id);
            db.CompanyInfo.Remove(entity);
            var i = db.SaveChanges();

            return i > 0 ? true : false;
        }

        public CompanyInfo GetCompanyInfo(int id)
        {
            var entity = db.CompanyInfo.Where(p => p.Id == id).FirstOrDefault();
            return entity;
        }

        public List<CompanyInfo> GetCompanyInfo()
        {
            var info = db.CompanyInfo.ToList();
            return info;
        }

        public void Update(CompanyInfo company)
        {
            throw new NotImplementedException();
        }
    }
}
