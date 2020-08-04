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
    /// 解法一
    /// 循环两次，第一次把非0元素从头按顺序排
    /// 第二次从0开始补齐
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

    /// <summary>
    /// 解法二
    /// 只循环一次，每当遇到非0元素，就对换两个指针的数值，因此非0元素在快指针到最后一个值时，也补齐了。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution2
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
                    Swap(nums, needWriteIndex++, currentIndex);
                }
            }
        }

        private void Swap(int[] nums, int needWriteIndex, int currentIndex)
        {
            int tem = nums[needWriteIndex];
            nums[needWriteIndex] = nums[currentIndex];
            nums[currentIndex] = tem;
        }
    }
}
