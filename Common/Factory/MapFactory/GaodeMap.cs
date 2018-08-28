using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Common.Factory.MapFactory
{
    public class GaodeMap:Map
    {
        /// <summary>
        /// 地址搜索
        /// </summary>
        /// <param name="address">关键词</param>
        /// <returns>json结果</returns>
        public override string SearchAddress(string address)
        {
            string url = "https://restapi.amap.com/v3/assistant/inputtips?";//关键字搜索API服务地址
            string key = WebConfigurationManager.AppSettings["MapKey"].ToString();//请求服务权限标识key
            var dic = new Dictionary<string, string>()
            {
                { "key",key},
                { "keywords",address}
            };
            //获得返回结果
            string json = Common.CommonMethod.Post(url, dic);
            return json;
        }
    }
}
