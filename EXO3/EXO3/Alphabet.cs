using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXO3
{

    static class Alphabet
    {
        public static List<char> Elements { get; } = new List<char>();

        public static List<char> Freq { get; } = new List<char>();

        static Alphabet()
        {
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                Elements.Add(letter);
            }
            Elements.Add(' ');
            Freq.Add(' ');
            Freq.Add('e');
            Freq.Add('t');
            Freq.Add('a');
            Freq.Add('o');
            Freq.Add('n');
            Freq.Add('i');
            Freq.Add('h');
            Freq.Add('s');
            Freq.Add('r');
            Freq.Add('l');
            Freq.Add('d');
            Freq.Add('u');
            Freq.Add('c');
            Freq.Add('m');
            Freq.Add('w');
            Freq.Add('y');
            Freq.Add('f');
            Freq.Add('g');
            Freq.Add('p');
            Freq.Add('b');
            Freq.Add('v');
            Freq.Add('k');
            Freq.Add('j');
            Freq.Add('x');
            Freq.Add('q');
            Freq.Add('z');
        }



    }
}
