using System;
using System.Collections;

namespace CustomList
{
    public class VList<T> : IEnumerable<T>, IEnumerable
    {
        private T[] items;
        private int count;

        public VList(int capacity = 4)
        {
            items = new T[capacity];
            count = 0;
        }

        public void Add(T item)
        {
            if (count >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public void Remove(T item)
        {
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(items[i], item)) // ✅ Works for all types!
                    {
                        for (int j = i; j < count - 1; j++)
                        {
                            items[j] = items[j + 1];
                        }

                        if (items[count - 1] != null)
                        {
                            items[count - 1] = default!; // Suppress the nullability warning
                        }

                        count--;
                        return;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i]; // Yield each element one by one
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); // ✅ Now works correctly!

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }
    }
}
