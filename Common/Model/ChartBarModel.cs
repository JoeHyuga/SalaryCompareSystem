﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ChartBarModel : ChartModel
    {
        public int barGap { get; set; }

        public int[] data { get; set; }
    }
}
