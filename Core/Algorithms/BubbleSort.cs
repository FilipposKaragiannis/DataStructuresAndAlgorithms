namespace Core.Algorithms
{
    public class BubbleSort
    {
        /// <summary>
        ///  On each iteration our goal is to bubble up the largest element.
        ///  The sorted item index is updated on every iteration
        /// </summary>
        public int[] Sort(int[] source)
        {
            var l = source.Length;
            for(var i = 0; i < l - 1; i++)
                for(var j = 0; j< l - 1 - i; j++)
                    if(source[j] > source[j + 1])
                        (source[j], source[j + 1]) = (source[j + 1], source[j]);

            return source;
        }
    }
}
