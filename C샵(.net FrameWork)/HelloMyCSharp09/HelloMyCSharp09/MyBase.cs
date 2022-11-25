using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp09
{
    public class MyBase
    {
        public string name { get; set; }
        public virtual void print(String msg)
        {
            Console.WriteLine(msg);
        }

    }
}
