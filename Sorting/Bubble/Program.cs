using System;
using System.Collections;
using System.Collections.Generic;

namespace Bubble
{
    class Program
    {
        static void Main()
        {
            IList<string> testStrings = new List<string>();
            testStrings.Add("Pesho");
            testStrings.Add("Gosho");
            testStrings.Add("Ivan");

            IList<int> testInts = new List<int>();
            testInts.Add(4);
            testInts.Add(7);
            testInts.Add(6);
            testInts.Add(1);
            testInts.Add(3);
            testInts.Add(2);
            testInts.Add(9);
            testInts.Add(7);
            testInts.Add(8);
            testInts.Add(2);
            testInts.Add(5);
            testInts.Add(0);

            var sortedStrings = new Bubble<string>();
            var sortedInts = new Bubble<int>();


            Console.WriteLine(string.Join(", ", sortedStrings.Sort(testStrings)));
            Console.WriteLine(string.Join(", ", sortedInts.Sort(testInts)));
        }
    }

    public class Bubble<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> list)
        {
            int size = list.Count;

            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < size - i; j++)
                {
                    var left = list[j];
                    var right = list[j + 1];
                    if (left.CompareTo(right) > 0)
                    {
                        this.Swap(list, j, j + 1);
                    }
                }
            }

            return list;
        }

        private void Swap(IList<T> list, int left, int right)
        {
            var temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}