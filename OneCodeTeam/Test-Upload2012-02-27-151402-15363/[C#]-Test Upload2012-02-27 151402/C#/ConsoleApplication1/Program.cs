using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic expandoObject = new ExpandoObject();
            expandoObject.Hello = (Action)(() => Console.WriteLine("Hello, How are you?"));
            expandoObject.Name = "Matt";

            Console.WriteLine(expandoObject.Name);
            expandoObject.Hello();

            Console.WriteLine();
            Console.WriteLine();
            foreach(var prop in expandoObject.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name);
            }
        }
    }

}
