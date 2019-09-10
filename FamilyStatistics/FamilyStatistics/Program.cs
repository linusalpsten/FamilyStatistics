﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStatistics
{
    class Program
    {
        static string[] names = new string[128];
        static int[] ages = new int[128];
        static double[] heights = new double[128];
        static RelationType[] relations = new RelationType[8];

        const string defaultName = null;
        const int defautAge = 0;
        const double defaultHeight = 0;
        const RelationType defaultRelation = RelationType.Default;
        static void Main(string[] args)
        {
        public static void ShowFamily()
        {
            Console.WriteLine("Names:");
            foreach (var item in names)
            {
                if (item == defaultName)
                {
                    break;
                }
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Ages:");
            foreach (var item in ages)
            {
                if (item == defautAge)
                {
                    break;
                }
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Heigts:");
            foreach (var item in heights)
            {
                if (item == defaultHeight)
                {
                    break;
                }
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Relations:");
            foreach (var item in relations)
            {
                if (item == defaultRelation)
                {
                    break;
                }
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        }
    }
}
