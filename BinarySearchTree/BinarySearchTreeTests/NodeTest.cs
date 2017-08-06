using BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTests
{
    [TestClass]
    public class NodeTest
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
        }

        [TestMethod]
        public void Minimum()
        {
            Assert.AreSame(_a, _a.Minimum());
            Assert.AreSame(_a, _d.Minimum());
            Assert.AreSame(_f, _f.Minimum());
            Assert.AreSame(_h, _h.Minimum());
            Assert.AreSame(_a, _i.Minimum());
            Assert.AreSame(_k, _k.Minimum());
            Assert.AreSame(_k, _l.Minimum());
            Assert.AreSame(_m, _m.Minimum());
            Assert.AreSame(_p, _p.Minimum());
        }

        [TestMethod]
        public void Maximum()
        {
            Assert.AreSame(_a, _a.Maximum());
            Assert.AreSame(_h, _d.Maximum());
            Assert.AreSame(_h, _f.Maximum());
            Assert.AreSame(_h, _h.Maximum());
            Assert.AreSame(_p, _i.Maximum());
            Assert.AreSame(_k, _k.Maximum());
            Assert.AreSame(_p, _l.Maximum());
            Assert.AreSame(_p, _m.Maximum());
            Assert.AreSame(_p, _p.Maximum());
        }

        [TestMethod]
        public void Successor()
        {
            Assert.AreSame(_d, _a.Successor());
            Assert.AreSame(_f, _d.Successor());
            Assert.AreSame(_h, _f.Successor());
            Assert.AreSame(_i, _h.Successor());
            Assert.AreSame(_k, _i.Successor());
            Assert.AreSame(_l, _k.Successor());
            Assert.AreSame(_m, _l.Successor());
            Assert.AreSame(_p, _m.Successor());
            Assert.IsNull(_p.Successor());
        }

        [TestMethod]
        public void Predecessor()
        {
            Assert.IsNull(_a.Predecessor());
            Assert.AreSame(_a, _d.Predecessor());
            Assert.AreSame(_d, _f.Predecessor());
            Assert.AreSame(_f, _h.Predecessor());
            Assert.AreSame(_h, _i.Predecessor());
            Assert.AreSame(_i, _k.Predecessor());
            Assert.AreSame(_k, _l.Predecessor());
            Assert.AreSame(_l, _m.Predecessor());
            Assert.AreSame(_m, _p.Predecessor());
        }

        [TestMethod]
        public void IsSmaller()
        {
            Assert.IsTrue(_a.IsSmaller());
            Assert.IsTrue(_d.IsSmaller());
            Assert.IsFalse(_f.IsSmaller());
            Assert.IsFalse(_h.IsSmaller());
            Assert.IsFalse(_i.IsSmaller());
            Assert.IsTrue(_k.IsSmaller());
            Assert.IsFalse(_l.IsSmaller());
            Assert.IsFalse(_m.IsSmaller());
            Assert.IsFalse(_p.IsSmaller());
        }

        [TestMethod]
        public void IsLarger()
        {
            Assert.IsFalse(_a.IsLarger());
            Assert.IsFalse(_d.IsLarger());
            Assert.IsTrue(_f.IsLarger());
            Assert.IsTrue(_h.IsLarger());
            Assert.IsFalse(_i.IsLarger());
            Assert.IsFalse(_k.IsLarger());
            Assert.IsTrue(_l.IsLarger());
            Assert.IsTrue(_m.IsLarger());
            Assert.IsTrue(_p.IsLarger());
        }
    }
}
