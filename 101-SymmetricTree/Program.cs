using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _101_SymmetricTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        //String: Beat 24%
        //StringBuilder, beat 44.83%
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;//空树
            if (root.left == null && root.right == null) return true;//只有一个根节点

            StringBuilder  leftStr = new StringBuilder();
            StringBuilder rightStr = new StringBuilder();
            PreTraverse(root.left,ref leftStr);
            PreTraverse_Counter(root.right,ref rightStr);

            return leftStr.Equals(rightStr);
        }

        private void PreTraverse(TreeNode node, ref StringBuilder str)
        {
            if (node != null)
            {
                str.Append(node.val);
                PreTraverse(node.left, ref str);
                PreTraverse(node.right, ref str);
            }
            else str.Append(" ");
        }
        private void PreTraverse_Counter(TreeNode node, ref StringBuilder str)
        {
            if (node != null)
            {
                str.Append(node.val);
                PreTraverse_Counter(node.right, ref str);
                PreTraverse_Counter(node.left, ref str);
            }
            else str.Append(" ");
        }

        //Solution from others,太巧妙了，为什么我想不出这种方案，我肯定注意定了a.left, b.right;a.right,b.left的对称性。可惜没有想到两个入参，一直被一个root参数给限制误导了。
        //这个方案给我的启发是：当二叉树需要左右的节点比较时，可以从root劈成两棵树。
        public bool IsSymmetric_V2(TreeNode root)
        {
            return IsMirror(root, root);
        }

        public bool IsMirror(TreeNode a, TreeNode b)
        {
            return a == null || b == null ? a == b : a.val == b.val && IsMirror(a.left, b.right) && IsMirror(a.right, b.left);
        }

        public TreeNode GetMirrorTree(TreeNode root)
        {
            TreeNode newTree = null;
            if (root != null)
            {
                newTree = new TreeNode(root.val);

                newTree.left = GetMirrorTree(root.right);
                newTree.right = GetMirrorTree(root.left);
            }

            return newTree;
        }

        //二叉树的中序遍历
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            if (root != null)
            {
                Inorder(root, ref list);
            }

            return list;
        }
        private void Inorder(TreeNode root, ref List<int> list)
        {
            if (root != null)
            {
                Inorder(root.left, ref list);
                list.Add(root.val);
                Inorder(root.right, ref list);
            }
        }
    }
}
