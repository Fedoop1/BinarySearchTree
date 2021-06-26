using System;
using System.Collections.Generic;
using Comparers;
using NUnit.Framework;
using TimeStruct;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    [TestFixture(new int[] { 3, 1, 2, 5, 4, 9, 7, 15 }, new int[] { 2, 1, 4, 7, 15, 9, 5, 3 }, false, TypeArgs = new Type[] { typeof(int) })] 
    [TestFixture(new int[] { 4, -7, -3, 2, 8, -9, 22, 15 }, new int[] { 2, -3, 15, 22, -9, 8, -7, 4 }, true, TypeArgs = new Type[] { typeof(int) })]
    [TestFixture(new string[] { "AA", "Little", "AAA", "Biker", "DotMatrix", "MoreThan", "Ping", "Successful" }, new string[] { "Ping", "Biker", "AAA", "MoreThan", "Successful", "DotMatrix", "Little", "AA" }, true, TypeArgs = new Type[] { typeof(string) })]
    [TestFixture(new string[] { "AA", "Little", "AAA", "Biker", "DotMatrix", "MoreThan", "Ping", "Successful" }, new string[] { "DotMatrix", "Biker", "AAA", "Successful", "Ping", "MoreThan", "Little", "AA" }, false, TypeArgs = new Type[] { typeof(string) })]
    internal class BinaryTreePostOrderTests<T> 
    {
        private T[] source;
        private T[] expected;
        private bool isCustomComparer;
        private IComparer<T> comparer = Comparer<T>.Default;

        public BinaryTreePostOrderTests(T[] source, T[] expected, bool isCustomComparer) => (this.source, this.expected, this.isCustomComparer) = (source, expected, isCustomComparer);

        [Test]
        public void PostOrderTests()
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

            CollectionAssert.AreEqual(this.expected, tree.PostOrder());
        }

        private static IComparer<T> CreateComparer(Type type) => type switch
        {
            _ when type == typeof(int) => (IComparer<T>)new IntegerByAbsComparer(),
            _ when type == typeof(string) => (IComparer<T>)new StringByLengthComparer(),
        };
    }
}
