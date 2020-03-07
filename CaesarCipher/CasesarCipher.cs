// Eric Michael Hicks
// Caesar Cipher

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CaesarCipher
{
    class StringExtensions
    {

        // Checks to see if the single value string is in a-z or A-Z
        public static Boolean isChar(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z]*$");
            return rg.IsMatch(strToCheck);
        }

        // Converts a char to its corresponding ASCII integer value, keeping within the range of 97-122 (a-z)
        private static int let2nat(char c)
        {
            int n = (int) Char.ToLower(c);
            if (n < 97)
                n = n + 26;
            if (n > 122)
                n = n - 26;
            return n - 97;
        }

        // Converts an int to its corresponding ASCII character, keeping within the range of a-z (97-122)
        private static char nat2let(int n)
        {
            if (n + 97 < 97)
                n = n + 26;
            if (n + 97 > 122)
                n = n - 26;
            char c = (char)(n+97);
            return c;
        }

        private static char shift(int n, char c)
        {
            if (isChar(c.ToString()))
            {
                int hi = n % 26;
                int let = let2nat(c);
                char nat = nat2let((let + hi));
                return nat;
            }
            else
                return c;
        }

        private static string encode(int n, string sesh)
        {
            int len = sesh.Length;
            int i;
            char[] newstr = new char[len];

            for(i = 0; i < len; i++)
            {
                newstr[i] = shift(n, sesh[i]);
            }

            return newstr.ToString();
        }

        private static string decode(int n, string sesh)
        {
            int len = sesh.Length;
            int i;
            char[] newstr = new char[len];

            for (i = 0; i < len; i++)
            {
                newstr[i] = shift(-n, sesh[i]);
            }



            return new string(newstr);
        }

        // Count how many lower case letters are in a string.
        private static int lowers(string bones)
        {
            int n = 0;
            for(int i = 0; i < bones.Length; i++)
                n = n + helper(bones[i]);
            return n;
        }

        // Helper function to lower().
        private static int helper(char c)
        {
            int n = (int)c;
            if (n > 96 && n < 122)
                return 1;
            else
                return 0;
        }

        // Counts the number of times a character occurs in the string.
        private static int count(char c, string wow)
        {
            int n = 0;
            for(int i = 0; i < wow.Length; i++)
            {
                if (wow[i] == c)
                    n++;
            }
            return n;
        }

        // Self explanatory.
        private static double percent(int n, int m)
        {
            return (double) n / m * 100;
        }

        // Returns a table representing the frequency of each character in a string.
        private static double[] freqs(string lean)
        {
            double[] table = new double[26];
            int chars = lowers(lean);
            double per;

            for(int i = 0; i < table.Length; i++)
            {
                per = percent(count((char)(i + 97), lean), chars);
                table[i] = per;
            }
            return table;
        }

        // Rotates a list n places to the left, wrapping around at the start of the list, and assuming n is in the range zero to the length of the list.
        private static double[] rotate(int n, double[] illmatic)
        {
            int len = illmatic.Length;
            double[] nas = new double[len];

            for (int i = 0; i < len; i++)
            {
                nas[i] = illmatic[(i + n) % len];
            }

            return nas;
        }

        // Calculates the chi square statistic for a list of observed frequencies os with respect to a list of expected frequencies es.
        private static double chisqr(double[] os, double[] es)
        {
            double summy = 0;
            for(int i = 0; i < os.Length; i++)
            {
                summy += (square(os[i] - es[i])) / es[i];
            }

            return summy;
        }

        private static double square(double n)
        {
            return (double)n * n;
        }

        // Returns the ﬁrst position (counting from zero) at which a value occurs in a list, assuming that it occurs at least once.
        private static int position(double n, double[] dub)
        {
            int m = 0;

            for(int i = 0; i < dub.Length; i++)
            {
                if(dub[i] == n)
                {
                    m = i;
                    i = dub.Length;
                }
            }

            return m;
        }

        private static string Cracked(string kool)
        {
            double[] table = { 8.2, 1.5, 2.8, 4.3, 12.7, 2.2, 2.0, 6.1, 7.0, 0.2, 0.8, 4.0, 2.4, 6.7, 7.5, 1.9, 0.1, 6.0, 6.3, 9.1, 2.8, 1.0, 2.4, 0.2, 2.0, 0.1 };
            double[] com = freqs(kool);
            double[] heems = new double[26];
            int doom;


            for(int i = 0; i < 26; i++)
                heems[i] = chisqr(rotate(i, com), table);
               
            doom = position(heems.Min(), heems);

            return decode(doom, kool);
        }

        static void Main(string[] args)
        {
            double[] table = { 8.2, 1.5, 2.8, 4.3, 12.7, 2.2, 2.0, 6.1, 7.0, 0.2, 0.8, 4.0, 2.4, 6.7, 7.5, 1.9, 0.1, 6.0, 6.3, 9.1, 2.8, 1.0, 2.4, 0.2, 2.0, 0.1 };
        }
    }
}

