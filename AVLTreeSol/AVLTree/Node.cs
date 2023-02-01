using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class Node
    {
        public int key;

        public Node left;
        public Node right;

        //constructor that takes key arguement
        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }
}
