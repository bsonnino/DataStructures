using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class NodeList<T>
    {
        public NodeList()
        {
            Next = null;
        }

        public T Data { get; set; }
        public NodeList<T> Next { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private NodeList<T> _top;
        private NodeList<T> _last;
        private int _count;
        private NodeList<T> _currentItem;

        public int Insert(T obj)
        {
            var node = new NodeList<T> { Data = obj };
            if (_top == null)
            {
                _top = node;
                _last = node;
            }
            else
            {
                _last.Next = node;
                _last = node;
            }
            _count++;
            return _count;
        }

        private NodeList<T> GetNodeAt(int position)
        {
            if (position < 0 || position >= _count)
                throw (new IndexOutOfRangeException());
            var current = _top;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public int InsertAt(int position, T obj)
        {
            if (position < 0)
                throw (new IndexOutOfRangeException());
            var node = new NodeList<T> { Data = obj };
            if (position == 0)
            {
                node.Next = _top;
                _top = node;
            }
            else
            {
                var current = GetNodeAt(position - 1);
                node.Next = current.Next;
                current.Next = node;
            }
            _count++;
            return _count;
        }

        public void Clear()
        {
            _top = null;
            _count = 0;
        }

        public int Count => _count;

        public T this[int index] => GetNodeAt(index).Data;

        public int Find(T obj)
        {
            if (Count == 0)
                return -1;
            NodeList<T> current = _top;
            int currentNo = 0;
            do
            {
                if (current.Data.Equals(obj))
                {
                    return currentNo;
                }
                current = current.Next;
                currentNo++;
            } while (current != null);
            return -1;
        }

        public bool Remove(T obj)
        {
            var currentItem = Find(obj);
            if (currentItem == -1)
                return false;
            if (currentItem == 0)
            {
                _top = _top.Next;
            }
            else
            {
                var previousNode = GetNodeAt(currentItem - 1);
                previousNode.Next = previousNode.Next.Next;
                if (previousNode.Next == null)
                    _last = previousNode;
            }
            _count--;
            return true;
        }

        public bool RemoveAt(int position)
        {
            if (position < 0 || position >= _count)
                throw (new IndexOutOfRangeException());
            if (position == 0)
            {
                _top = _top.Next;
            }
            else
            {
                var previousNode = GetNodeAt(position - 1);
                previousNode.Next = previousNode.Next.Next;
                if (previousNode.Next == null)
                    _last = previousNode;
            }
            _count--;
            return true;
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
