using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTConstruction
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Test Case 1
            //var root = new Program.BST(10);
            //root.left = new Program.BST(5);
            //root.left.left = new Program.BST(2);
            //root.left.left.left = new Program.BST(1);
            //root.left.right = new Program.BST(5);
            //root.right = new Program.BST(15);
            //root.right.left = new Program.BST(13);
            //root.right.left.right = new Program.BST(14);
            //root.right.right = new Program.BST(22);

            //PrintTree(root);

            //int valueToSearch = 10;
            //Console.WriteLine($"does this tree has {valueToSearch} ? {root.Contains(valueToSearch)}");
            //Console.WriteLine("\n ******************** \n");


            //root.Insert(12);
            //PrintTree(root);
            //Console.WriteLine("\n *******after adding 12************* \n");


            //root.Remove(10);
            //PrintTree(root);
            //Console.WriteLine("\n ******* after removing 10 ************* \n");


            //valueToSearch = 15;
            //Console.WriteLine($"does this tree has {valueToSearch} ? {root.Contains(valueToSearch)}");

            #endregion

            #region Test Case 5

            BST rootNode = new BST(10);
            rootNode.Insert(5);
            rootNode.Insert(15);

            int valueToSearch = 10;
            Console.WriteLine($"does this tree has {valueToSearch} ? {rootNode.Contains(valueToSearch)}");

            valueToSearch = 5;
            Console.WriteLine($"does this tree has {valueToSearch} ? {rootNode.Contains(valueToSearch)}");

            PrintTree(rootNode);

            Console.WriteLine("\n ******************** \n");
            
            rootNode.Remove(10);
            PrintTree(rootNode);
            Console.WriteLine("\n ********* end 10 *********** \n");
            
            rootNode.Remove(5);
            PrintTree(rootNode);
            Console.WriteLine("\n ********* end 5 *********** \n");

            rootNode.Remove(15);
            PrintTree(rootNode);
            Console.WriteLine("\n ********* end 15 *********** \n");

            valueToSearch = 10;
            Console.WriteLine($"does this tree has {valueToSearch} ? {rootNode.Contains(valueToSearch)}");

            valueToSearch = 5;
            Console.WriteLine($"does this tree has {valueToSearch} ? {rootNode.Contains(valueToSearch)}");

            valueToSearch = 15;
            Console.WriteLine($"does this tree has {valueToSearch} ? {rootNode.Contains(valueToSearch)}");

            #endregion

            #region Test Case 10

            //BST rootNode = new BST(10);
            //rootNode.Insert(5);
            //rootNode.Insert(15);
            //rootNode.Insert(2);
            //rootNode.Insert(5);
            //rootNode.Insert(13);
            //rootNode.Insert(22);
            //rootNode.Insert(1);
            //rootNode.Insert(14);
            //rootNode.Insert(12);
            //PrintTree(rootNode);

            //Console.WriteLine("\n ******************** \n");
            //rootNode.Remove(5);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ********* end first 5 *********** \n");

            //rootNode.Remove(5);
            //PrintTree(rootNode);

            //Console.WriteLine("\n ********* end second 5 *********** \n");

            //rootNode.Remove(12);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ******** end 12 ************ \n");

            //rootNode.Remove(13);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ********* end 13 *********** \n");

            //rootNode.Remove(14);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ********* end 14 *********** \n");

            //rootNode.Remove(22);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ********* end 22 *********** \n");

            //rootNode.Remove(2);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ********* end 2 *********** \n");

            //rootNode.Remove(1);
            //PrintTree(rootNode);
            //Console.WriteLine("\n ********** end 1 ********** \n");

            //int valueToSearch = 15;
            //Console.WriteLine($"does this tree has {valueToSearch} ? {rootNode.Contains(valueToSearch)}");


            #endregion
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

            public BST Insert(int value)
            {
                #region RecursiveVersion
                //if (this.value <= value)
                //{
                //    if (this.right == null)
                //    {
                //        this.right = new BST(value);
                //    }
                //    else
                //    {
                //        this.right.Insert(value);
                //    }
                //}
                //else if (this.value > value)
                //{
                //    if (this.left == null)
                //    {
                //        this.left = new BST(value);
                //    }
                //    else
                //    {
                //        this.left.Insert(value);
                //    }
                //}
                //return this;
                #endregion

                BST currentNode = this;
                while (currentNode != null)
                {
                    if (currentNode.value <= value)
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = new BST(value);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }
                    else if (currentNode.value > value)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = new BST(value);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                        }
                    }
                }
                return this;
            }

            public bool Contains(int value)
            {
                #region RecursiveVersion
                //if (this.value == value)
                //{
                //    return true;
                //}
                //else if (this.value > value)
                //{
                //    return this.left?.Contains(value) ?? false;
                //}
                //else if (this.value <= value)
                //{
                //    return this.right?.Contains(value) ?? false;
                //}
                //else
                //{
                //    return false;
                //}
                #endregion
                BST currentNode = this;
                while (currentNode != null)
                {
                    if (currentNode.value == value)
                    {
                        return true;
                    }
                    else if (currentNode.value > value)
                    {
                        currentNode = currentNode.left;
                    }
                    else if (currentNode.value <= value)
                    {
                        currentNode = currentNode.right;
                    }
                }
                return false;
            }

            public BST Remove(int value)
            {
                BST currentNode = this;
                BST parentNode = this;
                while (currentNode != null)
                {
                    if (currentNode.value == value)
                    {
                        if (currentNode.left == null && currentNode.right == null)
                        {
                            if (parentNode.left?.value == currentNode.value)
                            {
                                parentNode.left = null;
                            }
                            else if (parentNode.right?.value == currentNode.value)
                            {
                                parentNode.right = null;
                            }
                        }
                        else if (currentNode.right?.value == value)
                        {
                            while (currentNode.right != null)
                            {
                                parentNode = currentNode;
                                currentNode = currentNode.right;
                            }
                            continue;
                        }
                        else if (currentNode.right == null)
                        {
                            BST replaceNode = currentNode.left;
                            while (replaceNode.right != null)
                            {
                                parentNode = replaceNode;
                                replaceNode = replaceNode.right;
                            }
                            currentNode.value = replaceNode.value;
                            if (currentNode.left == replaceNode)
                            {
                                currentNode.left = replaceNode.left;
                            }
                            else
                            {
                                currentNode.right = null;
                            }
                        }
                        else
                        {
                            BST replaceNode = currentNode.right;
                            while (replaceNode.left != null)
                            {
                                parentNode = replaceNode;
                                replaceNode = replaceNode.left;
                            }
                            currentNode.value = replaceNode.value;
                            if (currentNode.right == replaceNode)
                            {
                                currentNode.right = replaceNode.right;
                            }
                            else
                            {
                                parentNode.left = null;
                            }

                        }

                        break;
                    }
                    if (currentNode.value < value)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.right;
                    }
                    else if (currentNode.value > value)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.left;
                    }
                }

                return this;
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
