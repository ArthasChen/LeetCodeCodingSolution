using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _860_LemonadeChange
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool LemonadeChange(int[] bills)
        {
            // verification
            if (bills == null || bills.Length <= 0)
            {
                return false;
            }

            // logic
            int five = 0;
            int ten = 0;

            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    five += 1;
                }
                else if (bills[i] == 10)
                {
                    if (five > 0)
                    {
                        five -= 1;
                        ten += 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (bills[i] == 20)
                {
                    if (five > 0 && ten > 0)
                    {
                        five -= 1;
                        ten -= 1;
                    }
                    else if (five >= 3)
                    {
                        five -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
