using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TimeStruct;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    [TestFixture]
    internal class BinaryTreeTimeStructTests
    {
        [TestCaseSource(typeof(TimeStructTestCaseSource), nameof(TimeStructTestCaseSource.TimeStructTestCaseForInOrder))]
        [Test]
        public void InOrderCustomComparerTimeStructTests(Time[] source, Time[] expected)
        {
            var tree = new BinaryTree<Time>(new TimeStructComparer());

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [TestCaseSource(typeof(TimeStructTestCaseSource), nameof(TimeStructTestCaseSource.TimeStructTestCaseForPreOrder))]
        [Test]
        public void PreOrderCustomComparerTimeStructTests(Time[] source, Time[] expected)
        {
            var tree = new BinaryTree<Time>(new TimeStructComparer());

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.PreOrder());
        }

        [TestCaseSource(typeof(TimeStructTestCaseSource), nameof(TimeStructTestCaseSource.TimeStructTestCaseForPostOrder))]
        [Test]
        public void PostOrderCustomComparerTimeStructTests(Time[] source, Time[] expected)
        {
            var tree = new BinaryTree<Time>(new TimeStructComparer());

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.PostOrder());
        }
    }
}
