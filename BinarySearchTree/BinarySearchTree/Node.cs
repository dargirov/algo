using System;   

namespace BinarySearchTree
{
    public class Node<T> where T : IComparable
    {
        private Node<T> smaller;
        private Node<T> larger;

        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Smaller
        {
            get { return smaller; }
            set
            {
                if (value != null && value == Larger)
                {
                    throw new ArgumentException("smaller cant be same as larger");
                }

                smaller = value;
            }
        }

        public Node<T> Larger
        {
            get { return larger;  }
            set
            {
                if (value != null && value == Smaller)
                {
                    throw new ArgumentException("Larger cant be same as smaller");
                }

                larger = value;
            }
        }

        public Node(T value) : this(value, null, null)
        {
        }

        public Node(T value, Node<T> smaller, Node<T> larger)
        {
            Value = value;
            Smaller = smaller;
            Larger = larger;

            if (Smaller != null)
            {
                Smaller.Parent = this;
            }

            if (Larger != null)
            {
                Larger.Parent = this;
            }
        }

        public Node<T> Minimum()
        {
            var node = this;
            while (node.Smaller != null)
            {
                node = node.Smaller;
            }

            return node;
        }

        public Node<T> Maximum()
        {
            var node = this;
            while (node.Larger != null)
            {
                node = node.Larger;
            }

            return node;
        }

        public bool IsSmaller()
        {
            return Parent != null && this == Parent.Smaller;
        }

        public bool IsLarger()
        {
            return Parent != null && this == Parent.Larger;
        }

        public Node<T> Successor()
        {
            if (Larger != null)
            {
                return Larger.Minimum();
            }

            var node = this;

            while (node.IsLarger())
            {
                node = node.Parent;
            }

            return node.Parent;
        }

        public Node<T> Predecessor()
        {
            if (Smaller != null)
            {
                return Smaller.Maximum();
            }

            var node = this;

            while (node.IsSmaller())
            {
                node = node.Parent;
            }

            return node.Parent;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            var other = (Node<T>)obj;

            return Value.Equals(other.Value)
                && EqualsSmaller(other.Smaller)
                && EqualsLarger(other.Larger);
        }

        private bool EqualsLarger(Node<T> other)
        {
            return Larger == null && other == null
                || Larger != null && Larger.Equals(other);
        }

        private bool EqualsSmaller(Node<T> other)
        {
            return Smaller == null && other == null
                || Smaller != null && Smaller.Equals(other);
        }
    }
}
