﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HelloData.FWCommon
{
    public class JsonHelper
    {
        public static  string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
