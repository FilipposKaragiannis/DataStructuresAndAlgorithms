using System;
using System.Linq;

namespace Playground.Questions.ArraysAndStrings
{
    public class IsPermutation
    {
        public static bool Assert(string a, string b)
        {
            if(a.Length != b.Length)
                return false;
            
            var aCount = GetCharCounts(a);
            var bCount = GetCharCounts(b);

            for(var i = aCount.Length - 1; i >= 0; i--)
            {
                if(aCount[i] != bCount[i])
                    return false;
            }

            return true;
        }

        private static int[] GetCharCounts(string s)
        {
            var arr = new int[26];

            foreach(var charIndex in s.Select(t => (int)t))
                arr[charIndex - 97]++;

            return arr;
        }
    }
}
