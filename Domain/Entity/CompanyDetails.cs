using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CompanyDetails
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        public string BaseSalary { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 工资
        /// </summary>
        [Required]
        public string Salary { get; set; }
        /// <summary>
        /// 餐补
        /// </summary>
        public string MealAllowance { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string TransportAllowance { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string HousingAllowance { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string FestivalAllowance { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string TelAllowance { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string OtherAllowance { get; set; }
        /// <summary>
        /// 年终奖
        /// </summary>
        public string YearAward { get; set; }
        /// <summary>
        /// 调薪次数
        /// </summary>
        public string RaiseSalaryTimes { get; set; }
    }
}
