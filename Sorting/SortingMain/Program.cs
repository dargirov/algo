using System;
using System.Collections.Generic;

using Bubble;
using Selection;
using Insertion;
using Shell;
using Quick;
using Merge;

namespace SortingMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var listInts = new List<int>();
            listInts.Add(3);
            listInts.Add(1);
            listInts.Add(4);
            listInts.Add(8);
            listInts.Add(5);
            listInts.Add(2);
            listInts.Add(7);
            listInts.Add(9);
            listInts.Add(3);

            var listStrings = new List<string>();
            listStrings.Add("Sofia");
            listStrings.Add("Plovdiv");
            listStrings.Add("Asenovgrad");
            listStrings.Add("Varna");
            listStrings.Add("Ruse");
            listStrings.Add("Pleven");
            listStrings.Add("Burgas");

            var mergeSort = new MergeSortList<int>();
            Console.WriteLine(string.Join(", ", mergeSort.Sort(listInts)));
        }
    }
}
