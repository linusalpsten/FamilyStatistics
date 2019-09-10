using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStatistics
{
    class Program
    {
        static string[] names = new string[1];
        static int[] ages = new int[1];
        static double[] heights = new double[1];
        static RelationType[] relations = new RelationType[8];

        static void Main(string[] args)
        {
            AddFamily();
            ShowFamily();
        }

        public static void ShowFamily()
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Name: {names[i]}, Age: {ages[i]}, Height: {heights[i]}, Relation: {relations[i]}");
            }
        }

        public static void AddFamily()
        {
            bool addingFamily = true;
            while (addingFamily)
            {
                string name = GetName();
                name.AddTo(ref names);
                GetAge(name).AddTo(ref ages);
                GetHeight(name).AddTo(ref heights);
                GetRelation(name).AddTo(ref relations);
                string input = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to add another family member? Yes/No");
                    input = Console.ReadLine();
                } while (input.ToLower() != "yes" && input.ToLower() != "no");
                if (input.ToLower() == "no")
                {
                    addingFamily = false;
                }
            }
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

        public static double GetHeight(string name)
        {
            Console.WriteLine($"How tall is {name} (in meters)?");
            double height = 0;
            do
            {
                string heightInput = Console.ReadLine().Replace('.', ',');
                double.TryParse(heightInput, out height);
                if (height <= 0)
                {
                    Console.WriteLine($"{name} can not be 0 meters or less tall.");
                }
            } while (height <= 0);
            return height;
        }

        public static RelationType GetRelation(string name)
        {
            Console.WriteLine($"What is your relation with {name}?");
            RelationType[] relationTypes = (RelationType[])Enum.GetValues(typeof(RelationType));
            relationTypes = relationTypes.Skip(1).ToArray();
            foreach (RelationType type in relationTypes)
            {
                if (!(type == RelationType.Default))
                {
                    Console.Write($"{type}, ");
                }
            }
            Console.WriteLine();
            RelationType relation = RelationType.Default;
            string input = string.Empty;
            do
            {
                input = Console.ReadLine().Capitalize();
                foreach (RelationType item in relationTypes)
                {
                    if (item.ToString() == input)
                    {
                        relation = item;
                    }
                }
                if (relation == RelationType.Default)
                {
                    Console.WriteLine("Write one of our options");
                }
            } while (relation == RelationType.Default);
            return relation;
        }
    }
}
