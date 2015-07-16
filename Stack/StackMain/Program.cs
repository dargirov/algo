using System;
using List;
using UndoableList;

namespace StackMain
{
    class Program
    {
        static void Main()
        {
            var list = new UndoableList<int>(new LinkedList<int>());
            list.Add(1);
        }
    }
}
