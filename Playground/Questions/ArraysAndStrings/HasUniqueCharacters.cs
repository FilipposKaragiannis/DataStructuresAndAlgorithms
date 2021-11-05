namespace Playground.Questions.ArraysAndStrings
{
    public class HasUniqueCharacters
    {
        public static bool Assert(string text)
        {
            // assuming ascii characters
            // A-Z -> 65-91 in ascii table
            // a-z -> 97 - 121 in ascii table
            var charCount = new int[128];

            for(var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if(charCount[c] > 0)
                    return false;

                charCount[c] = 1;
            }

            return true;
        }
    }
}
