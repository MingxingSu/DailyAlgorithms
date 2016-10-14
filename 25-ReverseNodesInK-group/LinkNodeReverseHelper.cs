using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_ReverseNodesInK_group
{
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

    public class LinkNodeReverseHelper
    {
        public ListNode Reversion(ListNode list)
        {
            if (list == null)
                return null;

            ListNode current = null;
            ListNode temp;

            while (list != null)
            {
                temp = new ListNode(list.val); //构建新的结点,对结点数据进行复制
                temp.next = current;
                current = temp;
                list = list.next;
            }
            list = current;


            return list;
        }



        //迭代方式  
        public ListNode Reverse_Ite(ListNode list)
        {
            ListNode newHead = null; //新链头 节点 
            ListNode cur = list; //定义一个指针，指向旧链

            //每次将原来链表的头取出
            while (cur != null)
            {
                ListNode tempNode = cur.next; //将原链表头结点的下一个节点取出来，放入临时节点
                cur.next = newHead; //将新链头节点放入第二节点

                newHead = cur; //将原链头节点放到新链头节点
                cur = tempNode; //接着处理 
            }

            return newHead;
        }

        //递归方式  
        public void Reverse_Recursive(ListNode oldHead, ListNode newHead)
        {
            if (oldHead == null)
            {
                oldHead = newHead;
                return;
            }

            ListNode tmp = oldHead.next; //将原来链表的头取出，并将第二个节点作为原来链表的头节点用于下一层递归  
            oldHead.next = newHead; //将取出的头设为新链表的头  
            Reverse_Recursive(tmp, oldHead); //接着处理  
        }


    }
}
