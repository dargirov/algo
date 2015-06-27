using System;
using List;

namespace ArrayMain
{
    class Program
    {
        static void Main()
        {
            //int[] defaults = {1, 2, 3, 4, 5};
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Insert(0, 11);
            linkedList.Insert(5, 11);

            /*IIterator<int> iterator = arrayList.Iterator();
            iterator.First();
            Console.WriteLine(iterator.Current());
            iterator.Next();
            Console.WriteLine(iterator.Current());*/
            Console.WriteLine(linkedList.ToString());


            /*foreach (var i in arrayList)
            {
                Console.WriteLine(i);
            }*/

        }
    }
}
