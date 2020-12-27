using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2.Kontroller
{
    public class Knapsack_problem
    {
        public static List<int> knapsack(int[] Gewicht, int[] Kosten, int notwendig)
        {
            List<int> rucksack = new List<int>();
            int a = Gewicht.Length;
            int[,] ss = new int[notwendig + 1, a + 1];
            for (int j = 1; j <= a; j++)
            {
                for (int w = 1; w <= notwendig; w++)
                {
                    if (Gewicht[j - 1] <= w)
                    {
                        ss[w, j] = Math.Max(ss[w, j - 1], ss[w - Gewicht[j - 1], j - 1] + Kosten[j - 1]);
                    }
                    else
                    {
                        ss[w, j] = ss[w, j - 1];
                    }
                }
            }
            int ruc = ss[notwendig, a], n = notwendig;
            for (int i = a; i >= 0; i--)
            {
                if (ruc <= 0)
                    break;
                if (ruc == ss[n, i - 1])
                    continue;
                else 
                {
                    rucksack.Add(i - 1);
                    ruc -= Kosten[i - 1];
                    n -= Gewicht[i - 1];
                }
            }
            rucksack.Add(ss[notwendig, a]);
            return rucksack;
        }
    }
}
