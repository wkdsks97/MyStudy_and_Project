using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("나이가 어떻게 되세요???");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("이름이 뭐예요??");
            String name = Console.ReadLine();

            Console.WriteLine("MBTI 뭐예요??");
            String MBTI = Console.ReadLine();

            Console.WriteLine("혈액형 뭐예요??");
            String Bt = Console.ReadLine();

            Console.WriteLine("1번: " + name + "님 " + age + "세이며, MBTI는 " + MBTI + " 혈액형: " + Bt);

            Console.WriteLine(" 태어난 연도는????");
            int year = 2023-int.Parse(Console.ReadLine());
            Console.WriteLine("2번: 내 나이는 "+year+"입니다.");

            Console.WriteLine("원의 반지름을 입력하세요!");
            int R = int.Parse(Console.ReadLine());
            Console.WriteLine("3-1번: 원의 둘레: "+2*3.14*R);
            Console.WriteLine("3-2번: 원의 넓이: " + 3.14 * R * R);

            Console.WriteLine("내 시력을 입력하세요!");
            double eye = double.Parse(Console.ReadLine());
            Console.WriteLine("4번: 내 시력은 "+eye+" 입니다.");



        }
    }
}
