using System;
using System.Collections.Generic;
using System.Linq;

namespace BST_Traversal
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
			BST tree7 = new BST(22);
			BST tree8 = new BST(1);

			tree1.left = tree2;
			tree1.right = tree3;

			tree2.left = tree4;
			tree2.right = tree5;

			tree3.right = tree7;

			tree4.left = tree8;

			#endregion

			PrintTree(tree1);

			Console.WriteLine($"\nIn Order Traverse {String.Join(',',InOrderTraverse(tree1,new List<int>()))}");
            Console.WriteLine($"\nPre Order Traverse {String.Join(',', PreOrderTraverse(tree1, new List<int>()))}");
            Console.WriteLine($"\nPost Order Traverse {String.Join(',', PostOrderTraverse(tree1, new List<int>()))}");
        }
		public static int counter = 0;
		public static Stack<int> treeValuesStack = new Stack<int>();
		public static List<int> InOrderTraverse(BST tree, List<int> array)
		{
			counter++;
			Console.WriteLine($"Rec No{counter}: tree's value: {tree?.value} , array: {String.Join(',',array)}, , treeValuesStack: {String.Join(',',  treeValuesStack.ToArray())}");
			
			if (tree == null)
            {
				//return array;
				return null;
			}
			treeValuesStack.Push(tree.value);

			InOrderTraverse(tree.left, array);
			array.Add(tree.value);
			treeValuesStack.Pop();
			InOrderTraverse(tree.right, array);
			return array;
		}

		public static List<int> PreOrderTraverse(BST tree, List<int> array)
		{
			if (tree == null)
			{
				return array;
			}
			array.Add(tree.value);
			PreOrderTraverse(tree.left, array);
			PreOrderTraverse(tree.right, array);
			return array;
		}

		public static List<int> PostOrderTraverse(BST tree, List<int> array)
		{
			if (tree == null)
			{
				return array;
			}
			PostOrderTraverse(tree.left, array);
			PostOrderTraverse(tree.right, array);
			array.Add(tree.value);
			return array;
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
