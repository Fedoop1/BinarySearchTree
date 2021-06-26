using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1118 // Parameter should not span multiple lines

namespace BinarySearchTree.Tests
{
    internal static class BookTestCaseSource
    {
        public static IEnumerable<TestCaseData> BookTestCaseForInOrder
        {
            get
            {
                yield return new TestCaseData(
                    new Book.Book[]
                {
                    new Book.Book("test", "AA", "test", "11111111111"), 
                    new Book.Book("test", "Little", "test", "22222222222"), 
                    new Book.Book("test", "AAA", "test", "33333333333"),
                    new Book.Book("test", "Biker", "test", "44444444444"),
                    new Book.Book("test", "DotMatrix", "test", "55555555555"),
                    new Book.Book("test", "MoreThan", "test", "666666666666"),
                    new Book.Book("test", "Ping", "test", "77777777777"),
                    new Book.Book("test", "Successful", "test", "88888888888"),
                },
                    new Book.Book[]
                {
                    new Book.Book("test", "AA", "test", "11111111111"),
                    new Book.Book("test", "AAA", "test", "33333333333"),
                    new Book.Book("test", "Ping", "test", "77777777777"),
                    new Book.Book("test", "Biker", "test", "44444444444"),
                    new Book.Book("test", "Little", "test", "22222222222"),
                    new Book.Book("test", "MoreThan", "test", "666666666666"),
                    new Book.Book("test", "DotMatrix", "test", "55555555555"),
                    new Book.Book("test", "Successful", "test", "88888888888"),
                });
            }
        }

        public static IEnumerable<TestCaseData> BookTestCaseForPreOrder
        {
            get
            {
                yield return new TestCaseData(
                    new Book.Book[]
                {
                    new Book.Book("test", "AA", "test", "11111111111"),
                    new Book.Book("test", "Little", "test", "22222222222"),
                    new Book.Book("test", "AAA", "test", "33333333333"),
                    new Book.Book("test", "Biker", "test", "44444444444"),
                    new Book.Book("test", "DotMatrix", "test", "55555555555"),
                    new Book.Book("test", "MoreThan", "test", "666666666666"),
                    new Book.Book("test", "Ping", "test", "77777777777"),
                    new Book.Book("test", "Successful", "test", "88888888888"),
                },
                    new Book.Book[]
                {
                    new Book.Book("test", "AA", "test", "11111111111"),
                    new Book.Book("test", "Little", "test", "22222222222"),
                    new Book.Book("test", "AAA", "test", "33333333333"),
                    new Book.Book("test", "Biker", "test", "44444444444"),
                    new Book.Book("test", "Ping", "test", "77777777777"),
                    new Book.Book("test", "DotMatrix", "test", "55555555555"),
                    new Book.Book("test", "MoreThan", "test", "666666666666"),
                    new Book.Book("test", "Successful", "test", "88888888888"),
                });
            }
        }

        public static IEnumerable<TestCaseData> BookTestCaseForPostOrder
        {
            get
            {
                yield return new TestCaseData(
                    new Book.Book[]
                {
                    new Book.Book("test", "AA", "test", "11111111111"),
                    new Book.Book("test", "Little", "test", "22222222222"),
                    new Book.Book("test", "AAA", "test", "33333333333"),
                    new Book.Book("test", "Biker", "test", "44444444444"),
                    new Book.Book("test", "DotMatrix", "test", "55555555555"),
                    new Book.Book("test", "MoreThan", "test", "666666666666"),
                    new Book.Book("test", "Ping", "test", "77777777777"),
                    new Book.Book("test", "Successful", "test", "88888888888"),
                },
                    new Book.Book[]
                {
                    new Book.Book("test", "Ping", "test", "77777777777"),
                    new Book.Book("test", "Biker", "test", "44444444444"),
                    new Book.Book("test", "AAA", "test", "33333333333"),
                    new Book.Book("test", "MoreThan", "test", "666666666666"),
                    new Book.Book("test", "Successful", "test", "88888888888"),
                    new Book.Book("test", "DotMatrix", "test", "55555555555"),
                    new Book.Book("test", "Little", "test", "22222222222"),
                    new Book.Book("test", "AA", "test", "11111111111"),
                });
            }
        }

        public static IEnumerable<TestCaseData> BookTestCaseForInOrderCustomComparer
        {
            get
            {
                yield return new TestCaseData(
                    new Book.Book[]
                {
                    new Book.Book("AA", "test", "test", "11111111111"),
                    new Book.Book("Little", "test", "test", "22222222222"),
                    new Book.Book("AAA", "test", "test", "33333333333"),
                    new Book.Book("Biker", "test", "test", "44444444444"),
                    new Book.Book("DotMatrix", "test", "test", "55555555555"),
                    new Book.Book("MoreThan", "test", "test", "666666666666"),
                    new Book.Book("Ping", "Ping", "test", "77777777777"),
                    new Book.Book("Successful", "test", "test", "88888888888"),
                },
                    new Book.Book[]
                {
                    new Book.Book("AA", "test", "test", "11111111111"),
                    new Book.Book("AAA", "test", "test", "33333333333"),
                    new Book.Book("Ping", "test", "test", "77777777777"),
                    new Book.Book("Biker", "test", "test", "44444444444"),
                    new Book.Book("Little", "test", "test", "22222222222"),
                    new Book.Book("MoreThan", "test", "test", "666666666666"),
                    new Book.Book("DotMatrix", "test", "test", "55555555555"),
                    new Book.Book("Successful", "test", "test", "88888888888"),
                });
            }
        }

        public static IEnumerable<TestCaseData> BookTestCaseForPreOrderCustomComparer
        {
            get
            {
                yield return new TestCaseData(
                    new Book.Book[]
                {
                    new Book.Book("AA", "test", "test", "11111111111"),
                    new Book.Book("Little", "test", "test", "22222222222"),
                    new Book.Book("AAA", "test", "test", "33333333333"),
                    new Book.Book("Biker", "test", "test", "44444444444"),
                    new Book.Book("DotMatrix", "test", "test", "55555555555"),
                    new Book.Book("MoreThan", "test", "test", "666666666666"),
                    new Book.Book("Ping", "Ping", "test", "77777777777"),
                    new Book.Book("Successful", "test", "test", "88888888888"),
                },
                    new Book.Book[]
                {
                    new Book.Book("AA", "test", "test", "11111111111"),
                    new Book.Book("Little", "test", "test", "22222222222"),
                    new Book.Book("AAA", "test", "test", "33333333333"),
                    new Book.Book("Biker", "test", "test", "44444444444"),
                    new Book.Book("Ping", "test", "test", "77777777777"),
                    new Book.Book("DotMatrix", "test", "test", "55555555555"),
                    new Book.Book("MoreThan", "test", "test", "666666666666"),
                    new Book.Book("Successful", "test", "test", "88888888888"),
                });
            }
        }

        public static IEnumerable<TestCaseData> BookTestCaseForPostOrderCustomComparer
        {
            get
            {
                yield return new TestCaseData(
                    new Book.Book[]
                {
                    new Book.Book("AA", "test", "test", "11111111111"),
                    new Book.Book("Little", "test", "test", "22222222222"),
                    new Book.Book("AAA", "test", "test", "33333333333"),
                    new Book.Book("Biker", "test", "test", "44444444444"),
                    new Book.Book("DotMatrix", "test", "test", "55555555555"),
                    new Book.Book("MoreThan", "test", "test", "666666666666"),
                    new Book.Book("Ping", "Ping", "test", "77777777777"),
                    new Book.Book("Successful", "test", "test", "88888888888"),
                },
                    new Book.Book[]
                {
                    new Book.Book("Ping", "test", "test", "77777777777"),
                    new Book.Book("Biker", "test", "test", "44444444444"),
                    new Book.Book("AAA", "test", "test", "33333333333"),
                    new Book.Book("MoreThan", "test", "test", "666666666666"),
                    new Book.Book("Successful", "test", "test", "88888888888"),
                    new Book.Book("DotMatrix", "test", "test", "55555555555"),
                    new Book.Book("Little", "test", "test", "22222222222"),
                    new Book.Book("AA", "test", "test", "11111111111"),
                });
            }
        }
    }
}
