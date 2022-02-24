using System;

namespace CSharpCode
{
    public class C2_Method
    {
        /// <summary>
        /// C#参数修饰符
        /// - 无         如果一个参数没有用参数修饰符标记，它默认按值传递，被调用的方法收到原始数据的副本
        /// - out       输出参数由被调用方法不知，因此它按引用传递，如果被调用方法没有给输出参数赋值，则会出现编译错误
        /// - ref       调用者赋初值，并且可以由被调用的方法可选地重新赋值，如果被调用方法没有给ref参数赋值，也不会出现错误
        /// - params    允许将一组数量可变的参数作为单独的逻辑参数进行传递，必须是方法的最后一个参数 
        /// </summary>

        public static void TestDecorator()
        {
            // out 部分
            int ans;
            string ans2;
            OutDecorator(1, 2, out ans, out ans2);
            Console.WriteLine(ans);
 
            // ref 部分
            string a1 = "hello";
            string a2 = "hi";
            RefDecorator(ref a1, ref a2);
            Console.WriteLine("a1 = {0}, a2 = {1}", a1, a2);
            
            // params 部分
            double avg = ParamsDecorator(1, 1, 4, 2.4, 1.2);
        }

        /// <summary>
        /// out 的好处是。通过它，调用者可以只使用一次方法调用就获得多个返回值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ans"></param>
        /// <param name="ans2"></param>
        public static void OutDecorator(int x, int y, out int ans, out string ans2)
        {
            ans = x + y;
            ans2 = "x + y + 1";
        }

        /// <summary>
        /// ref修饰的参数必须在它们被传递给方法之前就初始化好
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void RefDecorator(ref string x, ref string y)
        {
            string temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// 可变长
        /// - 注意参数声明的是[数组]
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double ParamsDecorator(params double[] values)
        {
            double sum = 0;
            foreach (var i in values)
            {
                sum += i;
            }
            return sum / values.Length;
        }


        /// <summary>
        /// 可选参数
        /// 为了避免歧义，可选参数必须放在方法签名的最后
        /// 将可选参数放在非可选参数前面将导致编译错误
        /// </summary>
        /// <param name="message"></param>
        public static void OptionalParameter(string message = "optional")
        {
            Console.WriteLine("The optional message is {0}", message);
        }



        /// <summary>
        /// 命名参数
        /// 允许在调用方法的时候以任意顺序指定参数的值
        /// </summary>
        public static void TestNamedParameter()
        {
            NamedParameter(a2:"hello", a1:"hi");
        }

        public static void NamedParameter(string a1, string a2)
        {
            Console.WriteLine("a1 = {0}, a2 = {1}", a1, a2);
        }
    }
}