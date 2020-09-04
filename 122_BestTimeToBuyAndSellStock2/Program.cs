using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _122_BestTimeToBuyAndSellStock2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            // verification
            if (prices == null || prices.Length <= 1)
            {
                return 0;
            }

            // logic
            int max = 0;
            int buyIndex = 0;
            int sellIndex = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    sellIndex = i;
                }
                else if (prices[i] < prices[i - 1])
                {
                    max += prices[sellIndex] - prices[buyIndex];

                    buyIndex = i;
                    sellIndex = i;
                }
            }

            max += prices[sellIndex] - prices[buyIndex];

            return max;
        }
    }
}
