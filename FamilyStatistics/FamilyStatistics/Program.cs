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
        static RelationType[] relations = new RelationType[1];

        static void Main(string[] args)
        {
            AddFamily();
            ShowFamily();
            ShowMostCommonCharacters();
            ShowAgeStatistics();
            ShowHeightStatistics();
            ShowMostCommonRelations();
        }

        public static void ShowMostCommonCharacters()
        {
            var mostCommonCharacters = MostCommonCharacters(names);
            string occurence = mostCommonCharacters[0].Value > 1 ? " occurences." : " occurence.";
            if (mostCommonCharacters.Count() == 1)
            {
                Console.WriteLine("The most common character in names is " +
                    $"'{mostCommonCharacters[0].Key}' with {mostCommonCharacters[0].Value} {occurence}");
            }
            else
            {
                Console.Write("The most common characters in names is ");
                for (int i = 0; i < mostCommonCharacters.Count; i++)
                {
                    if (i == mostCommonCharacters.Count-1)
                    {
                        Console.Write($" and '{mostCommonCharacters[i].Key}' ");
                    }
                    else if (i == 0)
                    {
                        Console.Write($"'{mostCommonCharacters[i].Key}'");
                    }
                    else
                    {
                        Console.Write($", '{mostCommonCharacters[i].Key}'");
                    }
                }
                Console.WriteLine($"with {mostCommonCharacters[0].Value} {occurence}");
            }
        }

        public static void ShowMostCommonRelations()
        {
            Console.WriteLine();
            var mostCommonRelations = MostCommonRelations(relations);
            string occurence = mostCommonRelations[0].Value > 1 ? " occurences." : " occurence.";
            if (mostCommonRelations.Count() == 1)
            {
                Console.WriteLine("The most common relation is " +
                    $"'{mostCommonRelations[0].Key}' with {mostCommonRelations[0].Value} {occurence}");
            }
            else
            {
                Console.Write("The most common relation is ");
                for (int i = 0; i < mostCommonRelations.Count; i++)
                {
                    if (i == mostCommonRelations.Count - 1)
                    {
                        Console.Write($" and '{mostCommonRelations[i].Key}' ");
                    }
                    else if (i == 0)
                    {
                        Console.Write($"'{mostCommonRelations[i].Key}'");
                    }
                    else
                    {
                        Console.Write($", '{mostCommonRelations[i].Key}'");
                    }
                }
                Console.WriteLine($"with {mostCommonRelations[0].Value} {occurence}");
            }
        }

        public static void ShowFamily()
        {
            Console.WriteLine("Here are your family members one by one");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].isDefault())
                {
                    break;
                }
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
                Console.Clear();
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
                    Console.WriteLine($"{name} must be atleast 1 year old, try again.");
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
                    Console.WriteLine($"{name} can not be 0 meters or less tall, try again.");
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
                    Console.WriteLine("Write one of our options, try again.");
                }
            } while (relation == RelationType.Default);
            return relation;
        }

        public static void ShowAgeStatistics()
        {
            double averageAge = 0;
            foreach (var item in ages)
            {
                averageAge += item;
            }
            averageAge /= ages.Length;
            Console.WriteLine($"\nYour familys average age is; {averageAge}");

            double averageAgeInSwe = 40.8;
            double ageBetween = averageAge - averageAgeInSwe;

            if (ageBetween < 0)
                Console.WriteLine($"Your familys average age is { Math.Abs(ageBetween)} years younger then the average of " +
                    "the Swedish populaion");
            else if (ageBetween > 0)
                Console.WriteLine($"Your familys average age is {ageBetween} years older then the average of the Swedish populaion");
            //This else is not needed. Because ageBetween can never be == 0
            else
                Console.WriteLine("Your family actually has the same average age as the Swedish population");
        }

        public static void ShowHeightStatistics()
        {
            double totalHeight = 0;
            foreach (var item in heights)
            {
                totalHeight += item;
            }

            Console.WriteLine($"\nYour familys total height is: {totalHeight} meters");
            int erthEquator = 40075000;
            double timesAround = erthEquator / totalHeight;

            Console.WriteLine($"If we want to cover the Erth's equator with your family members." +
                $" We need to lay them down { Math.Round(timesAround, 1)} times");
        }

        public static List<KeyValuePair<char, int>> MostCommonCharacters(string[] array)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (var strng in array)
            {
                foreach (var chr in strng.ToLower())
                {
                    if (!charCount.ContainsKey(chr))
                    {
                        charCount.Add(chr, 1);
                    }
                    else
                    {
                        charCount[chr] += 1;
                    }
                }
            }
            List<KeyValuePair<char, int>> max = new List<KeyValuePair<char, int>>();
            max.Add(new KeyValuePair<char, int>('-', -1));
            foreach (var character in charCount)
            {
                if (character.Value > max[0].Value)
                {
                    max.Clear();
                    max.Add(character);
                }
                else if (character.Value == max[0].Value)
                {
                    max.Add(character);
                }
            }
            return max;
        }

        public static List<KeyValuePair<RelationType, int>> MostCommonRelations(RelationType[] array)
        {
            Dictionary<RelationType, int> relationCount = new Dictionary<RelationType, int>();
            foreach (var relation in array)
            {
                if (!relationCount.ContainsKey(relation))
                {
                    relationCount.Add(relation, 1);
                }
                else
                {
                    relationCount[relation] += 1;
                }
            }
            List<KeyValuePair<RelationType, int>> max = new List<KeyValuePair<RelationType, int>>();
            max.Add(new KeyValuePair<RelationType, int>(RelationType.Default, -1));
            foreach (var relation in relationCount)
            {
                if (relation.Value > max[0].Value)
                {
                    max.Clear();
                    max.Add(relation);
                }
                else if (relation.Value == max[0].Value)
                {
                    max.Add(relation);
                }
            }
            return max;
        }
    }
}
