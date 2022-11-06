using System;

namespace targil0 
{
    partial class Program 
    {
        static void Main(string[] args)
        {
            Welcome6712();
            Welcome5260();
            Console.ReadKey();
        }

        static partial void Welcome5260();
        private static void Welcome6712()
        {
            Console.Write("Enter your name: ");
            string username = Console.ReadLine();
            Console.WriteLine("{0},welcome to my first console application", username);
        }
    }
}