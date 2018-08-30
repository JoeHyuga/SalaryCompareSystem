using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class BaiduMapResult
    {
        public int status { get; set; }

        public string message { get; set; }

        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string name { get; set; }

        public Location location{get;set;}

        public string address { get; set; }

        public string province { get; set; }

        public string area { get; set; }

        public int detail { get; set; }

        public string uid { get; set; }
    }

    public class Location
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string lng { get; set; }
    }
}
