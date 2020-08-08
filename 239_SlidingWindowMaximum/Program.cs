using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_SlidingWindowMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] maxArray = new int[0];

            // 题目规定 k <= 数组大小,因此这里不再做判断
            if (nums == null || nums.Length <= 0 || k <= 0)
            {
                return maxArray;
            }

            if (k == 1)
            {
                return nums;
            }

            maxArray = new int[nums.Length - k + 1];

            List<int> listIndex = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i <= k - 1)
                {
                    while (listIndex.Count != 0 && nums[i] >= nums[listIndex.Last()])
                    {
                        listIndex.RemoveAt(listIndex.LastIndexOf(listIndex.Last()));
                    }

                    listIndex.Add(i);
                    if (i == k - 1)
                    {
                        maxArray[i - k + 1] = nums[listIndex.First()];
                    }
                }
                else
                {
                    if (i - listIndex.First() < k)
                    {

                        while (listIndex.Count != 0 && nums[i] >= nums[listIndex.Last()])
                        {
                            listIndex.RemoveAt(listIndex.LastIndexOf(listIndex.Last()));
                        }

                        listIndex.Add(i);
                    }
                    else
                    {
                        listIndex.RemoveAt(listIndex.IndexOf(listIndex.First()));

                        while (listIndex.Count != 0 && nums[i] >= nums[listIndex.Last()])
                        {
                            listIndex.RemoveAt(listIndex.LastIndexOf(listIndex.Last()));
                        }

                        listIndex.Add(i);

                    }


                    if (listIndex.Count != 0)
                    {
                        maxArray[i - k + 1] = nums[listIndex.First()];
                    }

                }
            }

            return maxArray;
        }
    }
}
