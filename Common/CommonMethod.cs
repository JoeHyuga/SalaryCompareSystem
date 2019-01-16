using Common.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class CommonMethod
    {
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/x-www-form-urlencoded";

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            request.ContentLength = data.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            //获取网页相应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="dic">参数</param>
        /// <returns></returns>
        public static string Get(string url, Dictionary<string, string> dic)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url+ builder.ToString());
            //添加参数
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }

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
            var salary = Convert.ToDouble(details.Salary) + Convert.ToDouble(details.MealAllowance) + Convert.ToDouble(details.TelAllowance) + Convert.ToDouble(details.HousingAllowance);
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
