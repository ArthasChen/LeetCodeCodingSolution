using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _155_MinStack
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 在O(1)时间复杂度内检索到最小元素
    /// </summary>
    public class MinStack
    {
        private Stack<int> stack = null;
        private Stack<int> helpStack = null;

        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<int>();
            helpStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);

            if (helpStack.Count == 0)
            {
                helpStack.Push(x);
            }
            else
            {
                helpStack.Push(Math.Min(helpStack.Peek(), x));
            }
        }

        public void Pop()
        {
            stack.Pop();
            helpStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return helpStack.Peek();
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
