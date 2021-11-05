using System.Text;

namespace Playground.Questions.ArraysAndStrings
{
    public class Compressor
    {
        public string Execute(string s)
        {
            if(s.Length <= 2)
                return s;

            var sb = new StringBuilder();

            var runningCount = 1;
            var runningChar  = s[0];
            
            
            for(var i = 1; i < s.Length; i++)
            {
                if(s[i] == runningChar)
                {
                    runningCount++;
                }
                else
                {
                    sb.Append($"{runningChar}{runningCount}");
                    runningChar  = s[i];
                    runningCount = 1;
                }
                
                if(i == s.Length - 1)
                    sb.Append($"{runningChar}{runningCount}");
            }

            var result = sb.ToString();

            return s.Length > result.Length ? result : s;
        }
    }
}
