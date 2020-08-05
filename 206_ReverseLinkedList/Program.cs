using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _206_ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            node1.next = node2;
            node2.next = node3;

            Solution s = new Solution();
            var v = s.ReverseList(node1);
        }
    }


    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    /// <summary>
    /// 解法一：
    /// 迭代
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            // verification
            if (head == null)
            {
                return null;
            }

            // logic
            ListNode preNode = null;
            ListNode curNode = head;
            ListNode nextNode = null;

            while (curNode != null)
            {
                nextNode = curNode.next;
                curNode.next = preNode;
                preNode = curNode;
                curNode = nextNode;
            }

            return preNode;
        }
    }

    /// <summary>
    /// 解法二
    /// 递归解法
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n) 由于使用递归，将会使用隐式栈空间。递归深度可能会达到 n 层。
    /// </summary>
    public class Solution2
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            ListNode resultNode = ReverseList(head.next);
            head.next.next = head;
            head.next = null;

            return resultNode;
        }
    }
}
