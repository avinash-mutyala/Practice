using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Prime
    {
        /* Get prime numbers less than entered number*/
        public static void PrimeNumbers()
        {
            int number = Convert.ToInt32(Console.ReadLine());

            var list = new List<int>();

            if (number > 1)
            {
                for (int i = 2; i < number; i++)
                {
                    for (int y = i; y >= 1; y--)
                    {
                        if (y == 1)
                        {
                            list.Add(i);
                            break;
                        }
                        if (y == i) continue;
                        if (i % y == 0) break;
                    }
                }
            }

            foreach (var a in list)
            {
                Console.Write(a + " ");

            }

        }

    }
}
