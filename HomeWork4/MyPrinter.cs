using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public static class MyPrinter
    {
        public static void PrintExceptionsMessages(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            Console.Clear();
        }
        public static void Print<T>(T myObject, string message = "") where T : class
        {
            if(myObject is not null)
            {
                Console.WriteLine($"{message}\n {myObject}");
                Console.ReadLine();
            }  
        }

        public static void Print<T>(List<T> collection, string message = "") where T : class
        {
            if (collection is not null)
            {
                Console.WriteLine(message);
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }

        public static void Print<T, U>(T myCollection, string message = "") where T : class, IEnumerable<U>
        {
            if (myCollection is not null)
            {
                Console.WriteLine(message);
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
    }
}
