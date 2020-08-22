using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _344_ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 时间复杂度:O(n)
    /// 空间复杂度:O(1)
    /// </summary>
    public class Solution
    {
        public void ReverseString(char[] s)
        {
            // verification
            if (s == null || s.Length == 0)
            {
                return;
            }

            // logic
            int leftIndex = 0;
            int rightIndex = s.Length - 1;

            while (leftIndex < rightIndex)
            {
                char tem = s[leftIndex];
                s[leftIndex] = s[rightIndex];
                s[rightIndex] = tem;

                leftIndex++;
                rightIndex--;
            }
        }
    }

    /// <summary>
    ///  递归
    /// 时间复杂度:O(n)
    /// 空间复杂度:O(n) 递归过程中使用了n的堆栈空间
    /// </summary>
    public class Solution2
    {
        public void ReverseString(char[] s)
        {
            // verification
            if (s == null || s.Length == 0)
            {
                return;
            }

            // logic
            ReverseCore(s, 0, s.Length - 1);
        }

        public void ReverseCore(char[] s, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            char tem = s[leftIndex];
            s[leftIndex] = s[rightIndex];
            s[rightIndex] = tem;

            ReverseCore(s, ++leftIndex, --rightIndex);
        }
    }
}
