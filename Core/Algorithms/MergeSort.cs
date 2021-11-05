namespace Core.Algorithms
{
    public class MergeSort
    {
        public void Sort(int start, int end, int[] source)
        {
            if(start >= end)
                return;

            int mid = (start + end) / 2;
            
            Sort(start, mid, source);
            Sort(mid + 1, end, source);

            Merge(start, mid, end, source);
        }

       
        private void Merge(int start, int mid, int end, int[] source)
        {
            var leftPart  = new int[mid       - start + 1];
            var rightPart = new int[end - mid];

            for(var i = 0; i < leftPart.Length; i++)
                leftPart[i] = source[start + i];

            for(var j = 0; j < rightPart.Length; j++)
                rightPart[j] = source[mid + j + 1];

            var s     = 0;
            var m     = 0;
            var index = start;
            
            while(s < leftPart.Length && m < rightPart.Length)
            {
                if(leftPart[s] <= rightPart[m])
                    source[index++] = leftPart[s++];
                else
                    source[index++] = rightPart[m++];
            }

            while(s < leftPart.Length)
                source[index++] = leftPart[s++];

            while(m < rightPart.Length)
                source[index++] = rightPart[m++];
        }
        
    }
}
