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
        /// <summary>
        /// 工资饼图数据
        /// </summary>
        /// <param name="details">公司详情</param>
        /// <returns></returns>
        public List<PieStructure> SalaryPie(CompanyDetails details)
        {
            var list = new List<PieStructure>();

            string[] arryLabels = { "基本工资", "餐补", "交通补助", "住房补助", "节日补助", "话补", "年终奖" };
            var pieDate = new PieData()
            {
                data = new int[]
                {
                    Convert.ToInt32(details.Salary),
                    Convert.ToInt32(details.MealAllowance),
                Convert.ToInt32(details.TransportAllowance),
                Convert.ToInt32(details.HousingAllowance),
                Convert.ToInt32(details.FestivalAllowance),
                 Convert.ToInt32(details.TelAllowance),
                 Convert.ToInt32(details.YearAward)
                },
                backgroundColor = new string[]
                {
                    "#F7464A","#46BFBD","#FDB45C","#EE9A00","#E8E8E8","#CAE1FF","#8470FF"
                }
            };

            var hoverBackgroundColor = new HoverBackgroundColor();

            var pie = new PieStructure()
            {
                labels = arryLabels,
                datasets = new List<object>() { pieDate, hoverBackgroundColor }
            };
            list.Add(pie);
            return list;
        }
    }
}
