using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _21_MergeTwoSorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list1 = { 1, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10 };
            int[] list2 = { 1, 2, 5, 7,10,11,15 };

            var solution = new Solution();

            var listNodes1 = solution.GenerateList(list1.ToList());
            var listNodes2 = solution.GenerateList(list2.ToList());
            var listNodeResult = solution.MergeTwoLists(listNodes1, listNodes2);

            Console.WriteLine("Sort Result"+ solution.DisplayListNodes(listNodeResult));
            Console.Read();
        }
    }

    public class Solution
    {
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


