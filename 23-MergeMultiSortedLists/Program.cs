using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_MergeMultiSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list1 = { 1, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10 };
            int[] list2 = { 1, 2, 5, 7, 10, 11, 15 };
            int[] list3 = { 6, 7, 8, 11, 20 };
            int[] list4 = { 1,2,2,2,2,2,2,2};
            int[] list5 = { 16,18,18,22,99,99 };

            var solution = new Solution();

            var listNodes1 = solution.GenerateList(list1.ToList());
            var listNodes2 = solution.GenerateList(list2.ToList());
            var listNodes3 = solution.GenerateList(list3.ToList());
            var listNodes4 = solution.GenerateList(list4.ToList());
            var listNodes5 = solution.GenerateList(list5.ToList());

            var lists = new ListNode[] { listNodes1, listNodes2, listNodes3, listNodes4, listNodes5};

            var listNodeResult = solution.MergeKLists(lists);

            Console.WriteLine("Merged Result:" + solution.DisplayListNodes(listNodeResult));
            Console.Read();
        }
    }

    //Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
    public class Solution
    {
        #region My Origional Solution
        //Time complexicity about O(N*LogM)), N为全部节点数，M为链表数
        public ListNode MergeKLists(ListNode[] lists)
        {
            //异常
            if (lists == null || lists.Length == 0)
                return null;

            int len = lists.Length;
            
            //基准情形
            if (lists.Length == 1)
                return lists[0];

            //分治
            int mid = len / 2;

            //Divide and conquer
            var leftNodes = lists.Take(mid).ToArray();
            var rightNodes = lists.Skip(mid).ToArray();

            return MergeTwoLists(MergeKLists(leftNodes), MergeKLists(rightNodes));
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode tempNode = new ListNode(0);
            ListNode resultNode = tempNode;//保存首指针以方便返回值

            //好一招求同存异
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    tempNode.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tempNode.next = l2;
                    l2 = l2.next;
                }
                tempNode = tempNode.next;
            }
            //处理剩余的尾巴
            while (l1 != null)
            {
                tempNode.next = l1;
                l1 = l1.next;
                tempNode = tempNode.next;
            }
            while (l2 != null)
            {
                tempNode.next = l2;
                l2 = l2.next;

                tempNode = tempNode.next;
            }

            return resultNode.next;

        }
         

        #endregion


        #region Solution2 -Implemented by Binary Tree
        //Solution2: implemented by Binary Tree
        public ListNode MergeKListsWithBinaryTree(ListNode[] lists)
        {
            return null;
        }

        #endregion


        #region Help Methods

        public ListNode GenerateList(List<int> list)
        {
            if (list == null || list.Count == 0)
                return null;

            ListNode resultList = new ListNode(list[0]);
            ListNode temp = resultList;
            for (int i = 0; i < list.Count; i++)
            {
                var node = new ListNode(list[i]);

                temp.next = node;
                temp = temp.next;
            }

            return resultList.next;
        }

        public string DisplayListNodes(ListNode listNode)
        {
            if (listNode == null)
                return "";

            string nodesStr = "";
            while (listNode != null)
            {
                nodesStr += "->" + listNode.val;

                listNode = listNode.next;
            }

            return nodesStr;
        }

        #endregion

    }


    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
}
