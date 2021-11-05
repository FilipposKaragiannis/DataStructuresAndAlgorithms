using System;

namespace Playground.Questions.Classics
{
    public class FizzBuzz
    {
        public static void Print(int num)
        {
            for(var i = 1; i <= num; i++)
            {
                var s = string.Empty;

                if(i % 3 == 0)
                    s += "Fizz";

                if(i % 5 == 0)
                    s += "Buzz";
                
                
                if(string.IsNullOrEmpty(s))
                    Console.WriteLine(i);
                else
                    Console.WriteLine(s);
            }
        }
    }
}
