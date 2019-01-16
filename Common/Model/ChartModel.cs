using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ChartModel
    {
        public string title { get; set; }

        public string yName { get; set; }

        public string xName { get; set; }

        public string[] xData { get; set; }

        public List<series> series { get; set; }
    }

    public class series
    {
        public string name { get; set; }
        public string type { get; set; }
        public string[] data { get; set; }
    }
}
