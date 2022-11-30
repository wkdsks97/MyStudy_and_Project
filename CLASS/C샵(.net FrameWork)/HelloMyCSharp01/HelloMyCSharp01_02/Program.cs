using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("안녕 난 " +26 +"살이야");

            String name = "김성환";
            int age = 26;

            string info = "안녕 나는 " + age + "살 남성이고, " + name + "이라고 해";
            Console.WriteLine(info);

            string info2 = string.Format("안녕 나는 {0}살 남성이고, {1}이라고 해", age , name);
            Console.WriteLine(info2);

            string info3 = $"안녕 나는 {age}살 남성이고, {name}이라고 해";
            Console.WriteLine(info3);
        }
    }
}
