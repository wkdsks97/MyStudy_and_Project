using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01
{
    internal class Program
    {
        static void Main(string[] args)
        {//작업하는 곳

            //cw탭 ==(자바의 syso 안녕과 같다)
            Console.WriteLine("안녕");


            int num1 = 10;
            double num2 = 3.14;

            //c샵에서 문자열 저장은 s를 주로 사용 소문자로 함.
            string m1 = "Hello";
            String m2 = "이것도 된당";
            char lastName = '이';
            bool tf = true;  //자바에서는 boolean을 사용(c샵은 둘 다 사용가능)


            char c1 = "안녕하세요"[0]; //첫글자를 가져옴
            string s1 = "Hello";
            char c2 = s1[1]; //알파벳 e를 가져옴

            Console.WriteLine( c1); //안
            Console.WriteLine( s1); //Hello
            Console.WriteLine( c2); //e

            Console.WriteLine(10+20);  //30
            Console.WriteLine("안녕"+"하세요"); // 안녕하세요
            Console.WriteLine("10"+20); // 1020


            //문자열처리
            //1.더하기를 통해서ㅓ 변수랑 문자열 더함
            int age = 26;
            string info = "내 나이 : " + age; 
            Console.WriteLine(info);

            //2.string.format
            string info2 = string.Format("내 나이 : {0}", age);
            Console.WriteLine( info2);

            //3.$사용
            string info3  = $"내 나이 : {age}";
            Console.WriteLine(info3);





        }
    }
}
