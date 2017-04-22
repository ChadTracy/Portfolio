//Chad Tracy
//CIS 200
//Program 5 Part 2
//Due: 4/22/2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    class TreeNode<T> where T : IComparable
    {
        public T Left //left tree node proprty
        {
            get;
            set;
        }
        public T Right //right tree node property
        {
            get;
            set;
        }
        public T data// data property
        {
            get;
            set;
        }


        public TreeNode(T node)
        {
            data = node;
            Left = Right = default(T);
        }
        public void Insert(T inval)
        {
            int val = inval.CompareTo(data);

            if (val == -1)
            {
                if (Left == null)
                {
                    Left = new TreeNode(inval);

                }
                else
                {
                    Left.Insert(inval);
                }

            }
            else if (val == 1)
            {
                if (Right == null)
                {
                    Right = new(T) (inval);
                }
                else
                {
                    Right.Insert(inval);
                }
            }
        }
    }
    public class Tree<R> where R : IComparable
    {
        private R root;//for holding tree nodes

        public void TreeNode()//empty tree constructor
        {
            root = default(R);
        }

        public void InsertNode(R inval)
        {
            if (root == null)//checks if root is empty
            {
                root = new (R inval);
            }
            else
            {
                root.Insert(inval);
            }
        }
        public void PreOrderTraversal()
        {
            PreOrderHelper(root);
        }
        private void PreOrderHelper(R node) //helper for preorder
        {
            if (node != null) //checks for empty values
            {
                Console.Write(node.data + " "); //writes data
                PreOrderHelper(node.Left);
                PreOrderHelper(node.Right);
            }
        }

        public void InOrderTraversal()
        {
            InOrderHelper(root);
        }
        private void InOrderHelper(R node)
        {
            if (node != null)
            {
                InOrderHelper(node.Left);
                Console.Write(node.data + " ");
                InOrderHelper(node.Right);
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderHelper(root);
        }
        private void PostOrderHelper(R node)
        {
            if (node != null)
            {
                PostOrderHelper(node.Left);
                PostOrderHelper(node.Right);
                Console.Write(node.data + " ");
            }
        }
    }
}
