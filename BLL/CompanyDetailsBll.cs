using Common;
using Common.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompanyDetailsBll
    {
        public AfterTaxSalary AfterTaxSalary(CompanyDetails details)
        {
            var baseSalary = Convert.ToDouble(details.BaseSalary);

            var afterTax = new AfterTaxSalary();

            //五险一金计算
            afterTax.WorkInjureInsuerance = 0;
            afterTax.UnemployeeInsuerance = 0;
            afterTax.HousingBenefit = baseSalary * Constant.HousingPercent;
            afterTax.MedicareInsuerance = baseSalary * Constant.MedicarePercent;
            afterTax.PensionInsuerance = baseSalary * Constant.PensionPercent;
            afterTax.UnemployeeInsuerance = baseSalary * Constant.UnemployeePercent;
            //总工资
            var salary = Convert.ToDouble(details.Salary)+Convert.ToDouble(details.MealAllowance)+Convert.ToDouble(details.TelAllowance)+Convert.ToDouble(details.HousingAllowance);
            //扣除五险一金
            var afterInsurance = salary - afterTax.HousingBenefit - afterTax.MedicareInsuerance - afterTax.PensionInsuerance - afterTax.UnemployeeInsuerance - afterTax.WorkInjureInsuerance - afterTax.UnemployeeInsuerance;
            afterTax.Tax = TaxCalculation(afterInsurance);
            afterTax.TaxSalary = afterInsurance - afterTax.Tax;
            return afterTax;
        }
        /// <summary>
        /// 税后工资计算
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public double TaxCalculation(double salary)
        {
            double tax = 0;
            salary = salary - Constant.TaxPoint;
            if (salary >= 1500)
            {
                tax += 1500 * Constant.Under1500;
                salary = salary - 1500;
            }

            if (1500 < salary && salary <= 4500)
            {
                tax += salary * Constant.Over1500Under4500;
            }
            else
            {
                tax += 4500 * Constant.Over1500Under4500;
                salary = salary - 4500;
                if (4500 < salary && salary <= 9000)
                {
                    tax += salary * Constant.Over4500Under9000;
                }
                else
                {
                    tax += 9000 * Constant.Over4500Under9000;
                    salary = salary - 9000;
                    if (9000 < salary && salary <= 35000)
                    {
                        tax += salary * Constant.Over9000Under35000;
                    }
                    else
                    {
                        tax += 35000 * Constant.Over9000Under35000;
                        salary = salary - 35000;
                        if (35000 < salary && salary <= 55000)
                        {
                            tax += salary * Constant.Over9000Under35000;
                        }
                        else
                        {
                            tax += 55000 * Constant.Over35000Under55000;
                            salary = salary - 55000;
                            if (55000 < salary && salary <= 80000)
                            {
                                tax += salary * Constant.Over55000Under80000;
                            }
                            else
                            {
                                tax += 80000 * Constant.Over55000Under80000;
                                salary = salary - 80000;
                                if (80000 < salary)
                                {
                                    tax += (salary - 80000) * Constant.Over80000;
                                }
                            }
                        }
                    }
                }
            }

            

            

            

           

            

            return tax;
        }
    }
}
