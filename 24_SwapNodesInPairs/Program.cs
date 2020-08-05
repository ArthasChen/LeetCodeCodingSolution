using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_SwapNodesInPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;

            ListNode node11 = new ListNode(1);


            Solution s = new Solution();
            var a = s.SwapPairs(node11);
            Console.ReadKey();
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
    /// 递归解法
    /// 时间复杂度：o(n)
    /// 空间复杂度：o(n)
    /// </summary>
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            ListNode re = SwapPairs(head.next.next);

            ListNode temNode = head.next;
            head.next = re;
            temNode.next = head;

            return temNode;
        }
    }
}
