using System;
using System.Diagnostics;

namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            //Node root = null;
            //BTS tree = new BTS();


            Random random = new Random();

            Console.Write("Enter the number of nodes to be insert: ");

            int size = 10;

            int[] numbers = new int[size];

            Stopwatch timer = new Stopwatch();

            Console.WriteLine("The array will be filled with data.");

            //start timer
            timer.Start();
            //gererate random numbers (max range 5000)and insert to array
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(100);
            }
            //stop timer
            timer.Stop();

            Console.WriteLine("It took " + timer.ElapsedMilliseconds + " milliseconds.");

            //restart timer
            Console.WriteLine("The tree will be filled with data.");
            timer = Stopwatch.StartNew();

            //tree.Insert(10);

            //loading data into tree
            for (int i = 0; i < numbers.Length; i++)
            {
                tree.Insert(numbers[i]);
            }

            //stop new timer
            timer.Stop();
            Console.WriteLine("It took " + timer.ElapsedMilliseconds + " milliseconds.");

            //Console.WriteLine(numbers[0]);
            tree.Traverse();

            //just testing purpose
            int test = 1;
            while (tree.root == null)
            {
                tree.Search(test);
                test++;

            }

            Console.WriteLine("\n" + tree.root.key);
            tree.Insert(50);
            tree.Traverse();

        }
    }
}
