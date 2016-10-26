using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{    
    public class CircularBuffer<T>  : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (_queue.Count > _capacity)
            {
                var discarded = _queue.Dequeue();
                OnItemDiscarded(discarded, value);
            }
        }

        private void OnItemDiscarded(T discarded, T value)
        {
            if (ItemDiscarded != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discarded, value);
                ItemDiscarded(this, args);
            }
        }

        public bool IsFull { get { return _queue.Count == _capacity; } }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discarded, T newItem)
        {
            ItemDiscarded = discarded;
            ItemAdded = newItem;
        }
        public T ItemDiscarded { get; set; }
        public T ItemAdded { get; set; }
    }
}
