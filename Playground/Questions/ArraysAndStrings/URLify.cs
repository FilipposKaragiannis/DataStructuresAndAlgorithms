using System.Text;

namespace Playground.Questions.ArraysAndStrings
{
    public class URLify
    {
        public string Execute(string s, int length)
        {
            if(length <= 1 || string.IsNullOrWhiteSpace(s))
                return s;

            var spaceChar = "%20";

            s = s.Trim();
            var sb = new StringBuilder();
            foreach(var c in s)
            {
                if(c == ' ')
                    sb.Append(spaceChar);
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
