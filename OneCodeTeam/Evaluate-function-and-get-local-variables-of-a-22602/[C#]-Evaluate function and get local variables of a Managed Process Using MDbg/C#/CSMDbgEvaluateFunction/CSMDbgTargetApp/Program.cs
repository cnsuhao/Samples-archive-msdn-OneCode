using System;
using System.Diagnostics;

namespace CSMDbgTargetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Process.GetCurrentProcess().Id);

                TargetClass target = new TargetClass();
                target.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }   
    }
}
