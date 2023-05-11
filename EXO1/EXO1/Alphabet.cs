using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXO1
{

    static class Alphabet
    {
        public static List<char> Elements { get; } = new List<char>();

        static Alphabet()
        {
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                Elements.Add(letter);
            }
            Elements.Add(' ');
        }

    }
}
