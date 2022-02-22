using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    static class RandomExtensions
    {

        public static void Shuffle<T>(this Random rng, T[] cards)
        {



            int n = cards.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }


        }
    }
}