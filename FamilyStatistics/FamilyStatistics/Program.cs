using System;
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

        public static string GetName()
        {
            Console.WriteLine("Write a name of a family member");
            string name = string.Empty;
            do
            {
                name = Console.ReadLine().Capitalize();
                if (name == string.Empty)
                {
                    Console.WriteLine("Your family member has to have a name, try again.");
                }
            } while (name == string.Empty);
            return name;
        }
        public static int GetAge(string name)
        {
            Console.WriteLine($"How old is {name} (in years)?");
            int age = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out age);
                if (age <= 0)
                {
                    Console.WriteLine($"{name} must be atleast 1 year old.");
                }
            } while (age <= 0);
            return age;
        }
        }
    }
}
