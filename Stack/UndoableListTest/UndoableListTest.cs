using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListTests;
using List;
using UndoableList;

namespace UndoableListTest
{
    [TestClass]
    public class UndoableListTest : AbstractListTest
    {
        public UndoableListTest()
        {
        }

        protected override IList<int> CreateList()
        {
            return new UndoableList<int>(new LinkedList<int>());
        }

        [TestMethod]
        public void UndoInsertTest()
        {
            var list = this.CreateList();

            Assert.IsFalse(list.CanUndo());

            list.Insert(0, this.ValueA);
            Assert.IsTrue(list.CanUndo());

            list.Undo();
            Assert.AreEqual(0, list.GetSize());
            Assert.IsFalse(list.CanUndo());
        }

        [TestMethod]
        public void UndoAddTest()
        {
            var list = this.CreateList();

            Assert.IsFalse(list.CanUndo());

            list.Add(this.ValueA);
            Assert.IsTrue(list.CanUndo());

            list.Undo();
            Assert.AreEqual(0, list.GetSize());
            Assert.IsFalse(list.CanUndo());
        }

        [TestMethod]
        public void UndoDeleteByPosition()
        {
            var list = this.CreateList();
            list.Add(this.ValueA);
            list.Add(this.ValueB);

            Assert.AreEqual(this.ValueB, list.Delete(1));
            Assert.IsTrue(list.CanUndo());

            list.Undo();

            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(this.ValueA, list.Delete(0));
            Assert.AreEqual(this.ValueB, list.Delete(1));
            Assert.IsFalse(list.CanUndo());
        }
    }
}
