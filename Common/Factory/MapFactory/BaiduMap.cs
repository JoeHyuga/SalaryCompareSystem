using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Common.Factory.MapFactory
{
    public class BaiduMap:Map
    {
        public override string SearchAddress(string address)
        {
            string url = "http://api.map.baidu.com/place/v2/search?";//关键字搜索API服务地址
            string key = WebConfigurationManager.AppSettings["MapKey"].ToString();//请求服务权限标识key
            var dic = new Dictionary<string, string>()
            {
                { "query",address},
                { "region","杭州"},
                { "output","json"},
                { "city_limit","true"},
                { "ak",key}
            };
            //获得返回结果
            string json = Common.CommonMethod.Get(url, dic);
            return json;
        }
    }
}
