using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class StackAsListTests
    {
        [TestMethod]
        public void CreateStackCountIs0()
        {
            var stack = new StackAsList<string>();
            Assert.AreEqual(0,stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateCannotPop()
        {
            var stack = new StackAsList<string>();
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateCannotPeek()
        {
            var stack = new StackAsList<string>();
            stack.Peek();
        }

        [TestMethod]
        public void PushItemCountIs1()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushItemCanPopItem()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            Assert.AreEqual("test", stack.Pop());
        }

        [TestMethod]
        public void PushItemCanPeekItem()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            Assert.AreEqual("test", stack.Peek());
        }

        [TestMethod]
        public void PushItemPopItemCountIs0()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushItemPeekItemCountIs1()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Peek();
            Assert.AreEqual(1,stack.Count);
        }

        [TestMethod]
        public void PushTwoItemsCountIs2()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Push("other test");
            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod]
        public void PushTwoItemsPopTopItem()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Push("other test");
            Assert.AreEqual("other test", stack.Pop());
        }

        [TestMethod]
        public void PushTwoItemsPeekTopItem()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Push("other test");
            Assert.AreEqual("other test", stack.Peek());
        }

        [TestMethod]
        public void PushTwoItemsPopRemainsSecond()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Push("other test");
            stack.Pop();
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual("test", stack.Peek());
        }

        [TestMethod]
        public void ClearListResetsCountTo0()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Clear();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ClearListCantPopItem()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            stack.Clear();
            stack.Pop();
        }

        [TestMethod]
        public void StackOneItemCanIterate()
        {
            var stack = new StackAsList<string>();
            stack.Push("test");
            foreach (var item in stack)
            {
                Assert.AreEqual("test", item);
            }
        }

        [TestMethod]
        public void StackAddFiveItemsIterateInReverseOrder()
        {
            var stack = new StackAsList<int>();
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            var num = 4;
            foreach (var item in stack)
            {
                Assert.AreEqual(num, item);
                num--;
            }
        }

        [TestMethod]
        public void StackAddFiveItemsIterateCountRemains5()
        {
            var stack = new StackAsList<int>();
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            var num = 4;
            foreach (var item in stack)
            {
                Assert.AreEqual(num, item);
                num--;
            }
            Assert.AreEqual(5, stack.Count);
        }
    }
}
