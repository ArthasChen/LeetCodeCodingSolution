using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ThreeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
        }
    }

    /// <summary>
    /// 时间复杂度：O(n^2) 排序O(nlogn) 两层循环O(n^2)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (nums == null || nums.Length < 3)
            {
                return res;
            }

            Array.Sort(nums);

            int first = 0;
            int second = first + 1;
            int third = nums.Length - 1;

            for (first = 0; first < nums.Length - 2; first++)
            {
                if (first > 0 && nums[first] == nums[first - 1])
                {
                    continue;
                }

                int target = -1 * nums[first];
                third = nums.Length - 1;

                for (second = first + 1; second < third; second++)
                {
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        continue;
                    }

                    while (second < third)
                    {
                        if (second > first + 1 && nums[second] == nums[second - 1])
                        {
                            second++;
                            continue;
                        }

                        if (nums[second] + nums[third] > target)
                        {
                            third--;
                        }
                        else if (nums[second] + nums[third] < target)
                        {
                            second++;
                        }
                        else
                        {
                            res.Add(new List<int>() { nums[first], nums[second], nums[third] });
                            second++;
                        }
                    }
                }
            }

            return res;
        }
    }
}
