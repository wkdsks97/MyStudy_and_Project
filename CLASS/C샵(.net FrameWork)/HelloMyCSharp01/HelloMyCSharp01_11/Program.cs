using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1번------------------------------");
            Console.WriteLine("안녕하세요");
            Console.WriteLine("2번------------------------------");
            int p2_1 = 10;
            int p2_2 = 20;
            int p2_3 = 7;
            int p2_4 = 3;
            Console.WriteLine(p2_1+p2_2+" , "+p2_3/p2_4+" , " + p2_3 % p2_4 + " , " + p2_1 * p2_2);
            Console.WriteLine("3번------------------------------");
            Console.WriteLine("\"10\" + "+p2_1);
            Console.WriteLine("\'2\' + " + 100);
            Console.WriteLine("\"10\" + '2' ");
            Console.WriteLine("4번-----------태어난 연도입력-------------");
            int mybirth =int.Parse(Console.ReadLine());
            Console.WriteLine("나는 " + mybirth+"년생입니다.");
            Console.WriteLine("5번-----------이름 입력--------------");
            string myname = Console.ReadLine();
            Console.WriteLine("내 이름은 " +myname+"입니다.");
            Console.WriteLine("6번---------------------------");
            int age = 26;
            string name = "김성환";
            Console.WriteLine("나는 "+"\""+name+"\"입니다."+"나이는 " +"\""+age+"\"세 입니다.");
            Console.WriteLine("7번--------나이입력---------------");
            int myage = int.Parse(Console.ReadLine());
            int year = 2023 - int.Parse(Console.ReadLine());
            Console.WriteLine("입력: "+myage+"  출력: "+ year);
            Console.WriteLine("8번---------------------------");
            Console.WriteLine("올해는???");
            int nowYear = int.Parse(Console.ReadLine());
            Console.WriteLine("태어난 연도는???");
            int bornYear = int.Parse(Console.ReadLine());
            Console.WriteLine("출력: "+(nowYear-bornYear+1)+"살");
            Console.WriteLine("9번----글자입력(첫글자 출력)----------");
            string input = Console.ReadLine();
            Console.WriteLine(input[0]);

            Console.WriteLine("10번-----------정사각형 변 길이->넓이 구하기--------");
            int w = int.Parse(Console.ReadLine());
            Console.WriteLine("결과: "+w*w);
        }
    }
}
