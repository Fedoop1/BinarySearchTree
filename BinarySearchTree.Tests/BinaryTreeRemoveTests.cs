using System;
using NUnit.Framework;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    [TestFixture(new int[] { 3, 1, 2, 5, 4, 9, 7, 15 }, TypeArgs = new Type[] { typeof(int) })]
    internal class BinaryTreeRemoveTests<T>
    {
        private T[] source;

        public BinaryTreeRemoveTests(T[] source) => this.source = source;

        [Test]
        public void RemoveTests()
        {
            var tree = new BinaryTree<T>();

            foreach (var item in this.source)
            {
                tree.Add(item);
            }

            tree.Remove(this.source[^1]);
            int exptected = default;

            Assert.AreEqual(exptected, tree.Search(this.source[^1]));
        }
    }
}
