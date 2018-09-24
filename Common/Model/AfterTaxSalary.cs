using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class AfterTaxSalary
    {
        /// <summary>
        /// 养老保险
        /// </summary>
        public double PensionInsuerance { get; set; }
        /// <summary>
        /// 医疗保险
        /// </summary>
        public double MedicareInsuerance { get; set; }
        /// <summary>
        /// 失业保险
        /// </summary>
        public double UnemployeeInsuerance { get; set; }
        /// <summary>
        /// 公积金
        /// </summary>
        public double HousingBenefit { get; set; }
        /// <summary>
        /// 生育保险
        /// </summary>
        public double MaternityInsuerance { get; set; }
        /// <summary>
        /// 工伤保险
        /// </summary>
        public double WorkInjureInsuerance { get; set; }
        /// <summary>
        /// 税后工资
        /// </summary>
        public double TaxSalary { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        public double Tax{ get; set; }
    }
}
