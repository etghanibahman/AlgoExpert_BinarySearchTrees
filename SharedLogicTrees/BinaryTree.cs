using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLogicTrees
{
	public class BinaryTree
	{
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value)
		{
			this.value = value;
			left = null;
			right = null;
		}
	}
}
