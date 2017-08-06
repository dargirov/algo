using BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTests
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        private Node<string> _a;
        private Node<string> _d;
        private Node<string> _f;
        private Node<string> _h;
        private Node<string> _i;
        private Node<string> _k;
        private Node<string> _l;
        private Node<string> _m;
        private Node<string> _p;
        private Node<string> _root;
        private BinarySearchTree<string> _tree;

        [TestInitialize]
        public void Setup()
        {
            _a = new Node<string>("A");
            _h = new Node<string>("H");
            _k = new Node<string>("K");
            _p = new Node<string>("P");
            _f = new Node<string>("F", null, _h);
            _m = new Node<string>("M", null, _p);
            _d = new Node<string>("D", _a, _f);
            _l = new Node<string>("L", _k, _m);
            _i = new Node<string>("I", _d, _l);
            _root = _i;

            _tree = new BinarySearchTree<string>();
            _tree.Insert(_i.Value);
            _tree.Insert(_d.Value);
            _tree.Insert(_l.Value);
            _tree.Insert(_a.Value);
            _tree.Insert(_f.Value);
            _tree.Insert(_k.Value);
            _tree.Insert(_m.Value);
            _tree.Insert(_h.Value);
            _tree.Insert(_p.Value);
        }

        [TestMethod]
        public void Insert()
        {
            Assert.AreEqual(_root, _tree.Root);
        }

        [TestMethod]
        public void Search()
        {
            Assert.AreEqual(_a, _tree.Search(_a.Value));
            Assert.AreEqual(_d, _tree.Search(_d.Value));
            Assert.AreEqual(_f, _tree.Search(_f.Value));
            Assert.AreEqual(_h, _tree.Search(_h.Value));
            Assert.AreEqual(_i, _tree.Search(_i.Value));
            Assert.AreEqual(_k, _tree.Search(_k.Value));
            Assert.AreEqual(_l, _tree.Search(_l.Value));
            Assert.AreEqual(_m, _tree.Search(_m.Value));
            Assert.AreEqual(_p, _tree.Search(_p.Value));
            Assert.IsNull(_tree.Search("Something"));
        }

        [TestMethod]
        public void DeleteLeafNode()
        {
            var deleted = _tree.Delete(_h.Value);

            Assert.IsNotNull(deleted);
            Assert.AreEqual(_h.Value, deleted.Value);

            _f.Larger = null;
            Assert.AreEqual(_root, _tree.Root);
        }

        [TestMethod]
        public void DeleteNodeWithOneChild()
        {
            var deleted = _tree.Delete(_m.Value);

            Assert.IsNotNull(deleted);
            Assert.AreEqual(_m.Value, deleted.Value);

            _l.Larger = _p;
            Assert.AreEqual(_root, _tree.Root);
        }

        [TestMethod]
        public void DeleteNodeWithTwoChildren()
        {
            var deleted = _tree.Delete(_i.Value);

            Assert.IsNotNull(deleted);
            Assert.AreEqual(_i.Value, deleted.Value);
        }

        [TestMethod]
        public void DeleteRootNodeUntilTreeIsEmpty()
        {
            while (_tree.Root != null)
            {
                var key = _tree.Root.Value;
                var deleted = _tree.Delete(key);

                Assert.IsNotNull(deleted);
                Assert.AreEqual(key, deleted.Value);
            }
        }
    }
}
