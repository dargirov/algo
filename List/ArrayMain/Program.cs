using System;
using List;

namespace ArrayMain
{
    class Program
    {
        static void Main()
        {
            var arrayList = new ArrayList<int>();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);

            IIterator<int> iterator = arrayList.Iterator();
            iterator.First();
            Console.WriteLine(iterator.Current());


            /*foreach (var i in arrayList)
            {
                Console.WriteLine(i);
            }*/

        }
    }
}
