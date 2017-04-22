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
    public class TreeTestNodes
    {
        public TreeTestNodes Left //property for holding the left node
        {
            get;
            set;
        }
        public TreeTestNodes Right //property for holding the right node
        {
            get;
            set;
        }
        public int data //property for the data given
        {
            get;
            set;
        }
        
        public TreeTestNodes(int node)// constructor for get data and make a node
        {
            data = node;
        }
        
        public void intoTree (int inval)//method for inserting data into nodes of tree
        {
            if (inval < data)//for inserting into left side of tree. checks to see if value is less than the current value for the node
            {
                if (Left == null)
                {
                    Left = new TreeTestNodes(inval);
                }
                else
                {
                    Left.intoTree(inval); //recursive way of finding node location
                }

                
            }
           if (inval > data) //for inserting into right side of tree. does the same functions as left side, but for right tree insertion
            {
                if (Right == null)
                {
                    Right = new TreeTestNodes(inval);
                }
                else
                {
                    Right.intoTree(inval);
                }
            }
        }

    }
}
