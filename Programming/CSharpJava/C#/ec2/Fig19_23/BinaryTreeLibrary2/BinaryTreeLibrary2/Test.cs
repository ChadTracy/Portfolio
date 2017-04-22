//Chad Tracy
//CIS 200
//Program 5 Part 2
//Due: 4/22/2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeLibrary2
{
    class Test
    {
        static void Main(string[] args)
        {
            Random num = new Random(); //random numbers

            Tree tree = new Tree(); // new tree 

            int insertvalue; //int for value to be inserted

            Console.WriteLine("inserting these values: ");
            for (int i = 1; i<= 10; i++) //display values to be inserted. uses random numbers
            {
                insertvalue = num.Next(100);
                Console.WriteLine(insertvalue + "");
                tree.InsertNode(insertvalue);
            }

            Console.WriteLine("Display PreOrder Traversal of Tree: ");// displays pre order
            tree.PreorderTraversal();

            Console.WriteLine("Display PostOrder Traversal: ");// display post order
            tree.PostorderTraversal();

            Console.WriteLine("Display In Order Traversal: ");// displays in order
            tree.InorderTraversal();

            Tree floatVals = new Tree(); //variable for floating values that are to be sorted
            float invalFloat;

            Console.WriteLine("Floating vales");
            for (float i=81; i < 90; i++)// display for floating values
            {
                invalFloat = (float)i;
                Console.Write(invalFloat);
                floatVals.InsertNode(invalFloat);
            }
            Console.WriteLine("PreOrder Traversal: ");
            floatVals.PreorderTraversal();
            Console.WriteLine("PostOrder Traversal: ");
            floatVals.PostorderTraversal();
            Console.WriteLine("In Order Traversal: ");
            floatVals.InorderTraversal();

            Tree strings = new Tree(); //tree for strings
            string invalString;

            Console.WriteLine("Insert string values: "); //string vals
            for (int i = 1; i <= 10; i++)
            {
                invalString = i.ToString();
                Console.Write(invalString + "");
                strings.InsertNode(invalString);
            }
            Console.WriteLine("PreOrder Traversal: "); //pre order display
            strings.PreorderTraversal();
            Console.WriteLine("PostOrder Traversal: "); //post oreder display
            strings.PostorderTraversal();
            Console.WriteLine("In Order Traversal: "); // in order display
            strings.InorderTraversal();
            Console.ReadKey();

            
        }//end main
    }
}
