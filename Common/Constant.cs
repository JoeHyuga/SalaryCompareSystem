using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Constant
    {
        /// <summary>
        /// 养老保险比例
        /// </summary>
        public const double PensionPercent = 0.08;
        /// <summary>
        /// 医疗保险比例
        /// </summary>
        public const double MedicarePercent = 0.02;
        /// <summary>
        /// 失业保险比例
        /// </summary>
        public const double UnemployeePercent = 0.005;
        /// <summary>
        /// 公积金比例
        /// </summary>
        public const double HousingPercent = 0.12;
        /// <summary>
        /// 个税起征点
        /// </summary>
        public const double TaxPoint = 3500;

        public const double Under1500 = 0.03;

        public const double Over1500Under4500=0.1;

        public const double Over4500Under9000 = 0.2;
        public const double Over9000Under35000 = 0.25;
        public const double Over35000Under55000 = 0.3;
        public const double Over55000Under80000 = 0.35;
        public const double Over80000 = 0.45;
    }
}
