using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 解法一
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n) 需要辅助栈
    /// </summary>
    public class Solution
    {
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                    continue;
                }

                if (s[i] == ')' && !(stack.Count != 0 && stack.Pop() == '('))
                {
                    return false;
                }

                if (s[i] == ']' && !(stack.Count != 0 && stack.Pop() == '['))
                {
                    return false;
                }

                if (s[i] == '}' && !(stack.Count != 0 && stack.Pop() == '{'))
                {
                    return false;
                }
            }

            if (stack.Count == 0)
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
