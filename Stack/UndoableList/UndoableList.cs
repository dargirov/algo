using System;
using List;
using IStack;
using ListStack;

namespace UndoableList
{
    public class UndoableList<T>: IList<T>
    {
        private IStack<UndoAction> stack;
        private IList<T> list;

        public UndoableList(IList<T> list)
        {
            this.list = list;
            this.stack = new ListStack<UndoAction>();
        }

        private interface UndoAction
        {
            void Execute();
        }

        private class UndoInsertAction<T>: UndoAction
        {
            private int index;
            private UndoableList<T> parent;

            public UndoInsertAction(UndoableList<T> parent, int index)
            {
                this.parent = parent;
                this.index = index;
            }

            public void Execute()
            {
                this.parent.list.Delete(this.index);
            }
        }

        public void Insert(int index, T value)
        {
            this.list.Insert(index, value);
            this.stack.Push(new UndoInsertAction<T>(this, index));

        }

        public void Add(T value)
        {
            this.Insert(this.GetSize(), value);
        }

        private class UndoDeleteAction<T>: UndoAction
        {
            private int index;
            private T value;
            private UndoableList<T> parent;

            public UndoDeleteAction(UndoableList<T> parent, int index, T value)
            {
                this.parent = parent;
                this.index = index;
                this.value = value;
            }

            public void Execute()
            {
                this.parent.list.Insert(this.index, this.value);
            }
        }

        public T Delete(int index)
        {
            var value = this.list.Delete(index);
            this.stack.Push(new UndoDeleteAction<T>(this, index, value));
            return value;
        }

        public void Clear()
        {
            this.list.Clear();
            this.stack.Clear();
        }

        private class UndoSetAction<T>: UndoAction
        {
            private int index;
            private T value;
            private UndoableList<T> parent;

            public UndoSetAction(UndoableList<T> parent, int index, T value)
            {
                this.parent = parent;
                this.index = index;
                this.value = value;
            }

            public void Execute()
            {
                parent.list.Set(this.index, this.value);
            }
        }

        public T Set(int index, T value)
        {
            var result = this.list.Set(index, value);
            this.stack.Push(new UndoSetAction<T>(this, index, result));
            return result;
        }

        public T Get(int index)
        {
            return this.list.Get(index);
        }

        public int IndexOf(T value)
        {
            return this.list.IndexOf(value);
        }

        public bool Contains(T value)
        {
            return this.list.Contains(value);
        }

        public int GetSize()
        {
            return this.list.GetSize();
        }

        public bool IsEmpty()
        {
            return this.list.IsEmpty();
        }

        public IIterator<T> Iterator()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            ((UndoAction) this.stack.Pop()).Execute();
        }

        public bool CanUndo()
        {
            return !this.stack.IsEmpty();
        }
    }
}
