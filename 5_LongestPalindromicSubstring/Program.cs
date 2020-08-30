using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            // verification
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            // logic
            string resultString = string.Empty;
            // dp[i]表示以i为结尾的最大字串
            string[] dp = new string[s.Length];

            // 构建dp
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = s[i].ToString();

                // 从s的索引0开始往i遍历，判断是否是回文字符串,当遇到的第一个跟s[i]相同的字符，开始进行判断，如果是回文，则dp[i]找到了，如果一直遍历到i-1还未找到，则dp[i]为s[i]
                for (int j = 0; j < i; j++)
                {
                    // 满足判断初始条件，进入判断是否回文
                    if (s[j] == s[i] && Determine(s, j, i))
                    {
                        dp[i] = s.Substring(j, i - j + 1);
                        break;
                    }
                }
            }

            // 遍历dp，找到最长的dp[i],即为最大字串
            string temMinString = string.Empty;
            for (int i = 0; i < dp.Length; i++)
            {
                if (dp[i].Length > resultString.Length)
                {
                    resultString = dp[i];
                }
            }

            return resultString;
        }

        /// <summary>
        /// 判断是否是回文
        /// </summary>
        /// <param name="s">待判断字符串</param>
        /// <param name="start">回文开头</param>
        /// <param name="end">回文结尾</param>
        /// <returns> true 是回文，false 不是回文 </returns>
        private bool Determine(string s, int start, int end)
        {
            int leftIndex = start;
            int rightIndex = end;
            bool isHuiWen = false;

            while (leftIndex < rightIndex)
            {
                if (s[leftIndex] == s[rightIndex])
                {
                    leftIndex++;
                    rightIndex--;
                }
                else
                {
                    return isHuiWen;
                }
            }

            isHuiWen = true;

            return isHuiWen;
        }
    }
}
