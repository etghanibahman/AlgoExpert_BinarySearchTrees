using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidateBst
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Case__1
            
            BST tree1 = new BST(10);
            BST tree2 = new BST(5);
            BST tree3 = new BST(15);
            BST tree4 = new BST(2);
            BST tree5 = new BST(5);
            BST tree6 = new BST(13);
            BST tree7 = new BST(22);
            BST tree8 = new BST(1);
            BST tree9 = new BST(14);

            tree1.left = tree2;
            tree1.right = tree3;
            tree2.left = tree4;
            tree2.right = tree5;
            tree3.left = tree6;
            tree3.right = tree7;
            tree4.left = tree8;
            tree6.right = tree9;

            #endregion

            PrintTree(tree1);
            Console.WriteLine($"\nIs this tree a validate BST? {ValidateBst(tree1)} "); 
        }

        #region Algo__Solution
        public static bool ValidateBst(BST tree)
        {
            int minValue = Int32.MinValue;
            int maxValue = Int32.MaxValue;
            return IsValidBST(tree,minValue,maxValue);
        }

        public static bool IsValidBST(BST tree,int minValue,int maxValue)
        {
            if (tree == null)
                return true;
            if (tree.value < minValue || tree.value >= maxValue)
                return false;
            return IsValidBST(tree.left, minValue,tree.value) 
                    && IsValidBST(tree.right, tree.value,maxValue);
        }
        #endregion



        #region My_Solution
        //public static bool ValidateBst(BST tree)
        //{
        //    Queue<BST> queue = new Queue<BST>();
        //    queue.Enqueue(tree);

        //    while (queue.Count > 0)
        //    {
        //        var currentNode = queue.Dequeue();
        //        if (currentNode == null)
        //            continue;
        //        var leftNode = currentNode.left;
        //        var rightNode = currentNode.right;

        //        var rootValue = currentNode.value;


        //        Queue<BST> rightQueue = new Queue<BST>();
        //        rightQueue.Enqueue(rightNode);
        //        while (rightQueue.Count > 0)
        //        {
        //            var currentNodeRight = rightQueue.Dequeue();
        //            if (currentNodeRight == null)
        //                continue;
        //            if (rootValue > currentNodeRight.value)
        //                return false;
        //            if (currentNodeRight.left != null)
        //            {
        //                rightQueue.Enqueue(currentNodeRight.left);
        //            }
        //            if (currentNodeRight.right != null)
        //            {
        //                rightQueue.Enqueue(currentNodeRight.right);
        //            }
        //        }

        //        Queue<BST> leftQueue = new Queue<BST>();
        //        leftQueue.Enqueue(leftNode);
        //        while (leftQueue.Count > 0)
        //        {
        //            var currentNodeLeft = leftQueue.Dequeue();
        //            if (currentNodeLeft == null)
        //                continue;
        //            if (rootValue <= currentNodeLeft.value)
        //                return false;
        //            if (currentNodeLeft.left != null)
        //            {
        //                leftQueue.Enqueue((currentNodeLeft.left));
        //            }
        //            if (currentNodeLeft.right != null)
        //            {
        //                leftQueue.Enqueue((currentNodeLeft.right));
        //            }
        //        }

        //        queue.Enqueue(currentNode.right);
        //        queue.Enqueue(currentNode.left);

        //    }

        //    return true;
        //}
        #endregion



        public static void PrintTree(BST root)
        {
            var q = new Queue<(BST node, int depth)>();
            q.Enqueue((root, 0));
            List<Tuple<int, int>> nodesValueDepth = new List<Tuple<int, int>>();

            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();
                var currentDepth = currentNode.depth + 1;
                nodesValueDepth.Add(Tuple.Create(currentNode.node.value, currentNode.depth));
                if (currentNode.node.left != null)
                {
                    q.Enqueue((currentNode.node.left, currentDepth));
                }
                if (currentNode.node.right != null)
                {
                    q.Enqueue((currentNode.node.right, currentDepth));
                }
            }

            var maxDepth = nodesValueDepth.Select(a => a.Item2).Max();
            for (int i = 0; i <= maxDepth; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine("|");
                }
                Console.WriteLine(string.Join('-', nodesValueDepth.Where(a => a.Item2 == i).Select(a => a.Item1).ToList()));
            }
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }
    }
}
