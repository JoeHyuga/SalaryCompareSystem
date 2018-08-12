using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CompanyInfo
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
        [Required]
        public string CompanySize { get; set; }
        [Required]
        public string CompanyIndustry { get; set; }
        [Required]
        public string CompanyBuildDate { get; set; }
        [Required]
        public string RegisteredCapital { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
    }
}
