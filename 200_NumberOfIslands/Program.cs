using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200_NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 深度优先搜索
    /// 时间复杂度：O(mn)  m是行数 n是列数
    /// 空间复杂度：O(mn) 在最坏情况下，整个网格均为陆地，深度优先搜索的深度达到m*n。递归会在栈中保存之前的信息，最多递归m*n层深度
    /// </summary>
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            int result = 0;

            int rows = grid.Length;
            int cols = grid[0].Length;
            int[,] visited = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col] == 0 && grid[row][col] == '1')
                    {
                        Queue<int[]> queue = new Queue<int[]>();
                        queue.Enqueue(new int[] { row, col });

                        while (queue.Count != 0)
                        {
                            int[] currentPoint = queue.Dequeue();
                            int currentRow = currentPoint[0];
                            int currentCol = currentPoint[1];

                            Console.WriteLine("x = " + currentRow.ToString() + " y = " + currentCol.ToString());

                            visited[currentRow, currentCol] = 1;

                            if (currentCol + 1 < cols && visited[currentRow, currentCol + 1] == 0 && grid[currentRow][currentCol + 1] == '1')
                            {
                                queue.Enqueue(new int[] { currentRow, currentCol + 1 });
                            }
                            if (currentRow + 1 < rows && visited[currentRow + 1, currentCol] == 0 && grid[currentRow + 1][currentCol] == '1')
                            {
                                queue.Enqueue(new int[] { currentRow + 1, currentCol });
                            }
                            if (currentCol - 1 >= 0 && visited[currentRow, currentCol - 1] == 0 && grid[currentRow][currentCol - 1] == '1')
                            {
                                queue.Enqueue(new int[] { currentRow, currentCol - 1 });
                            }
                            if (currentRow - 1 >= 0 && visited[currentRow - 1, currentCol] == 0 && grid[currentRow - 1][currentCol] == '1')
                            {
                                queue.Enqueue(new int[] { currentRow - 1, currentCol });
                            }
                        }
                        result++;
                    }

                    if (visited[row, col] == 0 && grid[row][col] == '0')
                    {
                        visited[row, col] = 1;
                    }
                }
            }

            return result;
        }

        public void BFS(char[][] grid, int[,] visited, int row, int col, int rows, int cols)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { row, col });

            while (queue.Count != 0)
            {
                int[] currentPoint = queue.Dequeue();
                int currentRow = currentPoint[0];
                int currentCol = currentPoint[1];

                visited[currentRow, currentCol] = 1;

                if (currentCol + 1 < cols && visited[currentRow, currentCol + 1] == 0 && grid[currentRow][currentCol + 1] == '1')
                {
                    queue.Enqueue(new int[] { currentRow, currentCol + 1 });
                }
                if (currentRow + 1 < rows && visited[currentRow + 1, currentCol] == 0 && grid[currentRow + 1][currentCol] == '1')
                {
                    queue.Enqueue(new int[] { currentRow + 1, currentCol });
                }
                if (currentCol - 1 >= 0 && visited[currentRow, currentCol - 1] == 0 && grid[currentRow][currentCol - 1] == '1')
                {
                    queue.Enqueue(new int[] { currentRow, currentCol - 1 });
                }
                if (currentRow - 1 >= 0 && visited[currentRow - 1, currentCol] == 0 && grid[currentRow - 1][currentCol] == '1')
                {
                    queue.Enqueue(new int[] { currentRow - 1, currentCol });
                }
            }
        }
    }

    /// <summary>
    /// 广度优先搜索
    /// 时间复杂度：O(mn)
    /// 空间复杂度：O(min(m,n)) 最坏请款下，存储m和n的最小值
    /// </summary>
    public class Solution2
    {
        private int counts = 0;
        private int result = 0;

        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            int rows = grid.Length;
            int cols = grid[0].Length;
            int[,] visited = new int[rows, cols];

            while (counts < rows * cols)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (visited[row, col] != 1)
                        {
                            bool isIslands = false;
                            DFS(grid, visited, row, col, rows, cols, ref isIslands);
                            if (isIslands)
                            {
                                result++;
                            }
                        }
                    }
                }

            }

            return result;
        }

        public void DFS(char[][] grid, int[,] visited, int row, int col, int rows, int cols, ref bool isIslands)
        {
            if (grid[row][col] == '0')
            {
                counts++;
                visited[row, col] = 1;
                return;
            }

            if (grid[row][col] == '1')
            {
                isIslands = true;
                counts++;
                visited[row, col] = 1;
                if (col + 1 < cols && visited[row, col + 1] != 1)
                {
                    DFS(grid, visited, row, col + 1, rows, cols, ref isIslands);
                }
                if (row + 1 < rows && visited[row + 1, col] != 1)
                {
                    DFS(grid, visited, row + 1, col, rows, cols, ref isIslands);
                }
                if (col - 1 >= 0 && visited[row, col - 1] != 1)
                {
                    DFS(grid, visited, row, col - 1, rows, cols, ref isIslands);
                }
                if (row - 1 >= 0 && visited[row - 1, col] != 1)
                {
                    DFS(grid, visited, row - 1, col, rows, cols, ref isIslands);
                }
            }
        }
    }
}
