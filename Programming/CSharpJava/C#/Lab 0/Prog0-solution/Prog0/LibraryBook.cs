// Program 0
// CIS 200-01/02
// Due: 2/3/2016
// By: Andrew L. Wright

// File: LibraryBook.cs
// This file creates a simple LibraryBook class capable of tracking
// the book's title, author, publisher, copyright year, call number,
// and checked out status. In addition, when a book is checked out
// by a LibraryPatron, the patron is noted.
// LibraryBook HAS-A LibraryPatron (when the book is checked out)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LibraryBook
{
    public const int DEFAULT_YEAR = 2015; // Default copyright year

    private String _title;          // The book's title
    private String _author;         // The book's author
    private String _publisher;      // The book's publisher
    private int _copyrightYear;     // The book's year of copyright
    private String _callNumber;     // The book's call number in the library
    private bool _checkedOut;       // The book's checked out status
    private LibraryPatron _patron;  // The person that has the book checked out (null otherwise)

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

        ReturnToShelf(); // Make sure book is not checked out
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

    public LibraryPatron Patron
    {
        // Precondition:  IsCheckedOut() == true
        // Postcondition: The patron that has the book checked out is returned
        //                (otherwise null)
        get
        {
            return _patron;
        }

        // HELPER - not public
        // Precondition:  None
        // Postcondition: The associated patron value is stored
        private set
        {
            _patron = value;
        }
    }

    // Precondition:  None
    // Postcondition: The book is checked out by thePatron
    public void CheckOut(LibraryPatron thePatron)
    {
        _checkedOut = true;
        Patron = thePatron;
    }

    // Precondition:  None
    // Postcondition: The book is not checked out (by any patron)
    public void ReturnToShelf()
    {
        _checkedOut = false;
        Patron = null; // No longer associated with anyone
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
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{5}Author: {1}{5}Publisher: {2}{5}" +
            "Copyright: {3}{5}Call Number: {4}{5}",
            Title, Author, Publisher, CopyrightYear, CallNumber, System.Environment.NewLine);

        if (IsCheckedOut())
            result += String.Format("Checked Out By: {1}{0}", Patron, System.Environment.NewLine);
        else
            result += "Not Checked Out";

        return result;
    }
}
