using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class QueueAsListTests
    {
        [TestMethod]
        public void CreateQueueCountIs0()
        {
            var queue = new QueueAsList<string>();
            Assert.AreEqual(0,queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateCannotDeque()
        {
            var queue = new QueueAsList<string>();
            queue.Dequeue();
        }

       [TestMethod]
        public void EnqueueItemCountIs1()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void EnqueueItemCanDequeueItem()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            Assert.AreEqual("test", queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueItemDequeueItemCountIs0()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            queue.Dequeue();
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void EnqueueTwoItemsCountIs2()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            queue.Enqueue("other test");
            Assert.AreEqual(2, queue.Count);
        }

        [TestMethod]
        public void EnqueueTwoItemsDequeuBottomItem()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            queue.Enqueue("other test");
            Assert.AreEqual("test", queue.Dequeue());
        }

        
        [TestMethod]
        public void EnqueueTwoItemsDequeueRemainsSecond()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            queue.Enqueue("other test");
            queue.Dequeue();
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("other test", queue.Dequeue());
        }

        [TestMethod]
        public void ClearQueueResetsCountTo0()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ClearQueueCantDequeueItem()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            queue.Clear();
            queue.Dequeue();
        }

        [TestMethod]
        public void QueueOneItemCanIterate()
        {
            var queue = new QueueAsList<string>();
            queue.Enqueue("test");
            foreach (var item in queue)
            {
                Assert.AreEqual("test", item);
            }
        }

        [TestMethod]
        public void QueueAddFiveItemsIterateInOrder()
        {
            var queue = new QueueAsList<int>();
            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }
            var num = 0;
            foreach (var item in queue)
            {
                Assert.AreEqual(num, item);
                num++;
            }
        }

        [TestMethod]
        public void QueueAddFiveItemsIterateCountRemains5()
        {
            var queue = new QueueAsList<int>();
            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }
            var num = 0;
            foreach (var item in queue)
            {
                Assert.AreEqual(num, item);
                num++;
            }
            Assert.AreEqual(5, queue.Count);
        }
    }
}
