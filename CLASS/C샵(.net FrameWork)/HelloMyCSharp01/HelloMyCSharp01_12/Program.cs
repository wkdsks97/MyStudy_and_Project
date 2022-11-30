using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("11번+12번-------------------");
            Console.Write("숫자 입력: ");
            int num = int.Parse(Console.ReadLine());
            if(num<0)
                Console.WriteLine("음수");
            else if (num>0)
                Console.WriteLine("자연수");
            else
            {
                Console.WriteLine("자연수 아님");
            }


            Console.WriteLine("13번-------------------");
            Console.WriteLine("랜덤 가위바위보 출력하기");
            Random r = new Random();
            int com = r.Next(3);
            if(com == 0)
            {
                Console.WriteLine("가위");
            }
            else if(com == 1)
            {
                Console.WriteLine("바위");
            }
            else
            {
                Console.WriteLine("보");
            }


            Console.WriteLine("14번-------------------");
            int mychoice = int.Parse(Console.ReadLine());
            switch (mychoice)
            {
                case 0: //가위
                    switch (com)
                    {
                        case 0:
                            Console.WriteLine("비김");
                            break;
                        case 1:
                            Console.WriteLine("패배");
                            break;
                        case 2:
                            Console.WriteLine("승리");
                            break;
                        default:
                            break;
                    }
                    break;
                case 1: //바위
                    switch (com)
                    {
                        case 0:
                            Console.WriteLine("승리");
                            break;
                        case 1:
                            Console.WriteLine("비김");
                            break;
                        case 2:
                            Console.WriteLine("패배");
                            break;
                        default:
                            break;
                    }
                    break;
                case 2: //보
                    switch (com)
                    {
                        case 0:
                            Console.WriteLine("패배");
                            break;
                        case 1:
                            Console.WriteLine("승리");
                            break;
                        case 2:
                            Console.WriteLine("비김");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 값");
                    break;
            }

            Console.WriteLine("15번");
            if (com == mychoice)
                Console.WriteLine("비김");
            else if ((mychoice == 0 && com == 2) || (mychoice == 1 && com == 0) || (mychoice == 2 && com == 1)) //가위(0) -> 보(2), 바위(1) -> 가위(0), 보(2) -> 바위(1)
                Console.WriteLine("이김");
            else
                Console.WriteLine("짐");

            Console.WriteLine("16번------------------");
            Console.WriteLine("1~10 출력");
            for(int i = 1; i <= 10; i++)
            { Console.Write(i +" "); }

            Console.WriteLine(" ");
            Console.WriteLine("17번------------------");
            Console.WriteLine("1~10 곱");
            int sum = 1;
            for (int i = 1; i <= 10; i++)
            {
                sum *= i;
            }
            Console.WriteLine(sum);

            Console.WriteLine("18번------------------");
            for (int i = 1; i <= 10; i++)
            { 
                Console.WriteLine(i + "번 째 손님 안녕하세요 "); 
            }
            Console.WriteLine("19번------------------");
            int number =int.Parse(Console.ReadLine());
            while (number != 0)
            {
                int n = number * number;
                Console.WriteLine(n);
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("20_1번------------------");
            sum = 1;
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                    continue;
                sum *= i;
            }
            Console.WriteLine(sum);
            Console.WriteLine("20_2번------------------");
            sum = 1;
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 != 0)
                sum *= i;
            }
            Console.WriteLine(sum);
        }
    }
}
