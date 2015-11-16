using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using EasyOa.Common;

namespace EasyOa.Service
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //log4net配置文件
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppConfig.BasePath + "log4net.config"));
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new LogConsumerService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
