using System;

namespace CSharpCode
{
    public class C3_EnumAndStruct
    {
        /// <summary>
        /// 枚举类的声明
        /// </summary>
        enum EmpType : int
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }

        public static void EnumFeature()
        {
            EmpType e = EmpType.Contractor;
            Console.WriteLine("Current e is a {0}", e.ToString()); // 返回当前枚举类的字符串名
            Console.WriteLine("Current e's value is {0}",(int) e); // 获取某个枚举变量的值，只需要强行转换即可
            
            // 反向获取枚举类所有的变量和它们的值
            Array enumData = Enum.GetValues(e.GetType());
            foreach (var data in enumData)
            {
                Console.WriteLine("Name: {0}, Value: {1}", data, (int)data);
            }
        }

        /// <summary>
        /// 结构变量
        /// 注意结构变量是按值传递的
        /// 也就是对结构变量的任何复制会将结构变量里面的变量的值重新再拷贝一份！！
        /// </summary>
        struct Point
        {
            public int X;
            public int Y;

            public void Increasement()
            {
                X++;
                Y++;
            }

            public void Display()
            {
                Console.WriteLine("The point is ({0}, {1})", X, Y);
            }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public static void StructFeature()
        {
            Point p;
            p.X = 1;
            p.Y = 1;
            
            p.Increasement();
            p.Display();

            Point p1 = new Point(1, 2);
            p1.Increasement();
            p1.Display();
        }


        /// <summary>
        /// 可空类型
        /// 可以表示所有与实际类型的值加上null
        /// </summary>
        public static void NullableType()
        {
            int? nullableInt = 10; // ? 建立一个可空int型
            // 可以用下面的方法判断是否为空
            nullableInt = null;
            if (nullableInt.HasValue)
            {
                Console.WriteLine("It is not null!");
            }

            nullableInt = nullableInt ?? 10; // ?? 当获得的实际值是null的时候，可以用??给其赋值
            // 相当于 if nullableInt == null -> nullableInt = 10
            
            
            if (nullableInt != null)
            {
                Console.WriteLine("It is not null!");
            }
            // 注意字符串是不可以的，它是引用类型
        }
    }
}