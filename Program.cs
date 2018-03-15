using System;
using System.Collections;
using System.Collections.Generic;

namespace PrintTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[15];

            //for (int i = 0; i < 15; i++)
            //{
            //    arr[i] = i;
            //}

            //var root = BuildTree(arr);
            //// PrintTree(root);
            //RecursivePrint(root);
            //Console.ReadLine();
            MyPriorityQueue mpq = new MyPriorityQueue();

            Random r = new Random();


            for (int i = 0; i < 10; i++)
            {
                mpq.Add(r.Next(10));
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(mpq.Remove().Value);
            }
            Console.ReadLine();
        }

        public static void PrintTree( Node root)
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);

            int level = 0;

            while (true)
            {
                int counter = 0;

                for (int i = 0; i < Math.Pow(2, level); i++)
                {
                    var el = queue.Dequeue();
                    if (el == null)
                    {
                        Console.Write("null ");
                        queue.Enqueue(null);
                        queue.Enqueue(null);
                    }
                    else
                    {
                        counter++;
                        Console.Write(el.Data  +" ");
                        queue.Enqueue(el.Left);
                        queue.Enqueue(el.Right);
                    }                   
                }
                Console.WriteLine();
                level++;
                if (counter == 0)
                {
                    break;
                }
            }

        }
        public static Node BuildTree(int[] arr)
        {
            if (arr.Length <= 0)
            {
                return null;
            }
            Queue<Node> queue = new Queue<Node>();

            Node root = new Node() { Data = arr[0] };
            queue.Enqueue(root);
            int level = 0;
            int index = 1;

            while (index < arr.Length)
            {
                for (int i = 0; i < Math.Pow(2, level); i++)
                {
                    var el = queue.Dequeue();
                    if (index < arr.Length)
                    {
                        el.Left = new Node() { Data = arr[index] };
                    }
                    else
                    {
                        el.Left = null;
                    }
                    
                    queue.Enqueue(el.Left);

                    index++;
                    if (index < arr.Length)
                    {
                        el.Right = new Node() { Data = arr[index] };
                    }
                    else
                    {
                        el.Right = null;
                    }
                    queue.Enqueue(el.Right);
                    index++;
                }
                level++;
            }
            return root;
        }
        public static void RecursivePrint(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Data);
                RecursivePrint(root.Left);
                RecursivePrint(root.Right);
            }
        }
    }
}
