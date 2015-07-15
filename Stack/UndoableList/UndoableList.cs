using System;
using List;
using IStack;
using ListStack;

namespace UndoableList
{
    public class UndoableList<T>: IList<T>
    {
        private IStack<T> stack;
        private IList<T> list;

        public UndoableList(IList<T> list)
        {
            this.list = list;
            this.stack = new ListStack<T>();
        }
    }
}
