using System;
using System.Linq;

namespace CSharpCode
{
    public class C7_LINQ
    {
        public static void LINQTest()
        {

            int[] numbers = {10, 20, 30, 40, 1, 2, 3, 8};
            var subset = from i in numbers where i < 10 select i;
            foreach (var i in subset)
            {
                Console.WriteLine("{0} < 10", i);
            }

            int[] selectArr = subset.ToArray();

        }
    }
}