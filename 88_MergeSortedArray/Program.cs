using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _88_MergeSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            sol.Merge(new int[] { 2, 2, 2, 0, 0, 0 }, 3, new int[] { 1, 1, 1 }, 3);
        }
    }

    /// <summary>
    /// 双指针
    /// 时间复杂度：o(m+n)
    /// 空间复杂度：o(1)
    /// </summary>
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // verification
            if (nums1 == null || nums2 == null || nums1.Length <= 0 || nums2.Length <= 0 || nums1.Length < m + n)
            {
                return;
            }

            // logic
            int index1 = m - 1;
            int index2 = n - 1;
            int indexCurrent = m + n - 1;
            while (index2 >= 0 && index1 >= 0)
            {
                // 两指针从后往前遍历 对比，最大的复制到currentIndex，然后更新3个指针
                if (nums2[index2] > nums1[index1])
                {
                    nums1[indexCurrent--] = nums2[index2--];
                }
                else
                {
                    nums1[indexCurrent--] = nums1[index1--];
                }
            }

            if (index1 < 0)
            {
                while (index2 >= 0)
                {
                    nums1[indexCurrent--] = nums2[index2--];
                }
            }
        }
    }
}
