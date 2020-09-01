using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _529_Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            // verification
            if (board == null || board.Length == 0 || board[0].Length == 0 || click == null || click.Length != 2 ||
                click[0] < 0 || click[0] >= board.Length || click[1] < 0 || click[1] >= board[0].Length)
            {
                return new char[0][];
            }

            // logic
            char[][] resultChars = new char[board.Length][];
            bool[][] visited = new bool[board.Length][];

            for (int i = 0; i < board.Length; i++)
            {
                resultChars[i] = new char[board[0].Length];
                visited[i] = new bool[board[0].Length];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    resultChars[i][j] = board[i][j];
                }
            }



            Queue<int[]> queue = new Queue<int[]>();
            int[] currentPoint = new int[2];

            if (board[click[0]][click[1]] == 'M')
            {
                resultChars[click[0]][click[1]] = 'X';
            }
            else
            {
                // 广度优先 先遍历周围8个位置 没有地雷的话 再把8个位置放进队列
                queue.Enqueue(click);
                visited[click[0]][click[1]] = true;

                while (queue.Count != 0)
                {
                    currentPoint = queue.Dequeue();

                    // 遍历8个位置，如果没有雷，把八个位置添加进队列，如果有，把当前位置改为雷的数量。
                    var countsOfDILEI = Compute(currentPoint, board, visited);

                    if (countsOfDILEI == 0)
                    {
                        AddToQueue(currentPoint, board, queue, visited);
                        resultChars[currentPoint[0]][currentPoint[1]] = 'B';
                    }
                    else
                    {
                        resultChars[currentPoint[0]][currentPoint[1]] = char.Parse(countsOfDILEI.ToString());
                    }
                }
            }

            return resultChars;
        }

        private int Compute(int[] currentPoint, char[][] board, bool[][] visited)
        {
            int countsOfDILEI = 0;
            int row = currentPoint[0];
            int col = currentPoint[1];
            int rows = board.Length;
            int cols = board[0].Length;

            // right
            if (col + 1 < cols && visited[row][col + 1] == false)
            {
                if (board[row][col + 1] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // right down
            if (row + 1 < rows && col + 1 < cols && visited[row + 1][col + 1] == false)
            {
                if (board[row + 1][col + 1] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // down
            if (row + 1 < rows && visited[row + 1][col] == false)
            {
                if (board[row + 1][col] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // left down
            if (row + 1 < rows && col - 1 >= 0 && visited[row + 1][col - 1] == false)
            {
                if (board[row + 1][col - 1] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // left
            if (col - 1 >= 0 && visited[row][col - 1] == false)
            {
                if (board[row][col - 1] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // left up
            if (row - 1 >= 0 && col - 1 >= 0 && visited[row - 1][col - 1] == false)
            {
                if (board[row - 1][col - 1] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // up
            if (row - 1 >= 0 && visited[row - 1][col] == false)
            {
                if (board[row - 1][col] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            // right up
            if (row - 1 >= 0 && col + 1 < cols && visited[row - 1][col + 1] == false)
            {
                if (board[row - 1][col + 1] == 'M')
                {
                    countsOfDILEI++;
                }
            }

            return countsOfDILEI;
        }

        private void AddToQueue(int[] currentPoint, char[][] board, Queue<int[]> queue, bool[][] visited)
        {
            int row = currentPoint[0];
            int col = currentPoint[1];
            int rows = board.Length;
            int cols = board[0].Length;

            // right
            if (col + 1 < cols && visited[row][col + 1] == false)
            {
                queue.Enqueue(new int[2] { row, col + 1 });
                visited[row][col + 1] = true;
            }

            // right down
            if (row + 1 < rows && col + 1 < cols && visited[row + 1][col + 1] == false)
            {
                queue.Enqueue(new int[2] { row + 1, col + 1 });
                visited[row + 1][col + 1] = true;
            }

            // down
            if (row + 1 < rows && visited[row + 1][col] == false)
            {
                queue.Enqueue(new int[2] { row + 1, col });
                visited[row + 1][col] = true;
            }

            // left down
            if (row + 1 < rows && col - 1 >= 0 && visited[row + 1][col - 1] == false)
            {
                queue.Enqueue(new int[2] { row + 1, col - 1 });
                visited[row + 1][col - 1] = true;
            }

            // left
            if (col - 1 >= 0 && visited[row][col - 1] == false)
            {
                queue.Enqueue(new int[2] { row, col - 1 });
                visited[row][col - 1] = true;
            }

            // left up
            if (row - 1 >= 0 && col - 1 >= 0 && visited[row - 1][col - 1] == false)
            {
                queue.Enqueue(new int[2] { row - 1, col - 1 });
                visited[row - 1][col - 1] = true;
            }

            // up
            if (row - 1 >= 0 && visited[row - 1][col] == false)
            {
                queue.Enqueue(new int[2] { row - 1, col });
                visited[row - 1][col] = true;
            }

            // right up
            if (row - 1 >= 0 && col + 1 < cols && visited[row - 1][col + 1] == false)
            {
                queue.Enqueue(new int[2] { row - 1, col + 1 });
                visited[row - 1][col + 1] = true;
            }
        }

    }
}
