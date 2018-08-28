using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Factory.MapFactory
{
    public abstract class Map
    {
        /// <summary>
        /// 地址搜索
        /// </summary>
        /// <param name="address">关键词</param>
        /// <returns>json结果</returns>
        public abstract string SearchAddress(string address);
    }
}
