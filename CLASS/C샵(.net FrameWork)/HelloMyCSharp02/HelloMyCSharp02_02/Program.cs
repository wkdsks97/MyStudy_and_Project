using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp02_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //구조체
            BKBank B1 = new BKBank();
            B1.Name = "박재형";
            B1.Balance= 10000000;

            BKBank B2 = B1;
            B2.Balance = 0;

            B1.info();
            B2.info();

            KBBank kb1 = new KBBank();
            kb1.Name = "박지호";
            kb1.Balance = 9999;
            KBBank kb2 = kb1;
           
            kb2.Balance = 0;
             
            kb1.info();
            kb2.info();

            KyungBank kbb1 = new KyungBank("조영탁");
            kbb1.Balance = 50000;
            KyungBank kbb2 = new KyungBank(kbb1.Name);
            kbb2.Balance = 0;

            kbb1.info();
            kbb2.info();

            kbb1.saving(10000);
            kbb1.info();

            kbb2.withdraw(10000);
            kbb2.info();
        }
    }
}
