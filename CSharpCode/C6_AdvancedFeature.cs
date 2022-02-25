using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpCode
{
    public class C6_AdvancedFeature
    {

        public static void IndexTest()
        {
            List<People> myPeople = new List<People>();
            myPeople.Add(new People("John"));
            myPeople.Add(new People("Bob"));
            myPeople.Add(new People("Ken"));

            myPeople[0] = new People("Mary");
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine(myPeople[i].name);
            }
        }

        public static void OperaotrOverload()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(2, 3);
            Point p3 = p1 + p2;
            Console.WriteLine("The point p3 is ({0},{1})", p3.X, p3.Y);
        }

    }


    public class People : IEnumerable // 索引器需要实现接口 IEnumerable
    {
        public string name;

        public People(string name)
        {
            this.name = name;
        }

        private ArrayList arPeople = new ArrayList();

        // 索引器写法
        public People this[int index]
        {
            get => (People) arPeople[index];
            set => arPeople.Insert(index, value);
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }


    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        // 函数操作符重载
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
}