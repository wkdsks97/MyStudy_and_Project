using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp06_04
{
    internal class MyMath3
    {
        public static int power(int x , int c=2)
        {
            int result = 1;
            for(int i = 0; i < c; i++)
            {
                result *= x;
            }
            return result;
        }

        public static int multi(int x, int y)
        {
            return x * y;
        }
    }
}
