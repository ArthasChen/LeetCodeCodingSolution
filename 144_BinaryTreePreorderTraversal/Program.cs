using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _144_BinaryTreePreorderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            IList<int> result = new List<int>();
            TreeNode currenNode = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(currenNode);

            while (stack.Count != 0)
            {
                currenNode = stack.Pop();
                result.Add(currenNode.val);

                if (currenNode.right != null)
                {
                    stack.Push(currenNode.right);
                }

                if (currenNode.left != null)
                {
                    stack.Push(currenNode.left);
                }
            }

            return result;
        }
    }
}
