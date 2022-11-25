using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HelloMyCSharp09_01
{
    //스타1의 옵저버1 
    public class Observer1 : IObserver
    {
        public string name { get; set; }
        public void update(string value)
        {
            name += value + ", "+name+", 님";
            System.Windows.Forms.MessageBox.Show(name);

        }
    }
}
