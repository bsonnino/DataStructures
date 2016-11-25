using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataStructures.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void CreateTreeCountIs0()
        {
            var tree = new Tree<string>();
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void AddItemCountIs1()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void AddItemExistsTrue()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            Assert.IsTrue(tree.Exists("test"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddItemDuplicateThrows()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            tree.Add("test");
        }

        [TestMethod]
        public void AddThreeItemsThirdExists()
        {
            var items = new[] { "one", "two", "three" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item);
            }
            Assert.IsTrue(tree.Exists("three"));
        }

        [TestMethod]
        public void AddUnorderedItemsItemsExists()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            foreach (var item in items.OrderBy(i => i))
            {
                Assert.IsTrue(tree.Exists(item.ToString("00")));
            }
        }

        [TestMethod]
        public void AddThreeItemsFindThirdReturnsThirdAndSecond()
        {
            var items = new[] { "one", "two", "three" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item);
            }
            var actual = tree.FindParentAndNode("three");
            Assert.IsTrue(actual.Item1.Data == "two" && actual.Item2.Data == "three");
        }

        [TestMethod]
        public void AddUnorderedItemsFindRootReturnsNullAndRoot()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }

            var actual = tree.FindParentAndNode("12");
            Assert.IsTrue(actual.Item1 == null && actual.Item2.Data == "12");
        }

        [TestMethod]
        public void AddUnorderedItemsFindNonExistingItemReturnsNull()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }

            var actual = tree.FindParentAndNode("99");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void AddUnorderedItemsFindExistingItemReturnsNodeAndParent()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }

            var actual = tree.FindParentAndNode("34");
            Assert.IsTrue(actual.Item1.Data == "25" && actual.Item2.Data == "34");
        }

        [TestMethod]
        public void AddUnorderedItemsFindExistingItemReturnsNodeAndParent2()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }

            var actual = tree.FindParentAndNode("18");
            Assert.IsTrue(actual.Item1.Data == "12" && actual.Item2.Data == "18");
        }

        [TestMethod]
        public void AddItemRemoveItemCountIs0()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            tree.Remove("test");
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void AddItemRemoveItemDoesntExist()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            tree.Remove("test");
            Assert.IsFalse(tree.Exists("test"));
        }

        [TestMethod]
        public void CreateTreeTraverseTreeReturnsEmpty()
        {
            var tree = new Tree<string>();
            Assert.AreEqual("", tree.TraverseTree());
        }

        [TestMethod]
        public void AddItemTraverseTreeReturnsItem()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            var treeNodes = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(1, treeNodes.Length);
            Assert.AreEqual("test", treeNodes[0]);
        }

        [TestMethod]
        public void AddItemsTraverseTreeReturnsItemLeftAndRight()
        {
            var tree = new Tree<string>();
            tree.Add("10");
            tree.Add("15");
            tree.Add("05");
            var treeNodes = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(3, treeNodes.Length);
            Assert.AreEqual("10", treeNodes[0]);
            Assert.AreEqual("05", treeNodes[1]);
            Assert.AreEqual("15", treeNodes[2]);
        }

        [TestMethod]
        public void AddUnorderedItemsTraverseTreeReturnsTraversed()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "12", "04", "05", "07", "18", "25", "19", "34", "92", "45", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }

            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }

        [TestMethod]
        public void AddUnorderedItemsRemoveLeafTraverseTreeReturnsTraversed()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "12", "04", "05", "07", "18", "25", "34", "92", "45", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            tree.Remove("19");
            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }

        [TestMethod]
        public void AddUnorderedItemsRemoveWithOnlyLeftTraverseTreeReturnsTraversed()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "12", "04", "05", "07", "18", "25", "19", "34", "45", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            tree.Remove("92");
            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }

        [TestMethod]
        public void AddUnorderedItemsRemoveWithOnlyRightTraverseTreeReturnsTraversed()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "12", "05", "07", "18", "25", "19", "34", "92", "45", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            tree.Remove("04");
            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }

        [TestMethod]
        public void AddUnorderedItemsRemoveWithLeftAndRightParentNodeDeletedTraverseTreeReturnsTraversed()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "12", "04", "05", "07", "18", "25", "19", "34", "92", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            tree.Remove("45");
            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }

        [TestMethod]
        public void AddUnorderedItemsRemoveWithLeftAndRightParentNodeDeletedTraverseTreeReturnsTraversed2()
        {
            var items = new[] { 12, 4, 5, 7, 18, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "12", "04", "05", "07", "18", "19", "34", "92", "45", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            tree.Remove("25");
            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }
        [TestMethod]
        public void AddUnorderedItemsRemoveRootTraverseTreeReturnsTraversed()
        {
            var items = new[] { 12, 4, 5, 7, 18, 6, 25, 34, 19, 92, 45, 64, 35 };
            var traversedItems = new[] { "07", "04", "05", "06", "18", "25", "19", "34", "92", "45", "35", "64" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            tree.Remove("12");
            var actual = tree.TraverseTree().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(traversedItems[i], actual[i]);
            }
        }

        [TestMethod]
        public void AddItemRemoveItemTraverseTreeReturnsEmpty()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            tree.Remove("test");
            Assert.AreEqual("", tree.TraverseTree());
        }

        [TestMethod]
        public void CannotRemoveNonExistentItem()
        {
            var tree = new Tree<string>();
            tree.Add("test");
            Assert.IsFalse(tree.Remove("test1"));
            Assert.IsTrue(tree.Exists("test"));
        }

        [TestMethod]
        public void EmptyTreeGetItemsReturnsEmpty()
        {
            var tree = new Tree<string>();
            Assert.AreEqual(0, tree.Count());
        }

        [TestMethod]
        public void OneItemTreeGetItemsReturnsItem()
        {
            var tree = new Tree<string> {"test"};
            var items = tree.ToList();
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("test", items[0]);
        }


        [TestMethod]
        public void AddUnorderedItemsGetItemsReturnSorted()
        {
            var items = new[] { 12, 4, 5, 7, 18, 6, 25, 34, 19, 92, 45, 64, 35 };
            var sortedItems = new[] { "04", "05", "06", "07", "12", "18", "19", "25", "34", "35", "45", "64", "92" };
            var tree = new Tree<string>();
            foreach (var item in items)
            {
                tree.Add(item.ToString("00"));
            }
            var actual = tree.ToList();
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(sortedItems[i], actual[i]);
            }
        }

    }
}
