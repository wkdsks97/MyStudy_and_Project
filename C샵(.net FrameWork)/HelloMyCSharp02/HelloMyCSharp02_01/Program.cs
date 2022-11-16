using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp02_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1= new Student();
            s1.name = "김성환";
            s1.age= 26;
            s1.eye = 0.3;

            Console.WriteLine(s1.name);
            Console.WriteLine(s1.age);
            Console.WriteLine(s1.eye);
            Console.WriteLine();

            Console.WriteLine("p2---------------------------");
            Student s2 = new Student();
            Console.WriteLine("이름은?");
            s2.name = Console.ReadLine();
            Console.WriteLine("나이?");
            s2.age = int.Parse(Console.ReadLine());
            Console.WriteLine("시력?");
            s2.eye = double.Parse(Console.ReadLine());
            Console.WriteLine(s2.name);
            Console.WriteLine(s2.age);
            Console.WriteLine(s2.eye);
            Console.WriteLine();


            Console.WriteLine("p3---------------------------");
            Student[] st = new Student[3];
            st[0] = new Student();
            st[1] = new Student();
            st[2] = new Student();

            st[0].name = "안서준";
            st[0].age = 27;
            st[0].eye = 1.5;

            st[1].name = "박재형";
            st[1].age = 26;
            st[1].eye = 1.2;

            st[2].name = "도광현";
            st[2].age = 27;
            st[2].eye = 0.1;


           for(int i = 0; i < 3;i++)
            {
                Console.WriteLine($"{st[i].name}+학생은 " +
                    $"{st[i].age}+살이며, 시력은 {st[i].eye}이다");
            }

            Console.WriteLine("p4---------------------------");

            Student[] student = new Student[3];
            
            for(int i=0;i<student.Length;i++) 
            {
                student[i]=new Student();
                Console.Write(i+1+"번쨰 학생 이름: ");
                student[i].name = Console.ReadLine();
                Console.Write(i + 1 + "번쨰 학생 나이: ");
                student[i].age = int.Parse(Console.ReadLine());
                Console.Write(i + 1 + "번쨰 학생 시력: ");
                student[i].eye = double.Parse(Console.ReadLine());
            }
            for (int i = 0; i < student.Length; i++)
            {
                Console.WriteLine(student[i].name+student[i].age + student[i].eye);
            }

            Console.WriteLine("p6---------------------------");
            KBStudent kb = new KBStudent();
            kb.name = "장혜정";
            kb.age = 25;
            kb.eye = 0.3;
            kb.mbti = "infp";

            Console.WriteLine(kb.name+"님 "+ kb.age+"세이며, 시력은 "+ kb.eye+", mbti 는 "+ kb.age);



            KBStudent kb2= new KBStudent();
            kb2.name = "김성환";
            kb2.age = 26;
            kb2.eye = 1.2;
            kb2.mbti = "isfj";
            kb2.interduce();
        }
    }
}
