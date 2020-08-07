using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _84_LargestRectangleInHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 解法一：暴力解法
    /// 遍历数组每个数，以遍历到的数字作为高度，往左右继续遍历，直到遇到小于高度的数字为止，
    /// 然后根据左右指针求出中间的宽度，宽度乘以高度即为以遍历到的高度作为高的面积。
    /// 时间复杂度：o(n^2)
    /// 空间复杂度：o(1)
    /// </summary>
    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            // verification
            if (heights == null || heights.Length == 0)
            {
                return 0;
            }

            if (heights.Length == 1)
            {
                return heights[0];
            }

            // logic
            int maxArea = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                int leftIndex = i - 1;
                int rightIndex = i + 1;

                // to left
                while (leftIndex >= 0 && heights[leftIndex] >= heights[i])
                {
                    leftIndex--;
                }

                // to right
                while (rightIndex < heights.Length && heights[rightIndex] >= heights[i])
                {
                    rightIndex++;
                }

                maxArea = Math.Max((rightIndex - leftIndex - 1) * heights[i], maxArea);
            }

            return maxArea;
        }
    }

    /// <summary>
    /// 解法二：单调栈,空间换时间
    /// 使用一个辅助栈来存储遍历过的索引，存储的规则如下：如果栈为空，则添加遍历到的索引i；
    /// 如果栈不为空，则判断栈顶索引对应的高度和当前遍历到的索引i对应的高度，如果当前索引对应高度 小于 栈顶高度，则意味着以栈顶高度为高的面积右侧边界已经确定，
    /// 此时需要确定左侧边界，左侧边界一定是紧靠着栈顶索引的左侧的第一个对应高度 小于  栈顶高度的，而辅助栈是单调递增的，栈顶元素出栈后的栈顶元素即为左侧边界。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution2
    {
        public int LargestRectangleArea(int[] heights)
        {
            // verification
            if (heights == null || heights.Length == 0)
            {
                return 0;
            }

            if (heights.Length == 1)
            {
                return heights[0];
            }

            // logic
            int maxArea = 0;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Count != 0 && heights[stack.Peek()] > heights[i])
                {
                    int height = heights[stack.Pop()];
                    int width = 0;

                    if (stack.Count != 0)
                    {
                        width = i - stack.Peek() - 1;
                    }
                    else
                    {
                        width = i;
                    }

                    maxArea = Math.Max(height * width, maxArea);
                }

                stack.Push(i);
            }

            while (stack.Count != 0)
            {
                int height = heights[stack.Pop()];
                int width = 0;

                if (stack.Count != 0)
                {
                    width = heights.Length - stack.Peek() - 1;
                }
                else
                {
                    width = heights.Length;
                }

                maxArea = Math.Max(height * width, maxArea);
            }

            return maxArea;
        }
    }
}
