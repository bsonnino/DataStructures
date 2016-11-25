﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class TreeNode<T> where T : IComparable<T>
    {

        public TreeNode()
        {
            Left = null;
            Right = null;
        }

        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }


    public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        TreeNode<T> _root;
        TreeNode<T> _currentNode;
        int _count;

        public TreeNode<T> Root => _root;

        public void Add(T data)
        {
            var treenode = new TreeNode<T>() { Data = data };
            if (_root == null)
            {
                _root = treenode;
                _count++;
                return;
            }
            _currentNode = _root;
            while (true)
            {
                var comparison = treenode.Data.CompareTo(_currentNode.Data);
                if (comparison == 0)
                    throw new InvalidOperationException("Data already in the tree");
                if (comparison < 0)
                {
                    if (_currentNode.Left != null)
                        _currentNode = _currentNode.Left;
                    else
                    {
                        _currentNode.Left = treenode;
                        _count++;
                        break;
                    }
                }
                else
                {
                    if (_currentNode.Right != null)
                        _currentNode = _currentNode.Right;
                    else
                    {
                        _currentNode.Right = treenode;
                        _count++;
                        break;
                    }
                }
            }
        }

        public bool Exists(T obj)
        {
            if (_root == null)
                return false;
            TreeNode<T> currentNode = _root;
            while (true)
            {
                int comparison = obj.CompareTo(currentNode.Data);
                if (comparison < 0)
                {
                    if (currentNode.Left != null)
                        currentNode = currentNode.Left;
                    else
                        return false;
                }
                else if (comparison > 0)
                {
                    if (currentNode.Right != null)
                        currentNode = currentNode.Right;
                    else
                        return false;
                }
                else
                    return true;
            }
        }

        public string TraverseTree()
        {
            if (_root == null)
                return "";
            var sb = new StringBuilder();
            TraverseNode(_root, sb);
            return sb.ToString();
        }

        private void TraverseNode(TreeNode<T> node, StringBuilder sb)
        {
            sb.AppendLine(node.Data.ToString());
            if (node.Left != null)
                TraverseNode(node.Left, sb);
            if (node.Right != null)
                TraverseNode(node.Right, sb);
        }

        public Tuple<TreeNode<T>, TreeNode<T>> FindParentAndNode(T obj)
        {
            TreeNode<T> currentNode = _root;
            TreeNode<T> parentNode = null;
            while (true)
            {
                int comparison = obj.CompareTo(currentNode.Data);
                if (comparison < 0)
                {
                    if (currentNode.Left != null)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.Left;
                    }
                    else
                        return null;
                }
                else if (comparison > 0)
                {
                    if (currentNode.Right != null)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.Right;
                    }
                    else
                        return null;
                }
                else
                    return Tuple.Create(parentNode, currentNode);
            }
        }

        public int Count => _count;

        public bool Remove(T obj)
        {
            var nodeAndParent = FindParentAndNode(obj);
            if (nodeAndParent == null)
                return false;
            var parent = nodeAndParent.Item1;
            var currentNode = nodeAndParent.Item2;

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (parent == null)
                    _root = null;
                else if (parent.Left == currentNode)
                    parent.Left = null;
                else
                    parent.Right = null;
                _count--;
                return true;
            }

            if (currentNode.Left == null)
            {
                if (parent == null)
                    _root = currentNode.Right;
                else if (parent.Left == currentNode)
                    parent.Left = currentNode.Right;
                else
                    parent.Right = currentNode.Right;
                _count--;
                return true;
            }

            if (currentNode.Right == null)
            {
                if (parent == null)
                    _root = currentNode.Left;
                else if (parent.Left == currentNode)
                    parent.Left = currentNode.Left;
                else
                    parent.Right = currentNode.Left;
                _count--;
                return true;
            }

            var parentAndPredecessor = FindParentAndPredecessor(currentNode);
            var predParent = parentAndPredecessor.Item1;
            var pred = parentAndPredecessor.Item2;
            if (predParent == currentNode)
            {
                if (parent.Left == currentNode)
                {
                    parent.Left = pred;
                    pred.Right = currentNode.Right;
                }
                else
                {
                    parent.Right = pred;
                    pred.Right = currentNode.Right;
                }
            }
            else
            {
                predParent.Right = pred.Left;
                currentNode.Data = pred.Data;
            }
            return false;
        }

        private Tuple<TreeNode<T>, TreeNode<T>> FindParentAndPredecessor(TreeNode<T> currentNode)
        {
            var parent = currentNode;
            var pred = currentNode.Left;
            while (pred.Right != null)
            {
                parent = pred;
                pred = parent.Right;
            }
            return Tuple.Create(parent, pred);
        }

        private IEnumerable<T> VisitNode(TreeNode<T> node)
        {
            if (node.Left != null)
                foreach (var data in VisitNode(node.Left))
                    yield return data;
            yield return node.Data;
            if (node.Right != null)
                foreach (var data in VisitNode(node.Right))
                    yield return data;
        }

        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_root == null)
                yield break;
            foreach (var data in VisitNode(_root))
                yield return data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
