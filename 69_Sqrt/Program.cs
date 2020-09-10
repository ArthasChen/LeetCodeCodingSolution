using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _69_Sqrt
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MySqrt(int x)
        {
            int l = 0, r = x, ans = -1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if ((long)mid * mid <= x)
                {
                    ans = mid;
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return ans;
        }
    }
}
