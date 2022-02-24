using System;

namespace CSharpCode
{
    public class C1_Formatting
    {
        public static void Main(string[] args)
        {
        }


        public static void StringFormat()
        {
            int a = 0;
            Console.WriteLine("This is the value of a: {0}", a);
            Console.WriteLine("Repeat is for three times {0}, {0}, {0}", a);
        }

        public static void NumFormat()
        {
            int num = 99999;
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", num);          // 格式化货币
            Console.WriteLine("d9 format: {0:d9}", num);        // 格式化十进制数，预留9个位置
            Console.WriteLine("c format: {0:f3}", num);         // 格式化浮点数，3个小数位
            Console.WriteLine("c format: {0:n}", num);          // 基本数值格式化
            Console.WriteLine("c format: {0:E}", num);          // 指数计数法
            Console.WriteLine("c format: {0:e}", num);          // 指数计数法
            Console.WriteLine("c format: {0:X}", num);          // 十六进制格式化(字符大写)
            Console.WriteLine("c format: {0:x}", num);          // 十六进制格式化(字符小写)
        }
    }
}