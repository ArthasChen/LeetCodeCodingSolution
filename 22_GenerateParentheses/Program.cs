using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.GenerateParenthesis(3);
        }
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            if (n <= 0)
            {
                return new List<string>();
            }

            IList<IList<string>> dp = new List<IList<string>>();
            IList<string> dp0 = new List<string>() { "" };
            dp.Add(dp0);

            for (int i = 1; i <= n; i++)
            {
                IList<string> currenDP = new List<string>();

                for (int j = 0; j < i; j++)
                {
                    IList<string> str1 = dp[j];
                    IList<string> str2 = dp[i - 1 - j];

                    foreach (var item1 in str1)
                    {
                        foreach (var item2 in str2)
                        {
                            currenDP.Add("(" + item1 + ")" + item2);
                        }
                    }

                }

                dp.Add(currenDP);
            }

            return dp[n];
        }
    }
}
