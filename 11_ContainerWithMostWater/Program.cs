using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input=new int[]
            {
                //1,8,6,2,5,4,8,3,7
                2,2,2,2,2
            };
            Solution s =new Solution();
            int a = s.MaxArea(input);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 解法一
    /// 遍历数组，每当到某位数时，计算跟后面每位的容量。2层循环，记录最大值。
    /// 时间复杂度：O(N^2)
    /// 空间复杂度：O(1)
    /// </summary>

    /// <summary>
    /// 解法二
    /// 双指针，初始时分别指向头和尾。当左指针小于右指针时，计算容量。判断两指针指向的值，较小值对应的指针的向另一指针方向移动。
    /// 如果左右指针指向的值相等，判断左指针下一个和右指针下一个谁最大，最大的那个指针移动。如果相等，移动左指针。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length < 2)
            {
                return 0;
            }

            int length = height.Length;
            int leftIndex = 0;
            int rightIndex = length - 1;

            int currentWidth = 0;
            int currentHeight = 0;
            int maxArea = 0;

            while (leftIndex < rightIndex)
            {
                currentWidth = rightIndex - leftIndex;
                currentHeight = Math.Min(height[leftIndex], height[rightIndex]);

                maxArea = Math.Max(maxArea, currentWidth * currentHeight);

                if (height[leftIndex] < height[rightIndex])
                {
                    leftIndex++;
                }
                else if (height[leftIndex] > height[rightIndex])
                {
                    rightIndex--;
                }
                // 左右指针指向的值相等时
                else
                {
                    // 如果左右指针值相等并且紧邻着，则直接退出循环。因为他俩的值在进入这次循环时就算好了。没必要再进行操作，从而让下次循环不满足再退出循环。
                    if (leftIndex == rightIndex - 1)
                    {
                        break;
                    }

                    // 如果左边指针指向的下一位值比右指针指向的下一位大或者相等，则左指针移动。
                    if (height[leftIndex + 1] >= height[rightIndex - 1])
                    {
                        leftIndex++;
                    }
                    else
                    {
                        rightIndex--;
                    }
                }
            }

            return maxArea;
        }
    }
}
