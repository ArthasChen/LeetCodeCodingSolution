using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _169_MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            int resultNamuber = 0;
            int counts = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (counts == 0)
                {
                    resultNamuber = nums[i];
                    counts++;
                }
                else
                {
                    if (nums[i] == resultNamuber)
                    {
                        counts++;
                    }
                    else
                    {
                        counts--;
                    }
                }
            }

            return resultNamuber;
        }
    }
}
