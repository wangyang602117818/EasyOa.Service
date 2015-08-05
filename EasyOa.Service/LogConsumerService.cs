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
            FileHelper.WriteFile("LogConsumer.txt", DateTime.Now.ToString() + " 服务已启动...");
            LogConsumer logConsumer = new LogConsumer();
            Thread thread = new Thread(logConsumer.Execute);
            thread.IsBackground = true;
            thread.Start();


            //System.Timers.Timer time = new System.Timers.Timer(10000);
            //time.Elapsed += M1;
            //time.Start();



        }

        private void M1(object sender, System.Timers.ElapsedEventArgs e)
        {

            LogConsumer logConsumer = new LogConsumer();
            logConsumer.Execute();
        }

        protected override void OnStop()
        {
            FileHelper.WriteFile("LogConsumer.txt", DateTime.Now.ToString() + " 服务已停止...");
        }


    }
}
