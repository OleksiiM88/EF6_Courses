using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var course = new Courses();
            course.Level = CourseLevel.Advance;
            Console.ReadLine();
        }
    }
}
