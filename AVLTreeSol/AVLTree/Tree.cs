using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    internal class Tree
    {
        public Node insert(Node root, int value)
        {
            //Creates new Node if root is empty and set with the current value
            if (root == null)
            {
                root = new Node();
                root.Value = value;
            }

            //Saves to left node if value is smaller the root value 
            //and/or call recursiv method
            else if (value < root.Value)
            {
                root.Left = insert(root.Left, value);
            }

            //Saves to the right node if value is bigger then the left root value
            //and/or call recursiv method
            else
            {
                root.Right = insert(root.Right, value);
            }

            return root;
        }

        public void Traverse(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Value);

            Traverse(node.Left);
            Traverse(node.Right);

        }

    }
}
