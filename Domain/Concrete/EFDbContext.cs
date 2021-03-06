﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("name=EFDbContext")
        { }
        public DbSet<CompanyInfo> dbCompanyInfo { get; set; }

        public DbSet<CompanyDetails> dbCompanyDetails { get; set; }
    }
}
