using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _235_LowestCommonAncestorOfBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] treeData = new int[]{6,2,8,0,'*','*',4,3,5,7,9};
            BinaryTreeHelper helper = new BinaryTreeHelper();
            var root = helper.GenerateTree(treeData);
        }
    }
    
    public class Solution
    {
        //there are 3 cases for q, q: 
        //1. p,q belong to left. 2:p,q belongs to righ. 3:p and q , one of them in left, the other in right.
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null) return null;

            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);

            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);

            return root;
        }
    }


}
