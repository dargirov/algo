﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bubble;
using Selection;

namespace SortingMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var listInts = new List<int>();
            listInts.Add(5);
            listInts.Add(2);
            listInts.Add(1);
            listInts.Add(3);
            listInts.Add(8);
            listInts.Add(6);
            listInts.Add(7);
            listInts.Add(0);
            listInts.Add(4);
            listInts.Add(6);

            var listStrings = new List<string>();
            listStrings.Add("Sofia");
            listStrings.Add("Plovdiv");
            listStrings.Add("Asenovgrad");
            listStrings.Add("Varna");
            listStrings.Add("Ruse");
            listStrings.Add("Pleven");
            listStrings.Add("Burgas");

            var selectionSorter = new SelectionSortList<int>();
            Console.WriteLine(string.Join(", ", selectionSorter.Sort(listInts)));

            var bubbleSorter = new BubbleSortList<string>();
            Console.WriteLine(string.Join(", ", bubbleSorter.Sort(listStrings)));
        }
    }
}