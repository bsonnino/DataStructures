using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class QueueAsList<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        public void Enqueue(T obj)
        {
            _linkedList.Insert(obj);
        }

        public T Dequeue()
        {
            if (_linkedList.Count == 0)
                throw (new InvalidOperationException("The queue is empty"));
            var result = _linkedList[0];
            _linkedList.Remove(result);
            return result;
        }

        public int Count => _linkedList.Count;

        public void Clear()
        {
            _linkedList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
