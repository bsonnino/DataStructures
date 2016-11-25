using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Queue<T> : IEnumerable<T>
    {
        private int _count;
        private NodeList<T> _last;
        private NodeList<T> _top;
        private NodeList<T> _currentItem;

        public void Enqueue(T obj)
        {
            NodeList<T> node = new NodeList<T>() { Data = obj };
            _count++;
            if (_last == null)
            {
                _last = _top = node;
                return;
            }
            _last.Next = node;
            _last = node;
        }

        public T Dequeue()
        {
            if (_top != null)
            {
                NodeList<T> result = _top;
                _top = _top.Next;
                _count--;
                return result.Data;
            }
            throw (new InvalidOperationException("The queue is empty"));
        }

        public int Count => _count;
        public void Clear()
        {
            _top = null;
            _last = null;
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0)
                yield break;
            _currentItem = _top;
            while (_currentItem != null)
            {
                yield return _currentItem.Data;
                _currentItem = _currentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
