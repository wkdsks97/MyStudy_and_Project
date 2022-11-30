using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine("");
            Console.WriteLine("---------------");
            int k = 1;
            while(k <= 10)
            {
                Console.Write(k + " ");
                k++;
            }

            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("2번 a와 b입력");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if(a>b)
            {
                int temp = a;
                a = b;
                b= temp;
            }
            for (int i= a; i <= b; i++)
               {
                Console.Write(i+" ");
            }

            Console.WriteLine("");

            while (a <= b)
            {

                Console.Write(a + " ");
                a++;
            }
            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("3번");
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0) 
                Console.Write(i + " ");
            }
          

            Console.WriteLine("");
            Console.WriteLine("---------------");

            int num = 1;
            while (num <= 100)
            {
                if (num % 2 == 0)
                    Console.Write(num + " ");
                num++;
            }

            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("4번");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            for (int i = b; i >= a; i--)
            { Console.Write(i + " "); }

            Console.WriteLine("");
            while (b >= a)
            {
                
                    Console.Write(b + " ");
                b--;
            }

        }
    }
}
