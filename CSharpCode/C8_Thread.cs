using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpCode
{
    public class C8_Thread
    {
        public delegate int BinaryOP(int x, int y);

        public static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        /// <summary>
        /// 同步调用
        /// </summary>
        public static void SynchronousTest()
        {
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId); // 输出当前线程的ID
            BinaryOp b = Add;

            int ans = b(10, 10);
            Console.WriteLine("Doing more work in Main()");
            Console.WriteLine("10 + 10 is {0}", ans);
        }


        /// <summary>
        /// 异步调用
        /// </summary>
        public static void ASynchronousTest()
        {
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId); // 输出当前线程的ID
            BinaryOp b = Add;

            IAsyncResult iftAr = b.BeginInvoke(10, 10, null, null); // 开启另一个线程

            Console.WriteLine("Doing more work in Main()");

            // 在这里，为了获取结果，主线程收到阻塞
            int ans = b.EndInvoke(iftAr);
            Console.WriteLine("10 + 10 is {0}", ans);
        }

        /// <summary>
        /// 对于异步调用的改进
        /// </summary>
        public static void ASynchronousTest2()
        {
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId); // 输出当前线程的ID
            BinaryOp b = Add;

            IAsyncResult iftAr = b.BeginInvoke(10, 10, null, null); // 开启另一个线程

            //在新线程的结果没有结束的情况下，主线程可以先做下面的事情
            while (!iftAr.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()");
                Thread.Sleep(1000);
            }


            // 现在Add()完成了
            int ans = b.EndInvoke(iftAr);
            Console.WriteLine("10 + 10 is {0}", ans);
        }

        public static void ASynchronousTest3()
        {
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId); // 输出当前线程的ID
            BinaryOp b = Add;

            IAsyncResult iftAr = b.BeginInvoke(10, 10, null, null); // 开启另一个线程


            // 指定最长的等待时间，如果超时，返回False
            while (!iftAr.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Doing more work in Main()");
            }

            // 现在Add()完成了
            int ans = b.EndInvoke(iftAr);
            Console.WriteLine("10 + 10 is {0}", ans);
        }


        /// <summary>
        /// 多线程 [无返回值，无参数]的方法
        /// </summary>
        public static void MultiThread()
        {
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            Console.WriteLine("-> {0} executing Main()", Thread.CurrentThread.Name);

            // 创建执行任务的类
            C8_Thread p = new C8_Thread();
            // ThreadStart 仅仅委托[无返回值，无参数]的方法
            Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
            backgroundThread.Name = "Secondary";
            backgroundThread.Start();

            Console.WriteLine("I am working on main thread");
        }

        public void PrintNumbers()
        {
            Console.WriteLine("-> {0} executing PrintNumbers()", Thread.CurrentThread.Name);
            Console.Write("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0},", i);
                Thread.Sleep(1000);
            }

            Console.WriteLine();
        }


        public static void TestAsync()
        {
            Method1();
            Method2();
        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Method1");
                }
            });
        }

        public static void Method2()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Method2");
            }
        }
    }

    class AsyncAwait
    {
        public static void AsyncTest()
        {
            Console.WriteLine("Thread {0}: Let`s Do This!", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0}: I am going to call my son.", Thread.CurrentThread.ManagedThreadId);
            AsyncTask(); //调用Async修饰的方法
            Console.WriteLine("Thread {0}: My son is busy now,and I will go on.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0}: I`m done!", Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }

        //Async修饰的方法
        public static async Task AsyncTask()
        {
            // await 前的部分 -> 在caller线程下执行
            Console.WriteLine("Thread {0}: 我是方法AsyncTask", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0}: 我是方法AsyncTask1", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0}: 我是方法AsyncTask2", Thread.CurrentThread.ManagedThreadId);
            // await 开始标记开新的子线程
            var result = await WasteTime();
            // await 后的部分 -> 在callee线程下执行
            Console.WriteLine(result);
            Console.WriteLine("Thread {0}: 我已经干完了我应该干的事情!", Thread.CurrentThread.ManagedThreadId);
        }

        // 注意这个是后台线程，主线程如果结束完毕后直接被关掉
        private static async Task<string> WasteTime()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1); //避免Console.WriteLine执行太快使整个程序执行起来像是同步执行的
                Console.WriteLine("Thread {0}: 我开始异步执行了!", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread {0}: 可是我啥都不想干,还是等个五秒钟就跟主线程说我做好了吧", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);

                return $"Thread {Thread.CurrentThread.ManagedThreadId}: 我异步执行完了";
            });
        }
    }
}