using System;
using System.Collections.Generic;

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
            // Write your code here.
            return null;
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
