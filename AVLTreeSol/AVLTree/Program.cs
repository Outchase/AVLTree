using System;
using System.Diagnostics;

namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree tree = new Tree();
            Random random = new Random();
            int size = 10;
            int[] numbers = new int[size];

            Stopwatch timer = new Stopwatch();

            Console.WriteLine("The array will be filled with data.");

            //start timer
            timer.Start();
            //gererate random numbers (max range 5000)and insert to array
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(2000);
            }
            //stop timer
            timer.Stop();

            Console.WriteLine("It took " + timer.ElapsedMilliseconds + " milliseconds.");

            //restart timer
            Console.WriteLine("The tree will be filled with data.");
            timer = Stopwatch.StartNew();

            //loading data into tree
            for (int i = 0; i < numbers.Length; i++)
            {
               root=  tree.insert(root, numbers[i]);
            }

            //stop new timer
            timer.Stop();
            Console.WriteLine("It took " + timer.ElapsedMilliseconds + " milliseconds.");

            //Console.WriteLine(numbers[0]);
            tree.Traverse(root);

        }
    }
}
