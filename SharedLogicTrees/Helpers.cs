﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedLogicTrees
{
    public static class Helpers
    {
		public static void PrintTree(BinaryTree root)
		{
			var q = new Queue<(BinaryTree node, int depth)>();
			q.Enqueue((root, 0));
			List<Tuple<int, int>> nodesValueDepth = new List<Tuple<int, int>>();

			while (q.Count > 0)
			{
				var currentNode = q.Dequeue();
				var currentDepth = currentNode.depth + 1;
				nodesValueDepth.Add( Tuple.Create(currentNode.node.value, currentNode.depth));
				if (currentNode.node.left != null)
				{
					q.Enqueue((currentNode.node.left, currentDepth));
				}
				if (currentNode.node.right != null)
				{
					q.Enqueue((currentNode.node.right, currentDepth));
				}
			}

			var maxDepth = nodesValueDepth.Select(a=>a.Item2).Max();
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
