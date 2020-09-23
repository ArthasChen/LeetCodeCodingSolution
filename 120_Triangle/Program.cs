using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            IList<IList<int>> tri = new List<IList<int>>();
            tri.Add(new List<int>() { 2 });
            tri.Add(new List<int>() { 3, 4 });
            tri.Add(new List<int>() { 6, 5, 7 });
            tri.Add(new List<int>() { 4, 1, 8, 3 });
            int sss = s.MinimumTotal(tri);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            // verification
            if (triangle == null || triangle.Count == 0)
            {
                return 0;
            }

            // logic
            int triangleHeight = triangle.Count;
            IList<IList<int>> dp = new List<IList<int>>();
            dp.Add(new List<int>() { triangle[0][0] });

            for (int i = 1; i < triangleHeight; i++)
            {

                dp.Add(new List<int>());

                for (int j = 0; j < i + 1; j++)
                {
                    if (j  > 0 && j < i)
                    {
                        //dp[i][j] = Math.Min(dp[i - 1][j], dp[i - 1][j - 1]);
                        dp[i].Add(Math.Min(dp[i - 1][j] + triangle[i][j], dp[i - 1][j - 1] + triangle[i][j]));
                    }
                    else if (j == 0)
                    {
                        //dp[i][j] = dp[i - 1][j];
                        dp[i].Add(dp[i - 1][j] + triangle[i][j]);
                    }
                    else
                    {
                        dp[i].Add(dp[i - 1][j - 1] + triangle[i][j]);
                    }
                }
            }

            int minPath = int.MaxValue;

            for (int i = 0; i < triangleHeight; i++)
            {
                minPath = Math.Min(minPath, dp[triangleHeight - 1][i]);
            }

            return minPath;
        }
    }
}
