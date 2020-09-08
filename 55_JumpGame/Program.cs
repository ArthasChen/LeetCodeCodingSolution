using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _55_JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] input = new int[] { 3, 2, 1, 0, 4 };
            bool a = s.CanJump(input);


        }
    }

    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            // verification
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            // logic
            return Core(nums, 0);
        }

        private bool Core(int[] nums, int index)
        {
            // end
            if (index == nums.Length - 1)
            {
                return true;
            }
            else if (index >= nums.Length)
            {
                return false;
            }

            // current logic
            int step = nums[index];
            bool result = false;
            for (int i = 1; i <= step; i++)
            {
                result = result || Core(nums, index + i);
                if (result == true)
                {
                    return true;
                }
            }

            // drill down


            // reserve state


            return result;
        }
    }

    public class Solution2
    {
        public bool CanJump(int[] nums)
        {
            // verification
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            if (nums.Length == 1)
            {
                return true;
            }

            // logic
            int rightMost = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i <= rightMost)
                {
                    rightMost = Math.Max(rightMost, i + nums[i]);
                    if (rightMost >= nums.Length - 1)
                    {
                        return true;
                    }
                }


            }




            return false;
        }
    }
}
