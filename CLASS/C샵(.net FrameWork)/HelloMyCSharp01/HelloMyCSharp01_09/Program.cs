using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp01_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };
            int[] numbers2 = new int[3];
            numbers2[0] = 1;
            numbers2[1] = 2;
            numbers2[2] = 3;
            int[,] numbers_2 = new int[2, 3];
            numbers_2[0,0] = 1;
            numbers_2[0,1] = 2;
            numbers_2[0,2] = 3;
            numbers_2[1,0] = 4;
            numbers_2[1,1] = 5;
            numbers_2[1,2] = 6;

            //for문 while문으로도 되고
            //foreach문이라는 것도 됨
            for(int i = 0; i < numbers.Length; i++) 
                 Console.WriteLine(i);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            //2차원 배열 반복문
            for (int i = 0; i <numbers_2.GetLength(0); i++)
            {
                for (int j = 0; j < numbers_2.GetLength(1); j++)
                {
                    Console.WriteLine($"[{i},{j}]={numbers_2[i,j]}");
                }
            }


            int[] num = new int[5];
            for (int i = 0; i < 5; i++)
            {
                num[i] = int.Parse(Console.ReadLine());
            }

            int max = 0;
            int max_s = 0;
            int min = num[0];
            int min_s = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (min > num[i])
                {
                    min = num[i];
                    min_s = i;
                }
                if (max < num[i])
                {
                    max = num[i];
                    max_s = i;
                }
            }
            Console.WriteLine("최솟값: {0}, 최댓값: {1}",min,max);
            Console.WriteLine("최솟값은 {0}번째, 최댓값은 {1}번쨰", min_s+1, max_s+1);

            foreach (var item in num)
            {
                if(item>max_s)
                    item = max_s;
                if(item < min_s)
                    item = min_s;
            }

            int[] num10 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                num10[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < num10.Length; i++)
            {
                if ((num10[i])%2 != 0)
                {
                    num10[i] = 0;
                    continue;
                }
                Console.Write(num10[i]+" ");
                
            }



        }
    }
}
