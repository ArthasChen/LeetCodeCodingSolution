using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1143_LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string t1 = "bsbininm";
            string t2 = "jmjkbkjkv";
            s.LongestCommonSubsequence(t1, t2);
        }
    }

    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            // verification
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                return 0;
            }

            // logic
            int rows = text2.Length;
            int cols = text1.Length;
            int[,] array = new int[rows, cols];

            if (text2[0] == text1[0])
            {
                array[0, 0] = 1;
            }
            else
            {
                array[0, 0] = 0;
            }

            for (int i = 1; i < rows; i++)
            {
                if (text1[0] == text2[i])
                {
                    array[i, 0] = array[i - 1, 0] + 1;
                }
                else
                {
                    array[i, 0] = array[i - 1, 0];
                }
            }

            for (int i = 1; i < cols; i++)
            {
                if (text2[0] == text1[i])
                {
                    array[0, i] = array[0, i - 1] + 1;
                }
                else
                {
                    array[0, i] = array[0, i - 1];
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (text2[i] == text1[j])
                    {
                        array[i, j] = array[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        array[i, j] = Math.Max(array[i - 1, j], array[i, j - 1]);
                    }
                }
            }

            return array[rows - 1, cols - 1];
        }
    }
}
