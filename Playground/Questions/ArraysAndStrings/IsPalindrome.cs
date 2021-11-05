namespace Playground.Questions.ArraysAndStrings
{
    public class IsPalindrome
    {
        public static bool Assert(string s)
        {
            var length = s.Length;

            if(length <= 1)
                return true;


            for(var i = 0; i < length / 2; i++)
            {
                if(s[i] != s[length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
