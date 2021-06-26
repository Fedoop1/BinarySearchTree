using NUnit.Framework;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    [TestFixture]
    internal class BinaryTreeBookTests
    {
        [TestCaseSource(typeof(BookTestCaseSource), nameof(BookTestCaseSource.BookTestCaseForInOrder))]
        [Test]
        public void InOrderDefaultComparerBookTests(Book.Book[] source, Book.Book[] expected)
        {
            var tree = new BinaryTree<Book.Book>();

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [TestCaseSource(typeof(BookTestCaseSource), nameof(BookTestCaseSource.BookTestCaseForPreOrder))]
        [Test]
        public void PreOrderDefaultComparerBookTests(Book.Book[] source, Book.Book[] expected)
        {
            var tree = new BinaryTree<Book.Book>();

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.PreOrder());
        }

        [TestCaseSource(typeof(BookTestCaseSource), nameof(BookTestCaseSource.BookTestCaseForPostOrder))]
        [Test]
        public void PostOrderDefaultComparerBookTests(Book.Book[] source, Book.Book[] expected)
        {
            var tree = new BinaryTree<Book.Book>();

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.PostOrder());
        }

        [TestCaseSource(typeof(BookTestCaseSource), nameof(BookTestCaseSource.BookTestCaseForInOrderCustomComparer))]
        [Test]
        public void InOrderCustomComparerBookTests(Book.Book[] source, Book.Book[] expected)
        {
            var tree = new BinaryTree<Book.Book>(new Book.Comparators.BookByAuthorComparer());

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [TestCaseSource(typeof(BookTestCaseSource), nameof(BookTestCaseSource.BookTestCaseForPreOrderCustomComparer))]
        [Test]
        public void PreOrderCustomComparerBookTests(Book.Book[] source, Book.Book[] expected)
        {
            var tree = new BinaryTree<Book.Book>(new Book.Comparators.BookByAuthorComparer());

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.PreOrder());
        }

        [TestCaseSource(typeof(BookTestCaseSource), nameof(BookTestCaseSource.BookTestCaseForPostOrderCustomComparer))]
        [Test]
        public void PostOrderCustomComparerBookTests(Book.Book[] source, Book.Book[] expected)
        {
            var tree = new BinaryTree<Book.Book>(new Book.Comparators.BookByAuthorComparer());

            foreach (var item in source)
            {
                tree.Add(item);
            }

            CollectionAssert.AreEqual(expected, tree.PostOrder());
        }
    }
}
