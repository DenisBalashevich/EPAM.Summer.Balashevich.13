using System;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTreeTask
{
    /// <summary>
    /// Data binary finder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Tree<T> : IEnumerable<T>
    {
        #region properties
        Node _root;

        public IComparer<T> Comparator { get; set; }
        #endregion

        #region Constructors
        public Tree() : this(Comparer<T>.Default, null) { }

        public Tree(T elem) : this(Comparer<T>.Default)
        {
            Add(elem);
        }

        public Tree(IEnumerable<T> elems) : this(Comparer<T>.Default, elems) { }

        public Tree(IComparer<T> comparer) : this(comparer, null) { }

        public Tree(Comparison<T> comparer) : this(new Adapter(comparer), null) { }

        public Tree(Comparison<T> comparer, IEnumerable<T> elems) : this(new Adapter(comparer), elems) { }

        public Tree(IComparer<T> comparer, IEnumerable<T> elems)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException();

            try
            {
                comparer.Compare(default(T), default(T));
            }
            catch (Exception)
            {
                throw new ArgumentException("Can't compare objects");
            }
            Comparator = comparer;

            if (ReferenceEquals(elems, null))
                return;
            else Add(elems);
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="newElement"></param>
        public void Add(T newElement)
        {
            if (ReferenceEquals(newElement, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(_root, null))
            {
                _root = new Node(newElement);
                return;
            }

            Add(_root, newElement);
        }

        /// <summary>
        /// Add collection
        /// </summary>
        /// <param name="newElements"></param>
        public void Add(IEnumerable<T> newElements)
        {
            if (ReferenceEquals(newElements, null))
                throw new ArgumentNullException();
            foreach (var a in newElements)
                Add(a);
        }

        /// <summary>
        /// Find element
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public bool Find(T temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            Node node = _root;
            while (node != null)
            {
                if (Comparator.Compare(node.Data, temp) < 0)
                    node = node.Right;
                else if (Comparator.Compare(node.Data, temp) > 0)
                    node = node.Left;
                else return true;
            }
            return false;
        }

        /// <summary>
        /// Find Min
        /// </summary>
        /// <returns></returns>
        public T Min()
        {
            Node node = _root;
            while (true)
            {
                if (!ReferenceEquals(null, node.Left))
                    node = node.Left;
                else return node.Data;
            }
        }

        /// <summary>
        /// Find Max
        /// </summary>
        /// <returns></returns>
        public T Max()
        {
            Node node = _root;
            while (true)
            {
                if (!ReferenceEquals(null, node.Right))
                    node = node.Right;
                else return node.Data;
            }
        }

        /// <summary>
        /// Inorder goes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InOrder() => InOrder(_root);

        /// <summary>
        /// Preorder goes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PreOrder() => PreOrder(_root);

        /// <summary>
        /// Postorder goes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostOrder() => PostOrder(_root);

        #endregion

        #region Iterator
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var a in PreOrder())
                yield return a;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private Methods
        IEnumerable<T> InOrder(Node node)
        {
            if (!ReferenceEquals(node.Left, null))
                foreach (var value in InOrder(node.Left))
                    yield return value;
            yield return node.Data;
            if (!ReferenceEquals(node.Right, null))
                foreach (var value in InOrder(node.Right))
                    yield return value;
        }

        IEnumerable<T> PreOrder(Node node)
        {
            yield return node.Data;
            if (node.Left != null)
                foreach (var value in PreOrder(node.Left))
                    yield return value;
            if (node.Right != null)
                foreach (var value in PreOrder(node.Right))
                    yield return value;
        }



        IEnumerable<T> PostOrder(Node node)
        {
            if (!ReferenceEquals(node.Left, null))
                foreach (var value in PostOrder(node.Left))
                    yield return value;
            if (!ReferenceEquals(node.Right, null))
                foreach (var value in PostOrder(node.Right))
                    yield return value;
            yield return node.Data;
        }

        /// <summary>
        /// Add elements
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="newElement"></param>
        private void Add(Node currentNode, T newElement)
        {

            if (Comparator.Compare(newElement, currentNode.Data) > 0)
            {
                if (currentNode.Right == null)
                    currentNode.Right = new Node(newElement);
                else Add(currentNode.Right, newElement);
            }
            else
            {
                if (currentNode.Left == null)
                    currentNode.Left = new Node(newElement);
                else
                    Add(currentNode.Left, newElement);
            }
        }

        #endregion

        #region private Subclasses
        /// <summary>
        /// class represents Node of Binary Tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public Node() { }
            public Node(T Element)
            {
                Data = Element;
            }

        }
        /// <summary>
        /// class Adapt Comparision anr IComparer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Adapter : IComparer<T>
        {
            private readonly Comparison<T> comparer;
            public Adapter(Comparison<T> del)
            {
                comparer = del;
            }
            public int Compare(T a, T b)
            {
                return comparer(a, b);
            }
        }
        #endregion

    }
}
