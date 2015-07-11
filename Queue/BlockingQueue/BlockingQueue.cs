using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IQueue;
using ListQueue;

namespace BlockingQueue
{
    public class BlockingQueue<T>: IQueue<T>
    {
        private Object mutex = new Object();
        private IQueue<T> queue;
        private int maxSize;

        public BlockingQueue(int maxSize)
        {
            this.queue = new ListQueue<T>();
            this.maxSize = maxSize;
        }

        public BlockingQueue(): this(int.MaxValue)
        {
        }

        public void Enqueue(T value)
        {
            lock (this.mutex)
            {
                while (this.GetSize() == this.maxSize)
                {
                    this.WaitForNotification();
                }

                this.queue.Enqueue(value);
                Monitor.PulseAll(this.mutex);
            }
        }

        private void WaitForNotification()
        {
            Monitor.Wait(this.mutex);
        }

        public T Dequeue()
        {
            lock (this.mutex)
            {
                while (this.IsEmpty())
                {
                    this.WaitForNotification();
                }

                var value = this.queue.Dequeue();
                Monitor.PulseAll(this.mutex);
                return value;
            }
        }

        public void Clear()
        {
            lock (this.mutex)
            {
                this.queue.Clear();
                Monitor.PulseAll(this.mutex);
            }
        }

        public bool IsEmpty()
        {
            lock (this.mutex)
            {
                return this.queue.IsEmpty();
            }
        }

        public int GetSize()
        {
            lock (this.mutex)
            {
                return this.queue.GetSize();
            }
        }
    }
}
