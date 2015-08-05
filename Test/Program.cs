using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyOa.Common;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Person> list = new List<Person>()
            //    {
            //        new Person(){Age=12,Name = "张三"},
            //        new Person(){Age = 13,Name = "李四"}
            //    };
            //for (int i = 1; i <= 2; i++)
            //{
            //    LogEnqueue.Enqueue(BinarySerializerHelper.ObjectToByteArray("aaaanbbccc"));
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    LogEnqueue.Enqueue(list);
            //}
            //Console.WriteLine("已发送");

            while (true)
            {
                int code = 0;
                List<Person> list = LogDequeue.TryDequeue<List<Person>>(out code);
                if (code == 0) Console.WriteLine(list.Count);
                if (code == -1) Console.WriteLine("消息解析出错，重新入队");
                if (code == -2) Console.WriteLine("消息超出重试次数，自动删除");
            }
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
