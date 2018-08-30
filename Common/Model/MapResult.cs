using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class MapResult
    {
        public string message { get; set; }

        public string status { get; set; }

        public string count { get; set; }

        public List<Result> list { get; set; }
    }
}
