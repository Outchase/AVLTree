﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AVLTree
{
    public class BST
    {
        //Key can also mean Node like in arrays or assiociate arrays
        //Root of BST
        public Node root;
        public Node searchRoot;

        //Delegates
        public delegate void AVLOrder();
        public delegate void AVLfunc(int key);

        //Cosntructor
        public BST() { root = null; }
        public BST(int value) { root = new Node(value); }

        // This method mainly calls InsertRec()
        public void Insert(int key) { root = InsertRecu(root, key); }
        // This method mainly calls DeleteKey()
        public void Delete(int key) { root = DeleteKey(root, key); }

        // This method mainly calls SearchKey()
        public void Query(int key) { searchRoot = SearchKey(root, key); }

        // This method mainly calls InorderRec()
        public void Traverse() { InorderRecu(root); }

        // A utility function to right rotate subtree rooted with y
        Node RightRotate(Node y)
        {
            //saves to temp variable
            Node x = y.left;
            Node tempRight = x.right;

            // Perform rotation
            x.right = y;
            y.left = tempRight;

            // Update heights
            y.height = Max(Height(y.left),
                        Height(y.right)) + 1;
            x.height = Max(Height(x.left),
                        Height(x.right)) + 1;

            // Return new root
            return x;
        }

        //utility function to left rotate subtree rooted with x
        Node LeftRotate(Node x)
        {
            //saves to temp variable
            Node y = x.right;
            Node tempLeft = y.left;

            // Perform rotation
            y.left = x;
            x.right = tempLeft;

            // Update heights
            x.height = Max(Height(x.left),
                        Height(x.right)) + 1;
            y.height = Max(Height(y.left),
                        Height(y.right)) + 1;

            // Return new root
            return y;
        }

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
            root.height = 1 + Max(Height(root.left), Height(root.right));


            //3.  Get this ancestor node's balance factor to see whether it got imbalanced
            int balance = GetBalance(root);

            // If this node becomes unbalanced, then there are 4 cases:

            // Left Left Case
            if (balance > 1 && key < root.left.key)
            {
                return RightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && key > root.right.key)
            {
                return LeftRotate(root);
            }

            // Left Right Case
            if (balance > 1 && key > root.left.key)
            {
                root.left = LeftRotate(root.left);
                return RightRotate(root);
            }

            // Right Left Case
            if (balance < -1 && key < root.right.key)
            {
                root.right = RightRotate(root.right);
                return LeftRotate(root);
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

        //Non-empty binary search tree, return the node with minimum key found in that tree.

        //Note: The entire tree does not need to be searched
        Node MinValueNode(Node root)
        {
            Node minKey = root;

            //loop to find the leftmost leaf 
            while (minKey.left != null)
            {
                minKey = minKey.left;
            }

            //return the node with minimum key
            return minKey;
        }

        Node DeleteKey(Node root, int key)
        {
            // STEP 1: PERFORM STANDARD BST DELETE
            if (root == null)
            {
                return root;
            }

            //If the deleted key is smaller than the root key, it is located in the left subtree.
            if (key < root.key)
            {
                root.left = DeleteKey(root.left, key);
            }

            //If the removed key is bigger than the root key, it is in the right subtree.
            else if (key > root.key)
            {
                root.right = DeleteKey(root.right, key);
            }

            //If key matches root's key, this node will be deleted.
            else
            {

                //node with only one child or no child
                if ((root.left == null) || (root.right == null))
                {
                    Node temp = null;
                    if (temp == root.left)
                    {
                        temp = root.right;
                    }
                    else
                    {
                        temp = root.left;
                    }

                    // No child case
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }

                    // One child case
                    else
                    {
                        root = temp; // Copy the contents of the non-empty child
                    }
                }
                else
                {
                    //node with two children: Obtain the inorder descendant (smallest in the subtree)
                    Node temp = MinValueNode(root.right);

                    //Copy the data from the inorder descendant to this node
                    root.key = temp.key;

                    //Delete the inorder descendant
                    root.right = DeleteKey(root.right, temp.key);
                }
            }

            //If the tree had only one node then return
            if (root == null)
            {
                return root;
            }

            //2. Update height of this ancestor node
            root.height = 1 + Max(Height(root.left), Height(root.right)) /*+ 1*/;

            //3.  Get this ancestor node's balance factor to see whether it got imbalanced
            int balance = GetBalance(root);

            //If this node becomes unbalanced, then there are 4 cases:

            // Left Left Case
            if (balance > 1 && GetBalance(root.left) >= 0)
            {
                return RightRotate(root);
            }

            // Left Right Case
            if (balance > 1 && GetBalance(root.left) < 0)
            {
                root.left = LeftRotate(root.left);
                return RightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && GetBalance(root.right) <= 0)
            {
                return LeftRotate(root);
            }

            // Right Left Case
            if (balance < -1 && GetBalance(root.right) > 0)
            {
                root.right = RightRotate(root.right);
                return LeftRotate(root);
            }

            return root;
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
        int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //utility function to get the height of the tree
        int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return root.height;
        }

        // Get Balance factor of node ¨root
        int GetBalance(Node root)
        {
            if (root == null)
            {
                return 0;

            }

            return Height(root.left) - Height(root.right);
        }
    }
}
