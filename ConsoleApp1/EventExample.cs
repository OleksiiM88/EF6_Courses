using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EventExample
    {
        public void Execute()
        {
            First firstClass = new First();
            Second secondClass = new Second();
            firstClass.myEvent += secondClass.SomeWorkHandler;
            firstClass.SomeWork();
            firstClass.myEvent.Invoke(3);
            GC.Collect(2, GCCollectionMode.Aggressive);

            int n = 0;
        }
    }

    internal class First()
    {
        public Action<int> myEvent;

        public void SomeWork()
        {
            myEvent?.Invoke(5);
        }
    }

    internal class Second() 
    {
        public void SomeWorkHandler(int n)
        {
            Console.WriteLine($"MySencondEventHandler {n}");
        }
    }
}
