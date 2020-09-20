using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62_UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            // verification
            if (m <= 0 || n <= 0)
            {
                return 0;
            }

            // logic
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }

            return dp[m-1, n-1];
        }
    }
}
