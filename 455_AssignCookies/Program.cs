using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _455_AssignCookies
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            // verification
            if (g == null || s == null || g.Length == 0 || s.Length == 0)
            {
                return 0;
            }

            // logic
            Array.Sort(g);
            Array.Sort(s);
            int maxNums = 0;
            int childIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = childIndex; j < g.Length; j++)
                {
                    if (s[i] >= g[j])
                    {
                        maxNums++;
                        childIndex = j + 1;
                        break;
                    }
                }
            }

            return maxNums;
        }
    }
}
