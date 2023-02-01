using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class BST
    {

        //Root of BST
        public Node root;

        //Cosntructor
        public BST() { root = null; }
        public BST(int value) { root = new Node(value); }

        // This method mainly calls insertRec()
        public void Insert(int key) { root = InsertRecu(root, key); }

        // This method mainly calls InorderRec()
        public void Traverse() { InorderRecu(root); }

        //recursive funtion to insert a new key in BST
        Node InsertRecu(Node root, int key)
        {

            //Console.WriteLine(key);
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

        // utility function doing inorder traversal of BST
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

    }
}
