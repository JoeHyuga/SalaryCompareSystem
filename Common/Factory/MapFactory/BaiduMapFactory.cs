using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Factory.MapFactory
{
    public class BaiduMapFactory:MapFactory
    {
        public override Map CreateMap()
        {
            return new BaiduMap();
        }
    }
}
