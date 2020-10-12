using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _53_MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            // verification
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            // logic
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            int maxValue = dp[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                maxValue = Math.Max(maxValue, dp[i]);
            }

            return maxValue;
        }
    }
}
