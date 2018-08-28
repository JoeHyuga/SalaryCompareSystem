using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Factory.MapFactory
{
    public class GaodeMapFactory:MapFactory
    {
        public override Map CreateMap()
        {
            return new GaodeMap();
        }
    }
}
