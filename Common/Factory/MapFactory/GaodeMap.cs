using Common.Model;
using Newtonsoft.Json;
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

        /// <summary>
        /// 将json数据反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override MapResult  JsonToEntity(string json)
        {
            //反序列化
            var map = JsonConvert.DeserializeObject<GaodeMapResult>(json);

            //转换为通用结果
            var result = new MapResult();
            result.count = map.count;
            result.status = map.status=="1"?"0":"1";//百度地图api接口成功判断与高德地图相反
            result.message = map.info;
            var list = new List<Result>();
            foreach (var item in map.tips)
            {
                //搜索结果
                var i = new Result();
                i.name = item.name;
                i.location = item.loaction==null? new Location() { lat="0",lng="0"} : new Location() { lat = item.loaction.Split(',')[1], lng = item.loaction.Split(',')[0] };
                i.uid = item.id;
                i.address = item.address.ToString().Replace("[]","暂无地址详情") ;
                i.province = item.district;
                list.Add(i);
            }
            result.list = list;
            return result;
        }
    }
}
