using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace FindKthLargestValueInBst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Case__1

            BST tree1 = new BST(15);
            BST tree2 = new BST(5);
            BST tree3 = new BST(20);
            BST tree4 = new BST(2);
            BST tree5 = new BST(5);
            BST tree6 = new BST(17);
            BST tree7 = new BST(22);
            BST tree8 = new BST(1);
            BST tree9 = new BST(3);

            tree1.left = tree2;
            tree1.right = tree3;
            tree2.left = tree4;
            tree2.right = tree5;
            tree3.left = tree6;
            tree3.right = tree7;
            tree4.left = tree8;
            tree4.right = tree9;
            PrintTree(tree1);
            int k = 3;

            #endregion

            Console.WriteLine($"{k}th largest number is : {FindKthLargestValueInBst(tree1, k)}");
        }

        #region Algo_Solution_____O(n)_Time_____O(n)_Space
        static (int value, int numberOfNodesVisited) nodeData;
        public static int FindKthLargestValueInBst(BST tree, int k)
        {
            nodeData = (-1, 0);

            TraverseTree(tree, k);

            return nodeData.value;
        }

        public static void TraverseTree(BST tree, int k)
        {
            if (tree == null || nodeData.numberOfNodesVisited >= k)
                return;
            if (tree.right != null)
                TraverseTree(tree.right, k);
            if (nodeData.numberOfNodesVisited < k )
            {
                nodeData.numberOfNodesVisited += 1;
                nodeData.value = tree.value;
            }
            if (tree.left != null)
                TraverseTree(tree.left, k);
        }
        #endregion

        #region My_Solution_____O(n)_Time_____O(n)_Space
        //public static int FindKthLargestValueInBst(BST tree, int k)
        //{
        //    List<int> values = new List<int>();
        //    TraverseTree(tree, values);

        //    return values.ElementAt(values.Count - k);
        //}

        //public static void TraverseTree(BST tree, List<int> values)
        //{
        //    if (tree.left != null)
        //        TraverseTree(tree.left, values);
        //    values.Add(tree.value);
        //    if (tree.right != null)
        //        TraverseTree(tree.right, values);
        //}
        #endregion

        public class BST
        {
            public int value;
            public BST left = null;
            public BST right = null;

            public BST(int value)
            {
                this.value = value;
            }
        }

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
    }
}
