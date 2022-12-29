using SharedLogicTrees;
using System;
using System.Collections.Generic;

namespace FindClosestValueBst
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinaryTree tree1 = new BinaryTree(10);
            //BinaryTree tree2 = new BinaryTree(5);
            //BinaryTree tree3 = new BinaryTree(15);
            //BinaryTree tree4 = new BinaryTree(2);
            //BinaryTree tree5 = new BinaryTree(5);
            //BinaryTree tree6 = new BinaryTree(13);
            //BinaryTree tree7 = new BinaryTree(22);

            //tree1.left = tree2;
            //tree1.right = tree3;
            //tree2.left = tree4;
            //tree2.right = tree5;
            //tree3.left = tree6;
            //tree3.right = tree7;

            BinaryTree tree1 = new BinaryTree(10);
            BinaryTree tree2 = new BinaryTree(-5);
            BinaryTree tree3 = new BinaryTree(15);
            BinaryTree tree4 = new BinaryTree(-2);
            BinaryTree tree5 = new BinaryTree(-5);
            BinaryTree tree6 = new BinaryTree(13);
            BinaryTree tree7 = new BinaryTree(22);

            tree1.left = tree2;
            tree1.right = tree3;
            tree2.left = tree4;
            tree2.right = tree5;
            tree3.left = tree6;
            tree3.right = tree7;

            Helpers.PrintTree(tree1);

            int target = -6;

            Console.WriteLine($"The closest valut to target : {target} is : { FindClosestValueInBst(tree1,target) }");
        }


        #region MySolution
        //public static int FindClosestValueInBst(BinaryTree tree, int target)
        //{
        //    Queue<BinaryTree> q = new Queue<BinaryTree>();
        //    q.Enqueue((tree));
        //    (int difference, int value) valueAndDifference = (Math.Abs(Math.Abs(target) - Math.Abs(tree.value)), tree.value);
        //    while (q.Count > 0)
        //    {
        //        var currentNode = q.Dequeue();
        //        int differenceAbs = Math.Abs(Math.Abs(target) - Math.Abs(currentNode.value));
        //        if (valueAndDifference.difference >= differenceAbs)
        //        {
        //            valueAndDifference.difference = Math.Abs(Math.Abs(target) - Math.Abs(currentNode.value));
        //            valueAndDifference.value = currentNode.value;
        //        }
        //        if (currentNode.left != null && target < currentNode.value)
        //        {
        //            q.Enqueue((currentNode.left));
        //        }
        //        if (currentNode.right != null && target >= currentNode.value)
        //        {
        //            q.Enqueue((currentNode.right));
        //        }
        //    }

        //    return valueAndDifference.value;
        //}
        #endregion

        public static int FindClosestValueInBst(BinaryTree tree, int target)
        {
            int minNode = tree.value;
            var curNode = tree;
            while (curNode != null)
            {
                if (Math.Abs(target - minNode) > Math.Abs(target - curNode.value))
                    minNode = curNode.value;

                if (target> curNode.value)
                    curNode = curNode.right;
                else if (target < curNode.value)
                    curNode = curNode.left;
                else
                    break;
            }
            return minNode;
        }

    }
}
