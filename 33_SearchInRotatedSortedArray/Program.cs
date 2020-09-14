using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_SearchInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution so = new Solution();
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            int tar = 2;
            var a = so.Search(array, tar);
        }
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            int start = 0;
            int end = nums.Length - 1;
            int mid;
            while (start <= end)
            {
                mid = start + (end - start) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                // 前半部分有序,注意此处用小于等于
                if (nums[start] <= nums[mid])
                {
                    // target在前半部分
                    if (target >= nums[start] && target < nums[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target <= nums[end] && target > nums[mid])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }

            }

            return -1;
        }
    }
}
