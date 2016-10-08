using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeispielThread
{
    class Program
    {
        class tTest
        {
            public TimeSpan t1Dauer, t2Dauer;
            public void t1()
            {
                DateTime start = DateTime.Now;
                Double x = 3.88;
                for (int i = 0; i < 1000000; i++)
                {
                    x = Math.Sin(x) * i;
                }
                t1Dauer = DateTime.Now.Subtract(start);
            }


            public void t2()
            {
                DateTime start = DateTime.Now;
                Double x = 99.0105;
                for (int i = 0; i < 1000000; i++)
                {
                    x *= i;
                }
                t2Dauer = DateTime.Now.Subtract(start);
            }


        }

        static void Main(string[] args)
        {
            tTest tt = new tTest();
            Thread t1 = new Thread(new ThreadStart(tt.t1));
            Thread t2 = new Thread(new ThreadStart(tt.t2));
            t1.Name = "ThreadNummer1";
            t2.Name = "Thread2";
            Console.WriteLine($"Thread1 \t\tThread2");
            Console.WriteLine($"{t1.ThreadState} \t\t{t2.ThreadState}");

            t1.Start();
            t2.Start();

            Console.WriteLine($"{t1.Name} \t\t{t2.Name}");
            Console.WriteLine($"{t1.ThreadState} \t\t{t2.ThreadState}");


            t1.Join();
            t2.Join();

            Console.WriteLine($"{tt.t1Dauer} \t{tt.t2Dauer}");
            Console.WriteLine($"{t1.ThreadState} \t\t{t2.ThreadState}");

            Console.ReadLine();

        }
    }
}
