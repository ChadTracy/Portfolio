//Chad Tracy
//CIS 200
//Program 5 - EC 1
//Due: 4/22/2016


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QueueInheritanceLibrary;

namespace BinaryTreeLibrary
{
    public class Tree // class for the actual tree
    {
        


        private TreeTestNodes root; //tree node var for a  tree node


        public Tree() //constructor for tree
        {
            root = null;
        }

        public void insertTree(int inval)
        {
            if (root == null) // check if tree has no values in it
            {
                root = new TreeTestNodes(inval);
            }
            else // traverse tree to find correct place 
            {
                root.intoTree(inval);
            }
        }

        public void PreOrder() //method for finding pre order tree traversal. uses helper method
        {
            PreOrderHelper(root);
        }
        public void PreOrderHelper(TreeTestNodes node)//helper method for PreOrder
        {
            if (node != null)
            {
                Console.Write(node.data + " "); //print node
                PreOrderHelper(node.Left); // recursion for left traversal
                PreOrderHelper(node.Right); //recursion for right traversal
            }
        }
        public void OrderedTraversal() //method for finding the traversal of the ordered tree traversal
        {
            OrderedHelper(root);
        }
        public void OrderedHelper(TreeTestNodes node) //helper method for ordered traversal
        {
            if (node != null) //makes sure tree isnt empty
            {
                OrderedHelper(node.Left);//left traversal
                Console.Write(node.data + " "); //print
                OrderedHelper(node.Right);//right traversal                
            }
        }
        public void PostOrder()//method for finding post order traversal
        {
            PostHelper(root);
        }
        public void PostHelper(TreeTestNodes node)//helper method for post order traversal
        {
            if (node != null)
            {
                PostHelper(node.Left); //left traversal
                PostHelper(node.Right); //right traversal
                Console.Write(node.data + " "); //print
            }
        }

        public void LevelOrder()//method for finding the level traversal order
        {
            LevelOrderHelper(root);
        }
        public void LevelOrderHelper(TreeTestNodes t) //helper for finding lvl order
        {
            QueueInheritance lvl1 = new QueueInheritance(); //declare lvl1 for the first level of tree

            QueueInheritance nextlvl = new QueueInheritance(); // declare nextlvl for the 

            lvl1.Enqueue(t);//add to queue

            while (!lvl1.IsEmpty())//while loop for adding as long as lvl1 is not empty
            {
                TreeTestNodes n = (TreeTestNodes)lvl1.Dequeue();

                if (n != null)//nested if to make sure n is not empty. also writes data 
                {
                    Console.Write(n.data + " ");

                    nextlvl.Enqueue(n.Left);
                    nextlvl.Enqueue(n.Right);
                }
                if (lvl1.IsEmpty())// nested if for performing functionality while lvl1 is empty.
                {
                    while (!nextlvl.IsEmpty())
                    {
                        lvl1.Enqueue
                            (nextlvl.Dequeue());
                    }
                }
            }
        }       
     
    }
}
