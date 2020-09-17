using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153_FindMinimumInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int FindMin(int[] nums)
        {
            // verification
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            int midIndex = 0;

            while (leftIndex <= rightIndex)
            {
                midIndex = (rightIndex - leftIndex) / 2 + leftIndex;

                if (nums[midIndex] > nums[leftIndex] && nums[midIndex] > nums[rightIndex])
                {
                    leftIndex = midIndex + 1;
                }
                else if (nums[midIndex] > nums[leftIndex] && nums[midIndex] < nums[rightIndex])
                {
                    return nums[leftIndex];
                }
                else if (nums[midIndex] < nums[leftIndex])
                {
                    rightIndex = midIndex;
                }
                else
                {
                    // m == l
                    if (nums[leftIndex] > nums[rightIndex])
                    {
                        return nums[rightIndex];
                    }
                    else
                    {
                        return nums[leftIndex];
                    }

                }
            }

            return 0;
        }
    }
}
