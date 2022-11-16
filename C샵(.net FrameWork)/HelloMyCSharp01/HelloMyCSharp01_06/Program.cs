using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("안녕하세요 " + i + "번님");
            }

            Console.WriteLine("");
            int sum = 0;
            for (int i = 0; i <= 10; i++)
            {
                sum += i;
            }
            Console.WriteLine("1부터 10까지의 합은 " + sum);
            Console.WriteLine("");

            Console.Write("숫자를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (i >= j)
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine(" ");
            }

            int mynum = -1;
            do
            {
                Console.WriteLine("mynum=" + mynum);
                Console.WriteLine("mynum은?");
                mynum = int.Parse(Console.ReadLine());
            } while (mynum > 0);


        MYTEST:
            Console.WriteLine("Hello World");

            if (mynum == -1)
            {
                Console.WriteLine("mynum?");
                mynum = int.Parse(Console.ReadLine());
                goto MYTEST;
            }

        }
    }
}
