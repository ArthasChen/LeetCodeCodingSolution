using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 时间复杂度：O(n^2)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length <= 0)
            {
                return 0;
            }


            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }


            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
}
