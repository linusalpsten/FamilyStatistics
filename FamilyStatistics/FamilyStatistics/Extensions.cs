using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStatistics
{
    public static class Extensions
    {
        public static void AddTo<T>(this T addition, ref T[] array) where T : IComparable
        {
            if (isDefault<T>(addition))
            {
                throw new ArgumentException($"Addition can not be equal to the default value of {typeof(T)}");
            }

            int firstUsableIndex = -1;
            if (addition == null)
            {

            }
            for (int i = 0; i < array.Length; i++)
            {
                if (isDefault<T>(array[i]))
                {
                    firstUsableIndex = i;
                    break;
                }
            }
            if (firstUsableIndex == -1)
            {
                firstUsableIndex = array.Length;
                T[] extendedArray = new T[array.Length * 2];
                for (int i = 0; i < array.Length; i++)
                {
                    extendedArray[i] = array[i];
                }
                array = extendedArray;
            }
            array[firstUsableIndex] = addition;
        }
        public static bool isDefault<T>(T item) where T : IComparable
        {
            if (item == null)
            {
                return true;
            }
            if (item.CompareTo(default(T)) == 0)
            {
                return true;
            }
            return false;
        }

        public static string Capitalize(this string self)
        {
            if (self == null)
            {
                return self;
            }
            if (self.Length == 0)
            {
                return "";
            }
            return self[0].ToString().ToUpper() + self.Substring(1);
        }
    }
}
