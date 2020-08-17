using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _226_InvertBinaryTree
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
    /// 时间复杂度：O(n) n为树中节点的个数，每个节点都被访问一次。
    /// 空间复杂度：O(n) 使用了递归，在最坏情况下栈内需要存放O(h)个方法调用，其中 h 是树的高度。由于 h∈O(n)，可得出空间复杂度为O(n)。
    /// </summary>
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode leftTreeNode = null;
            if (root.left != null)
            {
                leftTreeNode = InvertTree(root.left);
            }

            TreeNode rightTreeNode = null;
            if (root.right != null)
            {
                rightTreeNode = InvertTree(root.right);
            }

            root.left = rightTreeNode;
            root.right = leftTreeNode;

            return root;
        }
    }

    /// <summary>
    /// 解法二
    /// 迭代
    /// 时间复杂度：O(n) n为树中节点的个数，每个节点都被访问一次
    /// 空间复杂度：O(n) 最多的时候栈里有一层满的子节点，是n的函数。因此还是O(n)级别的。
    /// </summary>
    public class Solution2
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode currentNode = root;
            queue.Enqueue(currentNode);

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();
                TreeNode temNode = currentNode.left;
                currentNode.left = currentNode.right;
                currentNode.right = temNode;

                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }

            return root;
        }
    }
}
