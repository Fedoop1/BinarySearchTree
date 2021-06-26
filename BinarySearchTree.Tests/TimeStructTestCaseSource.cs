using System.Collections.Generic;
using NUnit.Framework;
using TimeStruct;

#pragma warning disable SA1600 // Elements should be documented

namespace BinarySearchTree.Tests
{
    internal static class TimeStructTestCaseSource
    {
        public static IEnumerable<TestCaseData> TimeStructTestCaseForInOrder
        {
            get
            {
                yield return new TestCaseData(new Time[] { new Time(13), new Time(8), new Time(45), new Time(22), new Time(10) }, new Time[] { new Time(8), new Time(10), new Time(13), new Time(22), new Time(45) });
            }
        }

        public static IEnumerable<TestCaseData> TimeStructTestCaseForPreOrder
        {
            get
            {
                yield return new TestCaseData(new Time[] { new Time(13), new Time(8), new Time(45), new Time(22), new Time(10) }, new Time[] { new Time(13), new Time(8), new Time(10), new Time(45), new Time(22) });
            }
        }

        public static IEnumerable<TestCaseData> TimeStructTestCaseForPostOrder
        {
            get
            {
                yield return new TestCaseData(new Time[] { new Time(13), new Time(8), new Time(45), new Time(22), new Time(10) }, new Time[] { new Time(10), new Time(8), new Time(22), new Time(45), new Time(13) });
            }
        }
    }
}
