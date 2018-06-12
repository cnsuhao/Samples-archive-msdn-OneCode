using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CSMDbgTargetApp
{
    class TargetClass
    {

        public TargetClass()
        {
        }

        public void Start()
        {

            while (true)
            {
                VoidMethod();

                IntegerMethod(DateTime.Now.Millisecond);

                StringMethod(DateTime.Now.ToString());

                GenericMethod(new List<int>(new int[] { 1, 2 }));
            }
        }

        private void VoidMethod()
        {
            Console.WriteLine("Entering VoidMethod...");


            Console.WriteLine("Exiting VoidMethod...");
        }

        private int IntegerMethod(int a)
        {
            Console.WriteLine("Entering IntegerMethod...");

            int b = a * 2;

            Console.WriteLine("Exiting IntegerMethod...");

            return b;
        }

        private string StringMethod(string a)
        {
            Console.WriteLine("Entering StringMethod...");
            string b = a.ToUpper();

            Console.WriteLine("Exiting StringMethod...");
            return b;
        }

        private string GenericMethod(List<int> keys)
        {

            var dic = new Dictionary<int, string>();
            dic.Add(1, "One");
            dic.Add(2, "Two");
            dic.Add(3, "Three");
            dic.Add(4, "Four");

            Console.WriteLine("Entering GenericMethod...");
            List<string> values = new List<string>();

            foreach (var key in keys)
            {

                if (dic.ContainsKey(key))
                {
                    values.Add(dic[key]);
                }
            }

            StringBuilder result = new StringBuilder();

            foreach (var value in values)
            {
                result.AppendFormat("{0},", value);
            }

            Console.WriteLine("Exiting GenericMethod...");
            return result.ToString();
        }
    }
}
