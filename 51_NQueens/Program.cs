using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s=new Solution();
            s.SolveNQueens(3);
        }
    }

    /// <summary>
    /// 深度优先搜索
    /// 时间复杂度：O(n!) 
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        IList<IList<string>> result = new List<IList<string>>();
        IList<int> currenResult = new List<int>();
        HashSet<int> dangerCol = new HashSet<int>();
        HashSet<int> dangerPie = new HashSet<int>();
        HashSet<int> dangerNa = new HashSet<int>();

        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n <= 0)
            {
                return result;
            }

            DFS(currenResult, 0, n);

            return result;
        }

        public void DFS(IList<int> currentRes, int row, int n)
        {
            if (row >= n)
            {
                result.Add(Compute(currentRes, n));
                return;
            }

            // current level logic
            for (int col = 0; col < n; col++)
            {
                // 满足未受攻击的判定  col pie na
                if (!dangerCol.Contains(col) && !dangerPie.Contains(row + col) && !dangerNa.Contains(row - col))
                {
                    currentRes.Add(col);

                    dangerCol.Add(col);
                    dangerPie.Add(row + col);
                    dangerNa.Add(row - col);

                    // drill down
                    DFS(currentRes, row + 1, n);

                    // reverse state
                    currentRes.Remove(col);

                    dangerCol.Remove(col);
                    dangerPie.Remove(row + col);
                    dangerNa.Remove(row - col);
                }
            }
        }

        private IList<string> Compute(IList<int> currentRes, int n)
        {
            IList<string> reList = new List<string>();

            for (int row = 0; row < n; row++)
            {
                StringBuilder sb = new StringBuilder();

                for (int col = 0; col < n; col++)
                {
                    if (col == currentRes[row])
                    {
                        sb.Append("Q");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                reList.Add(sb.ToString());
            }

            return reList;
        }
    }
}
