using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Ascii
    {

        /*
         Rules for converting:

1.Each character should be replaced by the nearest Dhananjay's Magical alphabet.

2.If the character is equidistant with 2 Magical alphabets. The one with lower ASCII value will be considered as its replacement.

Input format:

First line of input contains an integer T number of test cases. Each test case contains an integer N (denoting the length of the string) and a string S.

Output Format:

For each test case, print Dhananjay's Magical Word in a new line.

Constraints:

1 <= T <= 100

1 <= |S| <= 500

SAMPLE INPUT 
----------------------
1
6
AFREEN

SAMPLE OUTPUT 
------------------
CGSCCO

Explanation
ASCII values of alphabets in AFREEN are 65, 70, 82, 69 ,69 and 78 respectively which are converted to CGSCCO with ASCII values 67, 71, 83, 67, 67, 79 respectively. All such ASCII values are prime numbers.*/

        public static void MagicWord()
        {
            int testCnt = Convert.ToInt32(Console.ReadLine());

            var inputs = new List<string>();
            for (int i = testCnt; i >= 1; i--)
            {
                int length = Convert.ToInt32(Console.ReadLine());
                string txt = Console.ReadLine();

                inputs.Add(txt);
            }

            foreach (var ipt in inputs)
            {
                Console.WriteLine(GetOutput(ipt));
            }
        }

        static string GetOutput(string ipt)
        {
            string opt = "";
            var ipop = new Dictionary<char, char>();

            for (int i = 0; i < ipt.Length; i++)
            {
                var cChar = ipt[i];
                char pChar = default(char);

                if (ipop.ContainsKey(cChar))
                {
                    pChar = ipop[cChar];
                }
                else
                {
                    pChar = GetPChar(cChar);
                    ipop.Add(cChar, pChar);
                }

                opt += pChar;
            }

            return opt;
        }

        static char GetPChar(char c)
        {
            int ascii = (int)c;
            int? uPrime = null, lPrime = null;
            int fPrime = 0;

            int A = (int)'A', Z = (int)'Z', a = (int)'a', z = (int)'z';

            for (int i = ascii; i >= ascii && i <= 255; i++)
            {
                if (IsPrime(i))
                {
                    if ((A <= i && i <= Z) || (a <= i && i <= z))
                    {
                        uPrime = i;
                        break;
                    }
                }
            }

            for (int i = ascii; i <= ascii && i >= 0; i--)
            {
                if (IsPrime(i))
                {
                    if ((A <= i && i <= Z) || (a <= i && i <= z))
                    {
                        lPrime = i;
                        break;
                    }
                }
            }

            if (!lPrime.HasValue && uPrime.HasValue)
            {
                lPrime = uPrime;
            }

            if (!uPrime.HasValue && lPrime.HasValue)
            {
                uPrime = lPrime;
            }

            if (ascii - lPrime <= uPrime - ascii)
            {
                fPrime = lPrime.Value;
            }
            else
            {
                fPrime = uPrime.Value;
            }

            return (char)fPrime;
        }

        static bool IsPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
