using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalendar2;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCalendar m = new MyCalendar();
            m.Book(10, 20); // returns true
            m.Book(50, 60); // returns true
            m.Book(10, 40); // returns true
            m.Book(5, 15); // returns false
            m.Book(5, 10); // returns true
            m.Book(25, 55); // returns true
        }
    }
}
