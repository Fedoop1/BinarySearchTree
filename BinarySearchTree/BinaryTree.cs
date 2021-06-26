using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary search tree instance.
    /// </summary>
    /// <typeparam name="T">Tree elements type.</typeparam>
    public class BinaryTree<T> 
    {
        private readonly IComparer<T> comparer = Comparer<T>.Default;
        private Node<T> root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="data">Root element data.</param>
        /// <param name="comparer">Custom comparer.</param>
        public BinaryTree(T data, IComparer<T> comparer) => (this.root, this.comparer) = ValidateRootAndComparer(data, comparer);

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="data">Root element data.</param>
        /// <exception cref="ArgumentNullException">Throws when data is null.</exception>
        public BinaryTree(T data) => this.root = new Node<T>(data);

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Throws when comparer is null.</exception>
        public BinaryTree(IComparer<T> comparer) => this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer), "Comparer is null");

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree()
        {
        }

        /// <summary>
        /// Add new tree element.
        /// </summary>
        /// <param name="data">New element data.</param>
        /// <exception cref="ArgumentNullException">Throws when data is null.</exception>
        public void Add(T data)
        {
            if (this.root is null)
            {
                this.root = new Node<T>(data);
                return;
            }

            var node = new Node<T>(data);

            this.Add(node, this.root);
        }

        /// <summary>
        /// Search element in tree.
        /// </summary>
        /// <param name="data">Data of element.</param>
        /// <returns><c>Element data</c> if find, otherwise <c>default type value</c>.</returns>
        public T Search(T data)
        {
            if (this.root is null)
            {
                return default;
            }

            return this.Search(data, this.root);
        }

        /// <summary>
        /// Remove element from tree.
        /// </summary>
        /// <param name="data">Value of element to remove.</param>
        public void Remove(T data)
        {
            if (this.root is null)
            {
                return;
            }

            this.root = this.Remove(data, this.root);
        }

        /// <summary>
        /// Iterate over the tree by pre-order method.
        /// </summary>
        /// <returns>Sequence of nodes in order root, left, right.</returns>
        public IEnumerable<T> PreOrder()
        {
            if (this.root is null)
            {
                return Array.Empty<T>();
            }

            return this.PreOrder(this.root);
        }

        /// <summary>
        /// Iterate over the tree by post-order method.
        /// </summary>
        /// <returns>Sequence of nodes in order left, right, root.</returns>
        public IEnumerable<T> PostOrder()
        {
            if (this.root is null)
            {
                return Array.Empty<T>();
            }

            return this.PostOrder(this.root);
        }

        /// <summary>
        /// Iterate over the tree by in-order method.
        /// </summary>
        /// <returns>Sequence of nodes in order left, root, right.</returns>
        public IEnumerable<T> InOrder()
        {
            if (this.root is null)
            {
                return Array.Empty<T>();
            }

            return this.InOrder(this.root);
        }

        private static (Node<T>, IComparer<T>) ValidateRootAndComparer(T rootData, IComparer<T> comparer) => (rootData, comparer) switch
        {
            (null, null) => throw new ArgumentNullException(nameof(rootData), "Data and comparer is null"),
            (null, _) => throw new ArgumentNullException(nameof(rootData), "Data is null"),
            (_, null) => throw new ArgumentNullException(nameof(rootData), "Comparer is null"),
            _ => (new Node<T>(rootData), comparer),
        };

        private static Node<T> FindMin(Node<T> currentNode)
        {
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        private IEnumerable<T> PostOrder(Node<T> currentNode)
        {
            if (currentNode.Left != null)
            {
                foreach (var leftNode in this.PostOrder(currentNode.Left))
                {
                    yield return leftNode;
                }
            }

            if (currentNode.Right != null)
            {
                foreach (var rightNode in this.PostOrder(currentNode.Right))
                {
                    yield return rightNode;
                }
            }

            yield return currentNode.Data;
        }

        private Node<T> Remove(T data, Node<T> currentNode)
        {
            if (currentNode is null)
            {
                return null;
            }

            switch (this.comparer.Compare(currentNode.Data, data))
            {
                case 0:
                    if (currentNode.Left is null)
                    {
                        return currentNode.Right;
                    }
                    else if (currentNode.Right is null)
                    {
                        return currentNode.Left;
                    }

                    currentNode = FindMin(currentNode.Right);
                    this.Remove(currentNode.Data, currentNode.Right);
                    return currentNode;
                case > 0:
                    return this.Remove(data, currentNode.Left);
                case < 0:
                    return this.Remove(data, currentNode.Right);
            }
        }

        private IEnumerable<T> InOrder(Node<T> currentNode)
        {
            if (currentNode.Left != null)
            {
                foreach (var leftNode in this.InOrder(currentNode.Left))
                {
                    yield return leftNode;
                }
            }

            yield return currentNode.Data;

            if (currentNode.Right != null)
            {
                foreach (var rightNode in this.InOrder(currentNode.Right))
                {
                    yield return rightNode;
                }
            }
        }

        private IEnumerable<T> PreOrder(Node<T> currentNode)
        {
            yield return currentNode.Data;

            if (currentNode.Left != null)
            {
                foreach (var leftNode in this.PreOrder(currentNode.Left))
                {
                    yield return leftNode;
                }
            }

            if (currentNode.Right != null)
            {
                foreach (var rightNode in this.PreOrder(currentNode.Right))
                {
                    yield return rightNode;
                }
            }
        }

        private T Search(T data, Node<T> currentNode)
        {
            if (currentNode is null)
            {
                return default;
            }

            return this.comparer.Compare(currentNode.Data, data) switch
            {
                0 => currentNode.Data,
                > 0 => this.Search(data, currentNode.Left),
                < 0 => this.Search(data, currentNode.Right),
            };
        }

        private void Add(Node<T> newNode, Node<T> currentNode)
        {
            if (this.comparer.Compare(currentNode.Data, newNode.Data) > 0)
            {
                if (currentNode.Left is null)
                {
                    currentNode.Left = newNode;
                    return;
                }

                this.Add(newNode, currentNode.Left);
            }
            else if (this.comparer.Compare(currentNode.Data, newNode.Data) < 0)
            {
                if (currentNode.Right is null)
                {
                    currentNode.Right = newNode;
                    return;
                }

                this.Add(newNode, currentNode.Right);
            }
        }

        private class Node<Type> 
            where Type : T
        {
            public Node(T data) => this.Data = data ?? throw new ArgumentNullException(nameof(data), "Data of node can't equals null");

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public T Data { get; }

            public override string ToString()
            {
                return $"Node data: {this.Data}.";
            }
        }
    }
}
