using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyOa.Common;
using System.Threading;

namespace EasyOa.Service
{
    public class LogConsumer
    {
        public void Execute()
        {
            while (true)
            {
                int code = 0;
                List<Person> list = LogDequeue.TryDequeue<List<Person>>(out code);
                if (code == 0) FileHelper.WriteFile("LogConsumer.txt", list.Count.ToString());
                if (code == -1) FileHelper.WriteFile("LogConsumer.txt", DateTime.Now.ToString() + " 消息解析出错");
                if (code == -2) FileHelper.WriteFile("LogConsumer.txt", DateTime.Now.ToString() + " 消息超过自动重试次数");
                Thread.Sleep(1000);
            }



        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
