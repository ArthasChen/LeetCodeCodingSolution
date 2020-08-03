using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// 解法一：暴力解法
    /// 时间复杂度：O(n^2)
    /// 空间复杂度：O(1) 


    /// <summary>
    /// 解法二：循环两轮
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n) 是用哈希表
    /// </summary>
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
            {
                return new int[0];
            }

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dic[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int num = target - nums[i];
                if (dic.ContainsKey(num) && dic[num] != i)
                {
                    return new int[] { i, dic[num] };
                }
            }

            throw new Exception("No exist");
        }
    }
}
