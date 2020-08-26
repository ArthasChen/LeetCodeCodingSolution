using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _78_Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public IList<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> Subsets(int[] nums)
        {
            // verification
            if (nums == null || nums.Length == 0)
            {
                return new List<IList<int>>();
            }

            // logic
            // add empty set
            result.Add(new List<int>());


            // add 除了空集和满集 的所有可能排列
            for (int i = 1; i < nums.Length; i++)
            {
                IList<int> currentRes = new List<int>();

                // process logic i表示这轮循环从数组里取出数字的个数
                BackTrack(currentRes, 0, i, 0, nums);

                //result.Add(currentRes);
            }

            // add full set
            result.Add(nums.ToList());

            return result;
        }

        private void BackTrack(IList<int> currentRes, int currentCount, int counts, int index, int[] numsArray)
        {
            // terminator 
            if (currentCount == counts)
            {
                result.Add(currentRes.ToList());
                return;
            }

            // process current level logic
            for (int i = index; i < numsArray.Length; i++)
            {
                currentRes.Add(numsArray[i]);

                // drill down
                currentCount++;
                i++;

                BackTrack(currentRes, currentCount, counts, i, numsArray);

                // reverse the current level status if needed
                currentCount--;
                i--;
                currentRes.RemoveAt(currentRes.Count - 1);
            }
        }
    }
}
