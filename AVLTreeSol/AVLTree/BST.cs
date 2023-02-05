using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AVLTree
{
    public class BST
    {

        //Root of BST
        public Node root;

        //Cosntructor
        public BST() { root = null; }
        public BST(int value) { root = new Node(value); }

        // This method mainly calls InsertRec()
        public void Insert(int key) { root = InsertRecu(root, key); }

        // This method mainly calls SearchKey()
        public void Query(int key) { root = SearchKey(root, key); }

        // This method mainly calls InorderRec()
        public void Traverse() { InorderRecu(root); }

        /*// A utility function to right
        // rotate subtree rooted with y
        // See the diagram given above.
        Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation
            x.right = y;
            y.left = T2;

            // Update heights
            y.height = max(height(y.left),
                        height(y.right)) + 1;
            x.height = max(height(x.left),
                        height(x.right)) + 1;

            // Return new root
            return x;
        }

        // A utility function to left
        // rotate subtree rooted with x
        // See the diagram given above.
        Node leftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation
            y.left = x;
            x.right = T2;

            // Update heights
            x.height = max(height(x.left),
                        height(x.right)) + 1;
            y.height = max(height(y.left),
                        height(y.right)) + 1;

            // Return new root
            return y;
        }
        */

        //recursive funtion to insert a new key in BST
        Node InsertRecu(Node root, int key)
        {

            //1. Perform the normal BST insertion
            //if tree is empty return a new node
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            //else recur down the tree
            //if key is smaller then the root key move to the left subtree
            if (key < root.key)
            {
                root.left = InsertRecu(root.left, key);
            }
            else if (key > root.key)  //if its greater move to right subtree
            {
                root.right = InsertRecu(root.right, key);
            }


            //2. Update height of this ancestor node
            root.height = 1 + max(height(root.left), height(root.right));


            //3.  Get this ancestor node's balance factor to see whether it got imbalanced
            int balance = getBalance(root);


            /*// If this node becomes unbalanced, then there
            // are 4 cases Left Left Case
            if (balance > 1 && key < node.left.key)
                return rightRotate(node);

            // Right Right Case
            if (balance < -1 && key > node.right.key)
                return leftRotate(node);

            // Left Right Case
            if (balance > 1 && key > node.left.key)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && key < node.right.key)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }*/

            //Return the "unchancged" node pointer
            return root;
        }

        //function to search a given key in BST
        Node SearchKey(Node root, int key)
        {
            //Base Case: root is null or key is present at root
            if (root == null || root.key == key)
            {
                return root;
            }

            //if Key is greater than root's key continue in right subtree
            if (root.key < key)
            {
                return SearchKey(root.right, key);
            }

            //if Key is smaller than root's key continue on left subtree
            return SearchKey(root.left, key);

        }

        //utility function doing inorder traversal of BST
        void InorderRecu(Node root)
        {

            //Console.WriteLine(root);
            if (root != null)
            {
                InorderRecu(root.left);
                Console.Write(root.key + " ");
                InorderRecu(root.right);
            }
        }

        //utility function get maximum of two integers
        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //utility function to get the height of the tree
        int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return root.height;
        }

        // Get Balance factor of node N
        int getBalance(Node root)
        {
            if (root == null)
            {
                return 0;

            }

            return height(root.left) - height(root.right);
        }
    }
}
