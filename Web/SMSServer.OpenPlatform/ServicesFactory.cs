using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SMSServer.OpenPlatform
{
    public class ServicesFactory
    {


        private static Dictionary<int, BaseService> s_Service = new Dictionary<int, BaseService>();


        public static void RegisterApp(BaseService handler)
        {
            if (s_Service.ContainsKey(handler.GetSignNum()))
                s_Service[handler.GetSignNum()] = handler;
            else
            {
                s_Service.Add(handler.GetSignNum(), handler);
            }
        }

        public static BaseService Execute(int signNum)
        {
            if (s_Service.ContainsKey(signNum))
                return s_Service[signNum];
            return null;
        }
    }
}
