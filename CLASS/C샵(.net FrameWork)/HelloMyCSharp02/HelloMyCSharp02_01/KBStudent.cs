using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp02_01
{
    internal struct KBStudent
    {
        public string name;
        public int age;
        public double eye;
        public string mbti;

        public void interduce()
        {
            Console.WriteLine("이름: "+name);
            Console.WriteLine("시력: "+ eye);
            Console.WriteLine("나이: "+ age);
            Console.WriteLine("MBTI: "+ mbti);
        }
    }
}
