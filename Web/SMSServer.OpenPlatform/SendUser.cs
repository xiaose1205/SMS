using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
   public class SendUser
   {
     
  
       //==========亿美=============

       /// <summary>
       /// 系列号
       /// </summary>
       public string serialNumber {get;set;}
       /// <summary>
       /// 优先级
       /// </summary>
       public string priority { get; set; }

       public string passwd { get; set; }

       public string sdkKey { get; set; }
       /// <summary>
       /// 特服号
       /// </summary>
       public string tefuhao { get; set; }

   }
}
