using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _590_N_aryTreePostorderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /*
    // Definition for a Node.
    */
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        public IList<int> Postorder(Node root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            IList<int> result = new List<int>();

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            Node currentNode = root;
            stack1.Push(currentNode);

            while (stack1.Count != 0)
            {
                currentNode = stack1.Pop();
                stack2.Push(currentNode);

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    if (currentNode.children[i] != null)
                    {
                        stack1.Push(currentNode.children[i]);
                    }
                }
            }

            while (stack2.Count != 0)
            {
                currentNode = stack2.Pop();
                result.Add(currentNode.val);
            }

            return result;
        }
    }
}
