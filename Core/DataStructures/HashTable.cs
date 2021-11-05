namespace Core.DataStructures
{
    public class HashTable
    {
        private readonly HashEntry[] array;
        private readonly int         initialSize = 15;

        public HashTable()
        {
            array = new HashEntry[initialSize];
        }

        public void Put(string key, string value)
        {
            var index = GetIndex(key);

            var entry    = array[index];
            var newEntry = new HashEntry(key, value);
            if(entry == null)
            {
                array[index] = newEntry;
                return;
            }

            entry.Add(newEntry);
        }

        public string Get(string key)
        {
            var index = GetIndex(key);

            var entry = array[index];

            return entry?.Find(key);
        }

        private int GetIndex(string key)
        {
            var hash = key.GetHashCode();

            //Ensure within range
            var index = hash & (0x7fffffff % initialSize);

            // Hack to force collision for testing
            if(key.Equals("John Smith") || key.Equals("Sandra Dee") || key.Equals("Tim Lee"))
                index = 4;

            return index;
        }
    }

    public class HashEntry
    {
        private readonly string    _key;
        private readonly string    _value;
        private          HashEntry _next;

        public HashEntry(string key, string value)
        {
            _key   = key;
            _value = value;
        }

        public void Add(HashEntry newEntry)
        {
            if(_next == null)
            {
                _next = newEntry;
                return;
            }

            var cur = _next;

            while(cur._next != null)
                cur = cur._next;

            cur._next = newEntry;
        }

        public string Find(string key)
        {
            if(_key == key)
                return _value;

            if(_next == null)
                return null;

            var cur = _next;

            while(cur != null)
            {
                if(cur._key == key)
                    return cur._value;

                cur = cur._next;
            }

            return null;
        }
    }
}
