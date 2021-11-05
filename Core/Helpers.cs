using System;
using System.Collections.Generic;

namespace Core
{
    public static class Helpers
    {
        public static void Print<T>(this IEnumerable<T> source)
        {
            foreach(var s in source)
                Console.WriteLine($"{s}");
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
        
        public static void Log(int number)
        {
            Console.WriteLine($"Result: {number}");
        }
    }
}
