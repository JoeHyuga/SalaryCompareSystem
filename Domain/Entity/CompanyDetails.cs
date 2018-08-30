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
        public string OtherAllowance1 { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string OtherAllowance2 { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string OtherAllowance3 { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string OtherAllowance4 { get; set; }
        /// <summary>
        /// 其他补助
        /// </summary>
        public string OtherAllowance5 { get; set; }
    }
}
