using System.Threading;
using EasyOa.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using EasyOa.Model;

namespace EasyOa.Service
{
    public partial class LogConsumerService : ServiceBase
    {
        public LogConsumerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LogHelper.InfoLog("服务启动...");
            LogDequeue<Person> logDequeue = new LogDequeue<Person>(Execute);
            Thread thread = new Thread(logDequeue.DoDequeue);
            thread.IsBackground = true;
            thread.Start();
            //System.Timers.Timer time = new System.Timers.Timer(10000);
            //time.Elapsed += M1;
            //time.Start();
        }
        protected override void OnStop()
        {
            //new LogDequeue<Person>(Execute).CloseConnection();
            LogHelper.InfoLog("服务停止...");
        }
        /// <summary>
        /// 用于处理消息的方法
        /// </summary>
        /// <param name="person"></param>
        /// <returns>返回处理的结果,true:正确处理,false:处理失败</returns>
        public bool Execute(Person person)
        {
            LogHelper.InfoLog(JsonSerializerHelper.Serialize(person));
            return true;

        }
    }
}
