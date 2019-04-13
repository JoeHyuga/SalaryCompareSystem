using Common.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Strategy.CompanyCompareStrategy
{
    public class CompareTemplate
    {
        private ICompanyCompare _comparable = null;
        private static CompareTemplate _compareTemplate;
        private static object lockObj = new object();

        private CompareTemplate(ICompanyCompare comparable)
        {
            this._comparable = comparable;
        }

        public static CompareTemplate CreateComparable(ICompanyCompare compare)
        {
            //if (null == _compareTemplate)
            //{
            //    lock (lockObj)
            //    {
            //        if (null == _compareTemplate)
            //        {
            //            _compareTemplate = new CompareTemplate(compare);
            //        }
            //    }
            //}
            _compareTemplate = new CompareTemplate(compare);
            return _compareTemplate;
        }

        public void SetCompare(ICompanyCompare setCompare)
        {
            this._comparable = setCompare;
        }

        public ChartModel Compare(List<CompanyDetails> Ids,List<CompanyInfo> infos)
        {
            return this._comparable.CompanyCompare(Ids,infos);
        }
    }
}
