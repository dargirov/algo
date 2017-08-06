using System;
using System.Collections.Generic;

namespace Hashtable
{
    public class BucketingHashtable<T> : IHashtable<T> where T : IComparable
    {
        private double _loadFactor;
        private IList<T>[] _buckets;
        public int Size { get; private set; }

        public BucketingHashtable(int initialCapacity, double loadFactor)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentException("Initial capacity cant be less than 1");
            }

            _loadFactor = loadFactor;
            _buckets = new List<T>[initialCapacity];
        }

        public void Add(T value)
        {
            var bucket = BucketFor(value);

            if (!bucket.Contains(value))
            {
                bucket.Add(value);
                Size++;
                MaintainLoad();
            }
        }

        private void MaintainLoad()
        {
            if (LoadFactorExceed())
            {
                Resize();
            }
        }

        private void Resize()
        {
            var copy = new BucketingHashtable<T>(_buckets.GetLength(0) * 2, _loadFactor);

            for (int i = 0; i < _buckets.GetLength(0); i++)
            {
                if (_buckets[i] != null)
                {
                    copy.AddAll(_buckets[i]);
                }
            }
        }

        private void AddAll(IList<T> list)
        {
            foreach (var item in list)
            {
                Add(item);
            }
        }

        private bool LoadFactorExceed()
        {
            return Size > _buckets.GetLength(0) * _loadFactor;
        }

        private IList<T> BucketFor(T value)
        {
            int bucketIndex = BucketIndexFor(value);
            var bucket = _buckets[bucketIndex];

            if (bucket == null)
            {
                bucket = new List<T>();
                _buckets[bucketIndex] = bucket;
            }

            return bucket;
        }

        private int BucketIndexFor(T value)
        {
            return Math.Abs(value.GetHashCode() % _buckets.GetLength(0));
        }

        public bool Contains(T value)
        {
            var bucket = _buckets[BucketIndexFor(value)];
            return bucket?.Contains(value) ?? false;
        }
    }
}
