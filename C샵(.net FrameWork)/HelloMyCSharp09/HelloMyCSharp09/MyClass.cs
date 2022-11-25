using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp09
{
    public class MyClass :MyBase
    {
        public int num { get; set; }
        public void printMsg(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg + "Test" + num);
        }

        private static MyClass _instance = null;
        private MyClass()
        {
        
        }

        //c#스타일
        public static MyClass getInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new MyClass();
                return _instance;
            }
        }
        //자바스타일
        public static MyClass _getInstance()
        {

            if (_instance == null)
                _instance = new MyClass();
            return _instance;

        }

        public override void print(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg);
        }
    }
}
