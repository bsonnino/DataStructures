using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void CreateLinkedListCountIs0()
        {
            var list = new LinkedList<string>();
            Assert.AreEqual(0,list.Count);
        }

        [TestMethod]
        public void CreateLinkedListGetItemsReturnsCount0()
        {
            var list = new LinkedList<string>();
            Assert.AreEqual(0,list.Count());
        }

        [TestMethod]
        public void InsertItemCountIs1()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void InsertItemCanGetItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            Assert.AreEqual("test", list[0]);
        }

        [TestMethod]
        public void InsertItemCanFindItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            var actual = list.Find("test");
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void NewListRemoveItemReturnsFalse()
        {
            var list = new LinkedList<string>();
            Assert.IsFalse(list.Remove("test"));
        }

        [TestMethod]
        public void InsertItemCanRemoveItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            Assert.IsTrue(list.Remove("test"));
        }

        [TestMethod]
        public void RemoveItemDecreaseCount()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Remove("test");
            Assert.AreEqual(0,list.Count);
        }

        [TestMethod]
        public void RemoveItemReturnsFalseNonExistent()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            Assert.IsFalse(list.Remove("other test"));
        }

        [TestMethod]
        public void RemoveItemNonExistentDontDecreaseCount()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Remove("other test");
            Assert.AreEqual(1,list.Count);
        }

        [TestMethod]
        public void InsertTwoItemsCountIs2()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void InsertTwoItemsRemoveFirstRemainsSecond()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            list.Remove("test");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("other test", list[0]);
        }

        [TestMethod]
        public void InsertTwoItemsRemoveSecondRemainsFirst()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            list.Remove("other test");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("test", list[0]);
        }

        [TestMethod]
        public void InsertTwoItemsGetItemsRetrievesItems()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            var items = list.ToList();
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("test",items[0]);
            Assert.AreEqual("other test",items[1]);
        }

        [TestMethod]
        public void InsertTwoItemsGetItemsCountEqualsCount()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            Assert.AreEqual(list.Count, list.Count());
        }

        [TestMethod]
        public void InsertTwoItemsDeleteOneItemGetItemsCountEqualsCount()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            list.Remove("test");
            Assert.AreEqual(list.Count, list.Count());
        }

        [TestMethod]
        public void InsertAt0NoItemsInsertItem()
        {
            var list = new LinkedList<string>();
            list.InsertAt(0,"test");
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertAtNegativeThrows()
        {
            var list = new LinkedList<string>();
            list.InsertAt(-1, "test");
        }

        [TestMethod]
        public void InsertAt0OneItemInsertItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.InsertAt(0, "new test");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("new test", list[0]);
        }

        [TestMethod]
        public void InsertAt1OneItemInsertItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.InsertAt(1, "new test");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("new test", list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertAt2OneItemThrows()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.InsertAt(2, "new test");
        }

        [TestMethod]
        public void InsertAt1TwoItemsInsertsInPosition()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            list.InsertAt(1, "new test");
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("new test", list[1]);
        }

        [TestMethod]
        public void ClearListResetsCountTo0()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ClearListCantGetItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Clear();
            var item = list[0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NewListThrowsGetItem()
        {
            var list = new LinkedList<string>();
            var item = list[0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NewListThrowsRemoveAt()
        {
            var list = new LinkedList<string>();
            list.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ListThrowsGetItemNegative()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            var item = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtThrowsItemNegative()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ListThrowsGetItemEqualCount()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            var item = list[1];
        }

        [TestMethod]
        public void RemoveAtReturnsTrueIfRemoved()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            Assert.IsTrue(list.RemoveAt(0));
        }

        [TestMethod]
        public void RemoveAtRemoveItem()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.RemoveAt(0);
            Assert.AreEqual(0,list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtThrowsItemEqualCount()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.RemoveAt(1);
        }

        [TestMethod]
        public void InsertTwoItemsRemoveAtFirstRemainsSecond()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            list.RemoveAt(0);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("other test", list[0]);
        }

        [TestMethod]
        public void InsertTwoItemsRemoveAtSecondRemainsFirst()
        {
            var list = new LinkedList<string>();
            list.Insert("test");
            list.Insert("other test");
            list.RemoveAt(1);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("test", list[0]);
        }
    }
}
