using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMyCSharp09_01
{
    public class Notifier : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void notify(string msg)
        {
            foreach (IObserver o in observers)
                o.update(msg);
        }

        public void register(IObserver o)
        {
            observers.Add(o);
        }

        public void unregister(IObserver o)
        {
            observers.Remove(o);
        }
    }
}
