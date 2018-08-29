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
        public static object SearchAddress(string address)
        {
            var mapDll = WebConfigurationManager.AppSettings["MapDll"].ToString();
            var mapClass = WebConfigurationManager.AppSettings["MapClass"].ToString();

            //var factory=(MapFactory)Activator.CreateInstance(Assembly.Load(mapDll).GetType(mapClass));//通过反射获取具体类
            var factory = new BaiduMapFactory();
            var map = factory.CreateMap();//实例化类
            var json = map.SearchAddress(address);//获取json结果
            var result = map.JsonToEntity(json);
            return result;
        }
    }
}
