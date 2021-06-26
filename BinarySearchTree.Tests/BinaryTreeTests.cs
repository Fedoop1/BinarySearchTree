using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    [TestFixture]
    internal class BinaryTreeTests
    {
        [Test]
        public void BinaryTree_NullComparer_ThrowNewArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(comparer: null));

        [Test]
        public void BinaryTree_NullNodeData_ThrowNewArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new BinaryTree<string>(data: null));
    }
}
