using System;
using System.Diagnostics;
using static AVLTree.BST;

namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            Random random = new Random();

            Console.Write("Enter the number of nodes to be insert: ");

            int size = 10;
            int testKey = 50;

            int[] numbers = new int[size];

            AVLOrder order = new AVLOrder(tree.Traverse);
            AVLfunc insert = new AVLfunc(tree.Insert);
            AVLfunc search = new AVLfunc(tree.Query);
            AVLfunc delete = new AVLfunc(tree.Delete);

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
                insert(numbers[i]);
                //tree.Insert(numbers[i]);
            }

            //stop new timer
            timer.Stop();
            Console.WriteLine("It took " + timer.ElapsedMilliseconds + " milliseconds.\n");

            /*Console.WriteLine("Before delete "+testKey);
            //tree.Insert(50);
            insert(50);
            order();*/


            Console.WriteLine("Query " + testKey);
            //insert(50);
            search(testKey);
            //tree.Query(testKey);
            order();

            if (tree.searchRoot == null)
            {
                Console.WriteLine("\n\nQuery not found ");
            }
            else
            {
                Console.WriteLine("\n\nQuery found " + tree.searchRoot.key);
            }

            /*Console.WriteLine("\n\nAfter delete " + testKey);
            delete(testKey);
            //tree.Delete(testKey);
            order();*/

        }
    }
}
