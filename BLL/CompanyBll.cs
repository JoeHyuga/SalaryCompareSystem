using Common;
using Common.Factory.MapFactory;
using Common.Model;
using Domain.Entity;
using Domain.IConcrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
        public static BaiduMapResult SearchAddress(string address)
        {
            var factory = new BaiduMapFactory();//获取具体工厂
            var map = factory.CreateMap();//实例化
            var json = map.SearchAddress(address);
            //将结果反序列化为实体
            var result = JsonConvert.DeserializeObject<BaiduMapResult>(json);
            return result;
        }
    }
}
