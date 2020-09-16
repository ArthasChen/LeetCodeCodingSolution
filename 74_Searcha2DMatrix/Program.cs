using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _74_Searcha2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] input = new int[][]
            {
                //new int[2]{-10,-10},
                //new int[2]{-9,-9},
                //new int[2]{-8,-6},
                //new int[2]{-4,-2},
                //new int[2]{0,1},
                //new int[2]{3,3},
                //new int[2]{5,5},
                //new int[2]{6,8},
                new int[4]{1,3,5,7}, 
                new int[4]{10,11,16,20}, 
                new int[4]{23,30,34,40}, 
            };

            s.SearchMatrix(input, 21);
        }
    }

    /// <summary>
    /// 解法一
    /// </summary>
    public class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            // verification
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }

            // logic
            int leftIndex = 0;
            int rightIndex = matrix.Length - 1;
            int midIndex = 0;
            int length = matrix[0].Length;

            while (leftIndex <= rightIndex)
            {
                midIndex = (rightIndex - leftIndex) / 2 + leftIndex;

                if (matrix[midIndex][0] == target)
                {
                    return true;
                }
                else if (matrix[midIndex][0] > target)
                {
                    rightIndex = midIndex - 1;
                }
                else
                {
                    if (matrix[midIndex][length - 1] == target)
                    {
                        return true;
                    }
                    else if (matrix[midIndex][length - 1] > target)
                    {
                        // 在m范围里二分
                        return SearchBinary(matrix[midIndex], target);
                    }
                    else
                    {
                        if (leftIndex + 1 == rightIndex)
                        {
                            // 在r范围里二分
                            return SearchBinary(matrix[rightIndex], target);
                        }
                        else
                        {
                            leftIndex = midIndex + 1;
                        }
                    }
                }
            }

            return false;
        }

        private bool SearchBinary(int[] array, int target)
        {
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            int midIndex = 0;

            while (leftIndex <= rightIndex)
            {
                midIndex = (rightIndex - leftIndex) / 2 + leftIndex;

                if (array[midIndex] == target)
                {
                    return true;
                }
                else if (array[midIndex] > target)
                {
                    rightIndex = midIndex - 1;
                }
                else
                {
                    leftIndex = midIndex + 1;
                }
            }

            return false;
        }
    }

    // 解法二，根据题意。把二维数组组成一维数组，然后而分。
}
