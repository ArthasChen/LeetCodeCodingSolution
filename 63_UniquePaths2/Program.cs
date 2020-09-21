using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _63_UniquePaths2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 分治思想 会超时
    /// </summary>
    //public class Solution
    //{
    //    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    //    {
    //        // verification
    //        if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
    //        {
    //            return 0;
    //        }

    //        // logic
    //        return FindPathCounts(obstacleGrid, 0, 0, obstacleGrid.Length, obstacleGrid[0].Length);
    //    }

    //    private int FindPathCounts(int[][] obstacleGrid, int row, int col, int rows, int cols)
    //    {
    //        // end condition
    //        if (obstacleGrid[row][col] == 1)
    //        {
    //            return 0;
    //        }

    //        if (row == rows - 1 && col == cols - 1)
    //        {
    //            return 1;
    //        }

    //        // current level logic
    //        int rightCounts = 0;
    //        int downCounts = 0;

    //        // dirll down

    //        if (row < rows && col + 1 < cols && obstacleGrid[row][col + 1] != 1)
    //        {
    //            rightCounts = FindPathCounts(obstacleGrid, row, col + 1, rows, cols);
    //        }

    //        if (row + 1 < rows && col < cols && obstacleGrid[row + 1][col] != 1)
    //        {
    //            downCounts = FindPathCounts(obstacleGrid, row + 1, col, rows, cols);
    //        }


    //        // reverse state

    //        return rightCounts + downCounts;
    //    }
    //}


    /// <summary>
    /// 动态规划
    /// </summary>
    public class Solution2
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            // verification
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
            {
                return 0;
            }

            // logic
            int rows = obstacleGrid.Length;
            int cols = obstacleGrid[0].Length;
            int[,] dp = new int[rows, cols];

            if (obstacleGrid[0][0] == 1)
            {
                dp[0, 0] = 0;
            }
            else
            {
                dp[0, 0] = 1;
            }

            for (int row = 0; row < rows && obstacleGrid[row][0] == 0; row++)
            {
                dp[row, 0] = 1;
            }

            for (int col = 0; col < cols && obstacleGrid[0][col] == 0; col++)
            {
                dp[0, col] = 1;
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (obstacleGrid[row][col] == 1)
                    {
                        dp[row, col] = 0;
                    }
                    else
                    {
                        dp[row, col] = dp[row, col - 1] + dp[row - 1, col];
                    }
                }
            }

            return dp[rows-1, cols-1];

            //if (obstacleGrid[rows - 1][cols - 1] == 1)
            //{
            //    dp[rows - 1, cols - 1] = 1;
            //}
            //else
            //{
            //    dp[rows - 1, cols - 1] = 0;
            //}

            //for (int row = 0; row < rows - 1; row++)
            //{
            //    if (obstacleGrid[row][cols - 1] == 1)
            //    {
            //        dp[row, cols - 1] = 0;
            //    }
            //    else
            //    {
            //        dp[row, cols - 1] = 1;
            //    }
            //}

            //for (int col = 0; col < cols - 1; col++)
            //{
            //    if (obstacleGrid[rows - 1][col] == 1)
            //    {
            //        dp[rows - 1, col] = 0;
            //    }
            //    else
            //    {
            //        dp[rows - 1, col] = 1;
            //    }
            //}

            //for (int row = rows - 2; row >= 0; row--)
            //{
            //    for (int col = cols - 2; col >= 0; col--)
            //    {
            //        if (obstacleGrid[row][col] == 1)
            //        {
            //            dp[row, col] = 0;
            //        }
            //        else
            //        {
            //            dp[row, col] = dp[row, col + 1] + dp[row + 1, col];
            //        }
            //    }
            //}

            //return dp[0, 0];
        }
    }
}
