using System;

namespace CSharpCode
{
    public delegate int BinaryOp(int x, int y);


    public class C5_Delegate
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        /// <summary>
        /// 委托可以是静态方法，也可以是对象的方法
        /// </summary>
        public static void DelegateTest()
        {
            C5_Delegate c = new C5_Delegate();
            BinaryOp binaryOp = c.Add;
            Console.WriteLine("Call delegate method binaryOp: {0}", binaryOp(1, 2));
            DisplayDelegateInfo(binaryOp);

            binaryOp += Subtract; // 可以给一个委托对象增加多个方法，同时调用
            Console.WriteLine("Call delegate method binaryOp: {0}", binaryOp(1, 2));
            DisplayDelegateInfo(binaryOp);
        }


        public static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (var d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method name: {0}", d.Method);
                Console.WriteLine("Type name: {0}", d.Target);
            }
        }
    }


    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead = false;

        public Car()
        {
            MaxSpeed = 100;
        }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }


        public delegate void CarEngineHandler(string msgForCaller);

       

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        
        
        private CarEngineHandler listOfHandlers;
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }
        
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        
        

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (Exploded != null)
                {
                    Exploded("Sorry, this car is dead");
                }
            }
            else
            {
                CurrentSpeed += delta;
                if (MaxSpeed - CurrentSpeed == 10 && AboutToBlow != null)
                {
                    AboutToBlow("Careful buddy!");
                }

                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }


    public class Program
    {
        public static void DelegateTest()
        {
            Car c1 = new Car("SlugBug", 100, 10);
            c1.RegisterWithCarEngine(OnCarEngineEvent);
            c1.RegisterWithCarEngine(OnCarEngineEvent2);

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }
        
        public static void DelegateTest2()
        {
            Car c1 = new Car("SlugBug", 100, 10);
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CasIsAboutToBlow;
            c1.Exploded  += CarExploded;
            c1.Exploded += delegate(string msg) { Console.WriteLine("This is an as anonymity function: {0}", msg);}; // 匿名函数
            c1.Exploded += msg => Console.WriteLine("This is a lambda expression: {0}", msg); // lambda 表达
            
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }


        public static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine("CarIsAlmostDoomed => {0}", msg);
        }
        
        public static void CasIsAboutToBlow(string msg)
        {
            Console.WriteLine("CasIsAboutToBlow => {0}", msg);
        }

        public static void CarExploded(string msg)
        {
            Console.WriteLine("CarExploded => {0}", msg);
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("=> {0}", msg);
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }
    }
}