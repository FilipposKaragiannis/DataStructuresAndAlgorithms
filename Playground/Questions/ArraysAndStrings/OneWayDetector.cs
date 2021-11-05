namespace Playground.Questions.ArraysAndStrings
{
    public class OneWayDetector
    {
        public bool Assert(string s1, string s2)
        {
            if(s1.Length == 0)
                return s2.Length == 1;
            if(s2.Length == 0)
                return s1.Length == 1;

            if(s1.Length > s2.Length)
                return CheckForDelete(s1, s2);

            if(s1.Length == s2.Length)
                return CheckForReplace(s1, s2);

            return CheckForInsert(s1, s2);
        }

        private bool CheckForInsert(string s1, string s2)
        {
            var fixes = 0;
            var p     = 0;

            for(var i = 0; i < s1.Length; i++)
            {
                if(s1[i] == s2[p])
                {
                    p++;
                    continue;
                }

                if(fixes > 0)
                    return false;

                fixes++;
                p++;
            }

            return true;
        }

        private bool CheckForReplace(string s1, string s2)
        {
            var fixes = 0;

            for(var i = 0; i < s1.Length; i++)
            {
                if(s1[i] == s2[i])
                    continue;

                if(fixes > 0)
                    return false;

                fixes++;
            }

            return true;
        }

        private bool CheckForDelete(string s1, string s2)
        {
            var fixes = 0;
            var p     = 0;
            
            for(var i = 0; i < s1.Length; i++)
            {
                if(s1[i] == s2[p])
                {
                    p++;
                    continue;
                }

                if(fixes > 0)
                    return false;

                fixes++;
            }

            return true;
        }
    }
}
