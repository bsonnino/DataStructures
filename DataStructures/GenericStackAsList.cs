using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class StackAsList<T> : IEnumerable<T>
    {

        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        public void Push(T obj)
        {
            _linkedList.InsertAt(0, obj);
        }

        public T Peek()
        {
            if (_linkedList.Count == 0)
                throw (new InvalidOperationException("The stack is empty"));
            return _linkedList[0];
        }

        public T Pop()
        {
            if (_linkedList.Count == 0)
                throw (new InvalidOperationException("The stack is empty"));
            var result = _linkedList[0];
            _linkedList.RemoveAt(0);
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
