using System;

namespace CSharpCode
{
    public class C4_Class
    {
        public static void ClassTest()
        {
            Console.WriteLine("The static variable currRate is {0}", Constructor.currRate);
            StaticClass.PrintTime();
        }


    }

    class Constructor
    {
        private int num;
        private string str;

        // 构造函数逻辑链
        // 构造函数也可以使用可选参数
        public Constructor(int num, string str = "")
        {
            this.num = num;
            this.str = str;
        }

        public Constructor(int num) : this(num, "")
        {
        }

        public Constructor() : this(0, "")
        {
        }


        /// <summary>
        /// 静态构造函数
        /// 初始化编译时未知的静态数据值
        /// - 一个类只能定义一个静态构造函数
        /// - 静态函数不允许访问修饰符且不接受任何参数
        /// - 静态构造函数只执行一次
        /// - 运行库创建实例或者调用者首次访问静态成员之前，运行库会先调用静态构造函数
        /// </summary>
        public static int currRate;

        static Constructor()
        {
            currRate = 1;
        }


        // .NET 属性的使用规则
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name must be less thant 16 characters");
                }
            }
        }
    }
    
    static class StaticClass{

        public static void PrintTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }
    }
}