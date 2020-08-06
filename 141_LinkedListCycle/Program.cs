using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _141_LinkedListCycle
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    /// <summary>
    /// 解法一
    /// 用哈希表记录遍历过的节点，进入节点后，如果在哈希表中查到节点存在，则意味着之前走过这个节点，链表有环。
    /// 如果遍历到尾节点，都未在哈希表中查到存在的，则无环。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n) 需要哈希表存储已经遍历过的节点的引用，或者地址。
    /// </summary>
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            HashSet<ListNode> hashSet = new HashSet<ListNode>();

            ListNode currentNode = head;

            while (currentNode != null)
            {
                if (hashSet.Contains(currentNode))
                {
                    return true;
                }
                else
                {
                    hashSet.Add(currentNode);
                    currentNode = currentNode.next;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// 解法二
    /// 双指针，快慢指针；快指针每次走两步，慢指针每次走一步。
    /// 如果无环，快指针先到尾节点的next节点null；如果有环，快指针必然会和慢指针重合。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution2
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            ListNode slowNode = head;
            ListNode fastNode = head;

            while (fastNode != null && fastNode.next != null)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;

                if (fastNode == slowNode)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
