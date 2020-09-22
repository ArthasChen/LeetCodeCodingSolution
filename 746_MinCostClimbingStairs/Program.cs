using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _746_MinCostClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 动态规划
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            // verification
            if (cost == null || cost.Length == 0)
            {
                return 0;
            }

            // logic
            // dp[i] 表示从索引0 or 1到i最小的cost
            int[] dp = new int[cost.Length + 1];
            dp[0] = 0;
            dp[1] = 0;

            for (int i = 2; i < cost.Length + 1; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }

            return dp[cost.Length];
        }
    }

    /// <summary>
    /// 动态规划
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution2
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            // verification
            if (cost == null || cost.Length == 0)
            {
                return 0;
            }

            // logic
            // dp[i] 表示从索引0 or 1到i最小的cost
            int f0 = 0;
            int f1 = 0;
            int f2 = 0;

            for (int i = 2; i < cost.Length + 1; i++)
            {
                f0 = Math.Min(f1 + cost[i - 1], f2 + cost[i - 2]);
                f2 = f1;
                f1 = f0;
            }

            return f0;
        }
    }
}
