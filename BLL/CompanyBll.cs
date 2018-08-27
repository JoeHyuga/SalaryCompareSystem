using Common;
using Common.Model;
using Domain.Entity;
using Domain.IConcrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BLL
{
    public class CompanyBll
    {

        /// <summary>
        /// 用高德地图api搜索地点
        /// </summary>
        /// <param name="address">搜索地点</param>
        public static MapSearchResult SearchAddress(string address)
        {
            string url = "https://restapi.amap.com/v3/assistant/inputtips?";//关键字搜索API服务地址
            string key = WebConfigurationManager.AppSettings["MapKey"].ToString();//请求服务权限标识key
            var dic = new Dictionary<string, string>()
            {
                { "key",key},
                { "keywords",address}
            };
            //获得返回结果
            string json=Common.CommonMethod.Post(url,dic);
            //将结果反序列化为实体
            var result = JsonConvert.DeserializeObject<MapSearchResult>(json);
            return result;
        }
    }
}
