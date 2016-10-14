using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_ReverseNodesInK_group
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> testData0 =
            //    new List<string>() {"MCDLXXVI", "IV", "V", "VII", "XXIX", "LV", "XCIX"};

            var solution = new Solution();
            List<int> testData =
                new List<int>() {1,2,3,4};
            int k = 2;

            var listNodes = solution.GenerateList(testData);
            var listNodeResult = solution.ReverseKGroup(listNodes,k);

            Console.WriteLine("Input List:{0}, After Reverse Nodes in {1} groups, result is : {2}",
                solution.DisplayListNodes(listNodes),
                k,
                solution.DisplayListNodes(listNodeResult));


            testData =new List<int>() { 1, 2, 3, 4,5,6,7 };
            k = 3;

            listNodes = solution.GenerateList(testData);
            listNodeResult = solution.ReverseKGroup(listNodes,k);

            Console.WriteLine("Input List:{0}, After Reverse Nodes in {1} groups, result is : {2}",
                solution.DisplayListNodes(listNodes),
                k,
                solution.DisplayListNodes(listNodeResult));

            Console.Read();
        }

        //这个自己写的算法牛逼了！打败了97.56%的人！
        public class Solution
        {
            //Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

            //If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.

            //You may not alter the values in the nodes, only nodes itself may be changed.

            //Only constant memory is allowed.

            //For example,
            //Given this linked list: 1->2->3->4->5

            //For k = 2, you should return: 2->1->4->3->5

            //For k = 3, you should return: 3->2->1->4->5
            public ListNode ReverseKGroup(ListNode head, int k) 
            {
                //list为空，或者只有一个节点，直接返回该链表
                if (head == null || head.next ==null)
                    return head;

                //找到递归点，保存到临时节点
                ListNode tempNode =head;
                int counter = k;
                while (tempNode != null && counter > 0)
                {
                    tempNode = tempNode.next;//移动指针至递归点
                    counter--;
                }

                //节点不够K个时，直接返回
                if (tempNode == null && counter > 0)
                {
                    return head;
                }

                //找到前K个节点（找到第K个节点，并把其的next指针置空，从而截断原链表）
                ListNode nodeToBeReversed = head;
                int count2 = k;
                while (nodeToBeReversed != null && count2 > 1)
                {
                    nodeToBeReversed = nodeToBeReversed.next;
                    count2--;
                }
                nodeToBeReversed.next = null;

                //对前K个节点原地逆序
                LinkNodeReverseHelper helper = new LinkNodeReverseHelper();
                ListNode reversedNode = helper.Reverse_Ite(head);

                //找到list联接点
                ListNode newHead = reversedNode;
                int count3 = k;
                while (reversedNode != null && count3 > 1)
                {
                    reversedNode = reversedNode.next;
                    count3--;
                }

                 //联接递归结果
                reversedNode.next = ReverseKGroup(tempNode, k);

                return newHead;
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
    }
}
