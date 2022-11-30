using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp02_02
{
    //KBBank를 상속한 클래스
    //KBBank에 있는 메소드, 변수 등을 다 쓸 수 있음
    public class KyungBank: KBBank
    {

        public KyungBank(string Name)
        {
            this.Name = Name;
        }
        public void withdraw(int money)
        {
            this.Balance -= money;
        }
        public void saving(int money) 
        {
            this.Balance += money;
        }
    }
}
