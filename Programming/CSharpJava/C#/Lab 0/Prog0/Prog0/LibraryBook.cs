// Program 0
// Starting Point

// File: LibraryBook.cs
// This file creates a simple LibraryBook class capable of tracking
// the book's title, author, publisher, copyright year, call number,
// and checked out status.
//Chad Tracy
//Program 0
//Due Date: 2/3/2016
//CIS 200-01

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LibraryBook
{
    public const int DEFAULT_YEAR = 2015; // Default copyright year

    private String _title;      // The book's title
    private String _author;     // The book's author
    private String _publisher;  // The book's publisher
    private int _copyrightYear; // The book's year of copyright
    private String _callNumber; // The book's call number in the library
    private bool _checkedOut;   // The book's checked out status
    private LibraryPatron _Patron; //Opens up composition (HAS-A) relationship with 'LibraryPatron' class


    // Precondition:  None
    // Postcondition: The library book has been initialized with the specified
    //                values for title, author, publisher, copyright year, and
    //                call number. The book is not checked out.
    public LibraryBook(String theTitle, String theAuthor, String thePublisher,
        int theCopyrightYear, String theCallNumber)
    {
        // Establish default first in case invalid
        CopyrightYear = DEFAULT_YEAR;

        Title = theTitle;
        Author = theAuthor;
        Publisher = thePublisher;
        CopyrightYear = theCopyrightYear;
        CallNumber = theCallNumber;

        _Patron = null; //sets both id and name for the patron to 'null' while constructing book
       
    }

    public String Title
    {
        // Precondition:  None
        // Postcondition: The title has been returned
        get
        {
            return _title;
        }

        // Precondition:  None
        // Postcondition: The title has been set to the specified value
        set
        {
            _title = value;
        }
    }

    public String Author
    {
        // Precondition:  None
        // Postcondition: The author has been returned
        get
        {
            return _author;
        }

        // Precondition:  None
        // Postcondition: The author has been set to the specified value
        set
        {
            _author = value;
        }
    }

    public String Publisher
    {
        // Precondition:  None
        // Postcondition: The publisher has been returned
        get
        {
            return _publisher;
        }

        // Precondition:  None
        // Postcondition: The publisher has been set to the specified value
        set
        {
            _publisher = value;
        }
    }

    public int CopyrightYear
    {
        // Precondition:  None
        // Postcondition: The copyright year has been returned
        get
        {
            return _copyrightYear;
        }

        // Precondition:  value >= 0
        // Postcondition: The copyright year has been set to the specified value
        set
        {
            if (value >= 0)
                _copyrightYear = value;
        }
    }

    public String CallNumber
    {
        // Precondition:  None
        // Postcondition: The call number has been returned
        get
        {
            return _callNumber;
        }

        // Precondition:  None
        // Postcondition: The call number has been set to the specified value
        set
        {
            _callNumber = value;
        }
    }

    public LibraryPatron Patron //read only property for LibraryPatron associated with the book
    {
        get
        {
            if (IsCheckedOut()) //use 'IsCheckedOut' method to check book status to being checked out
                return _Patron; 

            else //else function to return null if the book isn't checked out
                return null;
        }
        
    }


    // Precondition:  None
    // Postcondition: The book is checked out
    public void CheckOut(LibraryPatron checkPatron) //pass 'LibraryPatron' reference object
    {
        _Patron = checkPatron; // set to checkPatron
        _checkedOut = true;  // sets library books checked out status to true      
    }

    // Precondition:  None
    // Postcondition: The book is not checked out
    public void ReturnToShelf() 
    {
        _Patron = null; //removes variable 'Patron' from library book 
        _checkedOut = false; //sets the book's checked out status as false
    }

    // Precondition:  None
    // Postcondition: true is returned if the book is checked out,
    //                otherwise false is returned
    public bool IsCheckedOut()
    {
        return _checkedOut;
    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary book's data on
    //                separate lines
    public override string ToString()
    {
        return String.Format("Title: {0}{6}Author: {1}{6}Publisher: {2}{6}" +
            "Copyright: {3:D4}{6}Call Number: {4}{6}Checked Out By: {5}",
            Title, Author, Publisher, CopyrightYear, CallNumber, IsCheckedOut() ? String.Format("PatronID: {0}, Patron Name: {1}", Patron.PatronID,Patron.PatronName) : "Not checked out.", 
            System.Environment.NewLine);                                        //use of '?' to check if 'IsCheckedOut' returns a true value. If yes it prints the appropriate patrons, if not return 'not checked out'
    }
}
