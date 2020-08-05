using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n <= 2)
            {
                return n;
            }

            int sum = 0;
            int num1 = 1;
            int num2 = 2;

            for (int i = 3; i <= n; i++)
            {
                sum = num1 + num2;
                num1 = num2;
                num2 = sum;
            }

            return sum;
        }
    }
}
