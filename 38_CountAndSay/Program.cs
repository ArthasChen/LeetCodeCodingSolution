using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _38_CountAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public string CountAndSay(int n)
        {
            string[] strArray = new string[n];
            strArray[0] = "1";

            for (int i = 1; i < n; i++)
            {
                strArray[i] = JieXi(strArray[i - 1]);
            }

            return strArray[n - 1];
        }

        private static string JieXi(string str)
        {
            int currentIndex = 0;
            string currentStr = str[0].ToString();
            string lastStr = str[0].ToString();
            int count = 1;
            string resulet = string.Empty;

            for (int i = 1; i < str.Length; i++)
            {
                currentStr = str[i].ToString();
                if (currentStr == lastStr)
                {
                    count++;
                }
                else
                {
                    resulet += count.ToString() + lastStr;
                    lastStr = currentStr;
                    count = 1;
                }
            }

            resulet += count.ToString() + lastStr;

            return resulet;
        }
    }
}
