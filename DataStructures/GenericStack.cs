using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Stack<T> : IEnumerable<T>
    {

        private NodeList<T> _top;
        private int _count;
        private NodeList<T> _currentItem;

        public void Push(T obj)
        {
            var node = new NodeList<T>
            {
                Data = obj,
                Next = _top
            };
            _top = node;
            _count++;
        }

        public T Peek()
        {
            if (_top != null)
                return _top.Data;
            throw (new InvalidOperationException("The stack is empty"));
        }

        public T Pop()
        {
            if (_top == null)
                throw (new InvalidOperationException("The stack is empty"));
            var result = _top;
            _top = _top.Next;
            _count--;
            return result.Data;
        }

        public int Count => _count;

        public void Clear()
        {
            _top = null;
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
