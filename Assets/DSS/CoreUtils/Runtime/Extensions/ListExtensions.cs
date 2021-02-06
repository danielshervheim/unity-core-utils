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
    }

    // Source(s)
    // ---------
    // Shuffle
    // stackoverflow user "grenade"
    // https://stackoverflow.com/questions/273313/randomize-a-listt
}