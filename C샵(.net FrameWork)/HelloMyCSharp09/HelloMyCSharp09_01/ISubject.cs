using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp09_01
{
    public interface ISubject
    {
        void register(IObserver o);
        void unregister(IObserver o);
        void notify(string msg);
    }
}
