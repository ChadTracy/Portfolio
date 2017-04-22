// Program 1B
// CIS 200-01
// Due: 2/24/2016
// Chad Tracy

// File: Program.cs
// This file creates a small application that tests the LibraryItem hierarchy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryItems;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryItem hierarchy has been tested using LINQ, demonstrating polymorphism
    public static void Main(string[] args)
    {
        const int DAYSLATE = 20; // Number of days late to test each object's CalcLateFee method

        List<LibraryItem> items = new List<LibraryItem>();       // List of library items
        List<LibraryPatron> patrons = new List<LibraryPatron>(); // List of patrons

        int p; // Patron index

        // Test data - Magic numbers allowed here
        items.Add(new LibraryBook("The Wright Guide to C#", "UofL Press", 2010, 14,
            "ZZ25 3G", "Andrew Wright"));
        items.Add(new LibraryBook("Harriet Pooter", "Stealer Books", 2000, 21,
            "AB73 ZF", "IP Thief"));
        items.Add(new LibraryMovie("Andrew's Super-Duper Movie", "UofL Movies", 2011, 7,
            "MM33 2D", 92.5, "Andrew L. Wright", LibraryMediaItem.MediaType.BLURAY,
            LibraryMovie.MPAARatings.PG));
        items.Add(new LibraryMovie("Pirates of the Carribean: The Curse of C#", "Disney Programming", 2011, 10,
            "MO93 4S", 122.5, "Steven Stealberg", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.G));
        items.Add(new LibraryMusic("C# - The Album", "UofL Music", 2011, 14,
            "CD44 4Z", 84.3, "Dr. A", LibraryMediaItem.MediaType.CD, 10));
        items.Add(new LibraryMusic("The Sounds of Programming", "Soundproof Music", 1996, 21,
            "VI64 1Z", 65.0, "Cee Sharpe", LibraryMediaItem.MediaType.VINYL, 12));
        items.Add(new LibraryJournal("Journal of C# Goodness", "UofL Journals", 2011, 14,
            "JJ12 7M", 1, 2, "Information Systems", "Andrew Wright"));
        items.Add(new LibraryJournal("Journal of VB Goodness", "UofL Journals", 2007, 14,
            "JJ34 3F", 8, 4, "Information Systems", "Alexander Williams"));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9A", 16, 7));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9B", 16, 8));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9C", 16, 9));
        items.Add(new LibraryMagazine("VB Magazine", "UofL Mags", 2011, 14,
            "MA21 5V", 1, 1));

        // Add patrons
        patrons.Add(new LibraryPatron("Ima Reader", "12345"));
        patrons.Add(new LibraryPatron("Jane Doe", "11223"));
        patrons.Add(new LibraryPatron("John Smith", "54321"));
        patrons.Add(new LibraryPatron("James T. Kirk", "98765"));
        patrons.Add(new LibraryPatron("Jean-Luc Picard", "33456"));

        Console.WriteLine("List of items at start:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        // Check out some items
        items[0].CheckOut(patrons[0]);
        items[2].CheckOut(patrons[2]);
        items[5].CheckOut(patrons[1]);
        items[6].CheckOut(patrons[4]);
        items[10].CheckOut(patrons[3]);

        Console.WriteLine("List of items after checking some out:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        //Using LINQ, select all the items from the list that are checked out and display the resulting items and the count of checked out items 
        //(hint: use the Count method on the LINQ result variable). Pause and wait for the user to enter a key
        var filtered =
            from LibraryItem item in items
            where item.IsCheckedOut()
            select item;
        //display
        Console.WriteLine("Display All Checked Out Items:\n");
        Console.WriteLine("{0,40} {1,11} {2,6}", "Title", "Call Number", "Patron");
        Console.WriteLine("---------------------------------------- ----------- ------");
        //Calculations and display for each checked out item
        foreach (var item in filtered)
        {
            Console.WriteLine("{0,40} {1,11} {2,6}", item.Title, item.CallNumber, item.Patron.PatronName);
        }
        
        
        //display count of checked out items
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("{0,40} {1}", "Number of Items Checked Out: ", filtered.Count()); //use .Count() method for displaying number of books checked out
  
        Pause();

        //Using LINQ, filter the previous result set to select only checked out LibraryMediaItems. 
        //Display the results to the console and then pause and wait for the user to enter a key
        var mediaFilter =
            from item in filtered
            where item is LibraryMediaItem
            select item;
        //display
        Console.WriteLine("Display All Checked Out Media Items:\n");
        Console.WriteLine("{0,40} {1,11} {2,6}", "Title", "Call Number", "Patron");
        Console.WriteLine("---------------------------------------- ----------- ------");
        //Calculations and display for each checked out item in LibraryMediaItems
        foreach (var item in mediaFilter)
        {
            Console.WriteLine("{0,40} {1,11} {2,6}", item.Title, item.CallNumber, item.Patron.PatronName);
        }
        //display title, call number, and patron name for all checked out Library Media items

        Pause();


        //Using LINQ, select the unique titles of the LibraryMagazine objects from the list and display the titles to console.
        //Pause and wait for the user to enter a key.

        //LINQ statement for grabbing all of the items, even if they aren't checked out
        var unChecked =
            from LibraryItem item in items
            select item;
        //LINQ for filtering out LibraryMagazine items from the whole list of items
        var magFilter =
            from item in unChecked
            where item is LibraryMagazine
            select item;
        //filters the magazine items by title
        var magFilterTitle =
            from LibraryMagazine item in magFilter
            select item.Title;

        //display 
        Console.WriteLine("Display All Magazine Titles:\n");
        Console.WriteLine("{0,40}", "Title");
        Console.WriteLine("----------------------------------------");
        foreach (var item in magFilterTitle.Distinct()) //.Distinct() to only return the unique titles
        {
            Console.WriteLine("{0,40}", item); //just use item here. used item.Title in linq statement
        }

        
        Pause();

        //For each item in the list, calculate what the late fee would be if it were returned 14 days late. 
        //Display the item's title, call number, and the late fee to the console. Pause and wait for the user to enter a key.

        const int NEWDAYSLATE = 14; //constant int variable for the new amount of days late
        //template
        Console.WriteLine("Calculated Late Fees after {0} days late:\n", NEWDAYSLATE);
        Console.WriteLine("{0,42} {1,11} {2,8}", "Title", "Call Number", "Late Fee");
        Console.WriteLine("------------------------------------------ ----------- --------");
        // calculating and displaying late fees for each item if the days late is 14
        foreach (LibraryItem item in items)
            Console.WriteLine("{0,42} {1,11} {2,8:C}", item.Title, item.CallNumber,
                item.CalcLateFee(NEWDAYSLATE)); //uses the new constant for days late, which is equal to 14
        Pause();





        Console.WriteLine("Calculated late fees after {0} days late:\n", DAYSLATE);
        Console.WriteLine("{0,42} {1,11} {2,8}", "Title", "Call Number", "Late Fee");
        Console.WriteLine("------------------------------------------ ----------- --------");

        // Caluclate and display late fees for each item
        foreach (LibraryItem item in items)
            Console.WriteLine("{0,42} {1,11} {2,8:C}", item.Title, item.CallNumber,
                item.CalcLateFee(DAYSLATE));
        Pause();

        // Return all the checked out items. Show that the count of checked out items is now zero using the earlier LINQ result variable. 
        //This will demonstrate that LINQ uses deferred execution. Pause and wait for the user to enter a key
        
        foreach (LibraryItem item in filtered)
        {
            if (item.IsCheckedOut())
                item.ReturnToShelf();
        }

        Console.WriteLine("After returning all items:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        //display count of checked out items
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("{0,40} {1}", "Number of Items Checked Out: ", filtered.Count()); //use .Count() to display number of books checked out and demonstrate deferred execution

        Pause();


        //For each LibraryBook in the list, display its current loan period 
        //and then modify the book's loan period to add 7 more days and display the new loan
        //period for each book. Pause and wait for the user to enter a key.

        const int PLUS = 7; //constant variable for 7. Used to create the new loan period
       
        var bookFilter =
            from item in unChecked
            where item is LibraryBook
            select item;

        Console.WriteLine("Display Library Book Loan Periods:\n");
        Console.WriteLine("{0,40} {1, 10} {2,15}", "Title", "Loan Period", "New Loan Period");
        Console.WriteLine("---------------------------------------- ---------- ---------------");
        
     
        foreach (var item in bookFilter) //foreach specifies each item selected by the LINQ var 'bookFilter'
        {
            
            Console.WriteLine("{0,40} {1,10} {2,15}", item.Title, item.LoanPeriod, (item.LoanPeriod + PLUS)); //write title, loan period, and new loan period for each item
        }

        Pause();

        //Final display of all items
        Console.WriteLine("List of All Items:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);


    }

    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
}