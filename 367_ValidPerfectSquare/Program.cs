using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _367_ValidPerfectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool IsPerfectSquare(int num)
        {
            if (num < 2)
            {
                return true;
            }

            long left = 2, right = num / 2, x, guessSquared;
            while (left <= right)
            {
                x = left + (right - left) / 2;
                guessSquared = x * x;
                if (guessSquared == num)
                {
                    return true;
                }
                if (guessSquared > num)
                {
                    right = x - 1;
                }
                else
                {
                    left = x + 1;
                }
            }
            return false;
        }
    }
}
