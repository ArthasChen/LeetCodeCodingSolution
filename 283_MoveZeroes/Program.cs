using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _283_MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new[]
            {
                0, 1, 0, 3, 12
            };
            Solution s = new Solution();
            s.MoveZeroes(input);
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int currentIndex = 0;
            int needWriteIndex = 0;

            for (currentIndex = 0; currentIndex < nums.Length; currentIndex++)
            {
                if (nums[currentIndex] != 0)
                {
                    nums[needWriteIndex] = nums[currentIndex];
                    needWriteIndex++;
                }
            }

            for (; needWriteIndex < nums.Length; needWriteIndex++)
            {
                nums[needWriteIndex] = 0;
            }
        }
    }
}
