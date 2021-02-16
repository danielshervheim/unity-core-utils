using System.Collections.Generic;

namespace DSS.Extensions
{
    // @brief A collection of List extension methods.
    public static class ListExtensions
    {
        private static System.Random shuffleRNG = new System.Random();

        // @brief Permutes the order of the elements in the given list.
        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = shuffleRNG.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // @brief Returns the sublist of non-null elements in the given list.
        public static List<T> NonNull<T>(this List<T> list)
        {
            List<T> nonNull = new List<T>();
            foreach (T elem in list)
            {
                if (elem != null)
                {
                    nonNull.Add(elem);
                }
            }
            return nonNull;
        }
    }

    // Source(s)
    // ---------
    // Shuffle
    // stackoverflow user "grenade"
    // https://stackoverflow.com/questions/273313/randomize-a-listt
}