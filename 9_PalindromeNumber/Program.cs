using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var a = s.IsPalindrome(13431);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            // verification
            if (x < 0)
            {
                return false;
            }

            // logic
            if (x >= 0 && x < 9)
            {
                return true;
            }

            int oriNum = x;
            int newNum = 0;
            int temNum = 0;
            while (x > 0)
            {
                temNum = x % 10;
                x /= 10;
                newNum = newNum * 10 + temNum;
            }

            if (newNum == oriNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
