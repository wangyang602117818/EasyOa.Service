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
            string path = AppConfig.BasePath;
            LogHelper.InfoLog("zxcx");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
