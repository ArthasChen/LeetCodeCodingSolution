using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _242_ValidAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1) 常数级别大小的的哈希表
    /// </summary>
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            // verification
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(s))
            {
                return true;
            }

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(s) || s.Length != t.Length)
            {
                return false;
            }

            // logic
            int[] dic = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                char temChar = s[i];
                dic[temChar - 'a'] += 1;

                char temCharInT = t[i];
                dic[temCharInT - 'a'] -= 1;
            }

            foreach (var item in dic)
            {
                if (item != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
