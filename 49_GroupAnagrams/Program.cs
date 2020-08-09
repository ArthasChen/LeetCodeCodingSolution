using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49_GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            Solution s = new Solution();
            s.GroupAnagrams(input);
        }
    }

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // verification
            if (strs == null || strs.Length == 0)
            {
                return new List<IList<string>>();
            }

            // logic
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            int[] charAraay = new int[26];


            foreach (var str in strs)
            {
                Array.Clear(charAraay,0,charAraay.Length);

                for (int i = 0; i < str.Length; i++)
                {
                    charAraay[str[i] - 'a'] += 1;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in charAraay)
                {
                    sb.Append(item);
                }

                if (dic.ContainsKey(sb.ToString()))
                {
                    dic[sb.ToString()].Add(str);
                }
                else
                {
                    dic[sb.ToString()] = new List<string>();
                    dic[sb.ToString()].Add(str);
                }
            }

            foreach (var key in dic.Keys)
            {
                result.Add(dic[key]);
            }

            return result;
        }
    }
}
