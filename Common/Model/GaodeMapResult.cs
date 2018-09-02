using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class GaodeMapResult
    {
        /// <summary>
        /// 结果状态值 0：请求失败；1：请求成功
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 返回状态说明 status为0时，info返回错误原因，否则返回“OK”。
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 搜索数目
        /// </summary>
        public string count { get; set; }

        public List<Tips> tips { get; set; }
    }

    public class Tips
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public object id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public object address { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 区域编码
        /// </summary>
        public string adcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string typecode { get; set; }
    }
}
