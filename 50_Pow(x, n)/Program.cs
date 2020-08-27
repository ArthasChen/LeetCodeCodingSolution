using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_Pow_x__n_
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 递归
    /// 时间复杂度：O(logn)
    /// 空间复杂度：O(logn)
    /// </summary>
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            return Compute(x, n);
        }

        public double Compute(double x, long n)
        {
            if (n == 1)
            {
                return x;
            }

            if (n == 0)
            {
                return 1;
            }

            if (n < 0)
            {
                return 1d / Compute(x, -1 * n);
            }

            double y = Compute(x, n / 2);

            return n % 2 == 0 ? y * y : y * y * x;
        }
    }
}
