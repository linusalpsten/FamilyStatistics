using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStatistics
{
    public static class Extensions
    {
        public static void Add(this string[] array, string addition)
        {
            int firstUsableIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    firstUsableIndex = i;
                    break;
                }
            }
            if (firstUsableIndex == -1)
            {
                throw new IndexOutOfRangeException("Your family is not this big");
            }
            array[firstUsableIndex] = addition;
        }

        public static void Add(this int[] array, int addition)
        {
            if (addition <= 0)
            {
                throw new ArgumentException("Age can not be 0 or less");
            }
            int firstUsableIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    firstUsableIndex = i;
                    break;
                }
            }
            if (firstUsableIndex == -1)
            {
                throw new IndexOutOfRangeException("Your family is not this big");
            }
            array[firstUsableIndex] = addition;
        }

        public static void Add(this double[] array, double addition)
        {
            if (addition <= 0)
            {
                throw new ArgumentException("Height can not be 0 or less");
            }
            int firstUsableIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    firstUsableIndex = i;
                    break;
                }
            }
            if (firstUsableIndex == -1)
            {
                throw new IndexOutOfRangeException("Your family is not this big");
            }
            array[firstUsableIndex] = addition;
        }

        public static void Add(this RelationType[] array, RelationType addition)
        {
            if (addition <= RelationType.Default)
            {
                throw new ArgumentException("You need to have a relation with this family member");
            }
            int firstUsableIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    firstUsableIndex = i;
                    break;
                }
            }
            if (firstUsableIndex == -1)
            {
                throw new IndexOutOfRangeException("Your family is not this big");
            }
            array[firstUsableIndex] = addition;
        }
    }
}
