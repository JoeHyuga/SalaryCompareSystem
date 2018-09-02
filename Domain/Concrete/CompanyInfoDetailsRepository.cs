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
        public bool EditCompanyInfoDetails(CompanyDetails entity)
        {
            throw new NotImplementedException();
        }

        public CompanyDetails GetDetails(int Id)
        {
            var entity = db.dbCompanyDetails.Where(p => p.Id == Id).FirstOrDefault();
            return entity;
        }
    }
}
