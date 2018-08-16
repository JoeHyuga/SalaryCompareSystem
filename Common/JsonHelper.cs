using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsonHelper
    {

    }

    public class ApiResult<T,V>
    {
        public T obj { get; set; }

        public List<V> rows { get; set; }

        public bool success { get; set; }

        public int count { get; set; }

        public string message { get; set; }
    }
}
