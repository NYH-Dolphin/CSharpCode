using System;
using System.Linq;

namespace CSharpCode
{
    public class C1_BasicUsage
    {
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// 字符串格式化输出
        /// </summary>
        public static void StringFormat()
        {
            int a = 0;
            Console.WriteLine("This is the value of a: {0}", a);
            Console.WriteLine("Repeat is for three times {0}, {0}, {0}", a);
        }


        /// <summary>
        /// 数字格式化输出
        /// </summary>
        public static void NumFormat()
        {
            int num = 99999;
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", num); // 格式化货币
            Console.WriteLine("d9 format: {0:d9}", num); // 格式化十进制数，预留9个位置
            Console.WriteLine("c format: {0:f3}", num); // 格式化浮点数，3个小数位
            Console.WriteLine("c format: {0:n}", num); // 基本数值格式化
            Console.WriteLine("c format: {0:E}", num); // 指数计数法
            Console.WriteLine("c format: {0:e}", num); // 指数计数法
            Console.WriteLine("c format: {0:X}", num); // 十六进制格式化(字符大写)
            Console.WriteLine("c format: {0:x}", num); // 十六进制格式化(字符小写)
        }


        /// <summary>
        /// checked 关键字的功能 -> 检查强制转换问题
        /// .NET 运行时默认的行为是忽略运算溢出
        /// </summary>
        public static void CheckedTest()
        {
            // 方法1
            int i = 100;
            int j = 20;
            try
            {
                byte sum1 = checked((byte) (i + j));
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            // 方法2
            try
            {
                checked
                {
                    byte sum2 = (byte) (i + j);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            // unchecked 不检查
            try
            {
                unchecked
                {
                    byte sum2 = (byte) (i + j);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// 隐式类型变量，使用var关键字不必指定具体的数据类型
        /// 注意
        /// - 隐式类型只能用于方法或属性范围内的本地变量
        /// - var 关键字不能够定义返回值，参数或者自定义类型
        /// - 声明局部变量必须分配初始值
        /// </summary>
        public static void DeclareImplicitVars()
        {
            var myInt = 0;
            var myBool = true;
            var myString = "This is a string";
            var arr = new[] {1, 2, 3, 4, 5};
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);
        }

        /// <summary>
        /// 事实上，可以说只有在LINQ查询时返回数据时候才应该使用var关键字
        /// 或者是在数组foreach迭代中可以使用
        /// 剩下的时候，使用var被视为一种不好的设计
        /// </summary>
        public static void VarInLINQ()
        {
            int[] numbers = {10, 20, 30, 40, 1, 2, 3, 8};
            
            // LINQ 查询
            var subset = from i in numbers where i < 10 select i;
            
            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}