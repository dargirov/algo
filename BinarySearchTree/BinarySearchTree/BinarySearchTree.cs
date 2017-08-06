using System;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> _root;

        public Node<T> Root => _root;

        public Node<T> Search(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Value cant be null");
            }

            var node = _root;

            while (node != null)
            {
                var cmp = value.CompareTo(node.Value);
                if (cmp == 0)
                {
                    break;
                }

                node = cmp < 0 ? node.Smaller : node.Larger;
            }

            return node;
        }

        public Node<T> Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Value cant be null");
            }

            Node<T> parent = null;
            var node = _root;

            int cmp = 0;
            while (node != null)
            {
                parent = node;
                cmp = value.CompareTo(node.Value);
                node = cmp < 0 ? node.Smaller : node.Larger;
            }

            var inserted = new Node<T>(value);
            inserted.Parent = parent;
            if (parent == null)
            {
                _root = inserted;
            }
            else if (cmp < 0)
            {
                parent.Smaller = inserted;
            }
            else
            {
                parent.Larger = inserted;
            }

            return inserted;
        }

        public Node<T> Delete(T value)
        {
            var node = Search(value);

            if (node == null)
            {
                return null;
            }

            var deleted = node.Smaller != null && node.Larger != null
                ? node.Successor() : node;

            var replacement = deleted.Smaller ?? deleted.Larger;
            if (replacement != null)
            {
                replacement.Parent = deleted.Parent;
            }

            if (deleted == _root)
            {
                _root = replacement;
            }
            else if (deleted.IsSmaller())
            {
                deleted.Parent.Smaller = replacement;
            }
            else
            {
                deleted.Parent.Larger = replacement;
            }

            if (deleted != node)
            {
                var deletedValue = node.Value;
                node.Value = deleted.Value;
                deleted.Value = deletedValue;
            }

            return deleted;
        }
    }
}
