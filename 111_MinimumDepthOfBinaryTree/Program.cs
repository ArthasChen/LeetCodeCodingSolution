using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _111_MinimumDepthOfBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /**
   * Definition for a binary tree node.*/
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// 解法一
    /// 递归
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int minDepth = 0;
            int leftMinDepth = 0;

            if (root.left != null)
            {
                leftMinDepth = MinDepth(root.left);
            }
            else
            {
                leftMinDepth = int.MaxValue;
            }

            int rightMinDepth = 0;
            if (root.right != null)
            {
                rightMinDepth = MinDepth(root.right);
            }
            else
            {
                rightMinDepth = int.MaxValue;
            }

            minDepth = Math.Min(leftMinDepth, rightMinDepth) + 1;

            return minDepth;
        }
    }
}
