using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SMSServer.OpenPlatform
{
    public class AbstractFactory
   {
       private static readonly string AssemblyName = "SMSServer.OpenPlatform"; 

       private static readonly string InstantiationClassName = "YM"; 

       public static AbstractMethod GetAssemblyNameClass() 
       {
           return (AbstractMethod)Assembly.Load(AssemblyName).CreateInstance(AssemblyName + "." + InstantiationClassName);

       }
    }
}
