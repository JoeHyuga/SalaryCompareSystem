using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// 饼图数据返回类型
    /// </summary>
    public class PieStructure
    {
        public string[] labels { get; set; }

        public List<object> datasets { get; set; }
    }

    public class PieData
    {
        public int[] data { get; set; }

        public string[] backgroundColor { get; set; }
    }

    public class HoverBackgroundColor
    {
        public string[] hoverBackgroundColor { get; set; }
    }
}
