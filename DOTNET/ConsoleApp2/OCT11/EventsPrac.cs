using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT10.EventsPrac
{
    public delegate void MyEventHandler(object sender, EventArgs e);
    //In the example above,
    //MyEventHandler is a delegate that can point to methods taking
    //two parameters - an object (sender) and an EventArgs object (e),
    //which is often used for event data.

    //public event MyEventHandler SomeEvent;
    internal class EventsPrac
    {
        public static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            list1.Add(3);

        }
    }
}
