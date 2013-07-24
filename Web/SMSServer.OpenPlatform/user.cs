using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
   public class user
   {
       public string url { get; set; }
       //===============无极限发送所需字段===================
       public string content { get; set; }
       public string mdpass { get; set; }
       public string mobile { get; set; }
       public string name { get; set; }
       public string pass { get; set; }
       public string ptimestamp { get; set; }
       public string sendPort { get; set; }
       public string sendTime { get; set; }


       public string method { get; set; } 


       //===============合众发送所需字段===================
       public int unitid { get; set; }
       public string username { get; set; }
       public string passwd { get; set; }
       public string msg { get; set; }
       public string phone { get; set; }

       //==========亿美=============

       /// <summary>
       /// 系列号
       /// </summary>
       public string serialNumber {get;set;}
       /// <summary>
       /// 优先级
       /// </summary>
       public string priority { get; set; }
    }
}
