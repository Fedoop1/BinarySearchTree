using System;
using System.Collections.Generic;
using Comparers;
using NUnit.Framework;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    [TestFixture(new int[] { 3, 1, 2, 5, 4, 9, 7, 15 }, new int[] { 1, 2, 3, 4, 5, 7, 9, 15 }, false, TypeArgs = new Type[] { typeof(int) })]
    [TestFixture(new int[] { 4, -7, -3, 2, 8, -9, 22, 15 }, new int[] { 2, -3, 4, -7, 8, -9, 15, 22 }, true, TypeArgs = new Type[] { typeof(int) })]
    [TestFixture(new string[] { "AA", "Little", "AAA", "Biker", "DotMatrix", "MoreThan", "Ping", "Successful" }, new string[] { "AA", "AAA", "Ping", "Biker", "Little", "MoreThan", "DotMatrix", "Successful" }, true, TypeArgs = new Type[] { typeof(string) })]
    [TestFixture(new string[] { "AA", "Little", "AAA", "Biker", "DotMatrix", "MoreThan", "Ping", "Successful" }, new string[] { "AA", "AAA", "Biker", "DotMatrix", "Little", "MoreThan", "Ping", "Successful" }, false, TypeArgs = new Type[] { typeof(string) })]
    internal class BinaryTreeInOrderTests<T>
    {
        private T[] source;
        private T[] expected;
        private bool isCustomComparer;
        private IComparer<T> comparer = Comparer<T>.Default;

        public BinaryTreeInOrderTests(T[] source, T[] expected, bool isCustomComparer) => (this.source, this.expected, this.isCustomComparer) = (source, expected, isCustomComparer);

        [Test]
        public void InOrderTests()
        {
            if (this.isCustomComparer)
            {
                this.comparer = CreateComparer(typeof(T));    
            }

            var tree = new BinaryTree<T>(this.comparer);

            foreach (var item in this.source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(this.expected, tree.InOrder());
        }

        private static IComparer<T> CreateComparer(Type type) => type switch
        {
            _ when type == typeof(int) => (IComparer<T>)new IntegerByAbsComparer(),
            _ when type == typeof(string) => (IComparer<T>)new StringByLengthComparer(),
        };
    }
}
