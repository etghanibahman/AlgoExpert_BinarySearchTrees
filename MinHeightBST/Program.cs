using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace MinHeightBST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>() { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
            Console.WriteLine($"The root of constructed BST is {MinHeightBst(array)?.value}");
        }

        public static BST MinHeightBst(List<int> array)
        {
            return CreateNode(array, 0, array.Count - 1);
        }

        private static BST CreateNode(List<int> array, int i, int j)
        {
            if (i > j)
                return null;
            var average = (i + j) / 2;
            var node = new BST(array[average]);
            node.left = CreateNode(array, i, average - 1);
            node.right = CreateNode(array, average + 1, j);
            Console.WriteLine($"\nNode value is {node.value}");
            return node;
        }
        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }

            public void insert(int value)
            {
                if (value < this.value)
                {
                    if (left == null)
                    {
                        left = new BST(value);
                    }
                    else
                    {
                        left.insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new BST(value);
                    }
                    else
                    {
                        right.insert(value);
                    }
                }
            }
        }
    }
}
