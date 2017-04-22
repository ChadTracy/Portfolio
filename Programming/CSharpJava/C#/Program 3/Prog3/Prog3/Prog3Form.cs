// Program 2 - Extra Credit
// CIS 200-01/02
// Spring 2016
// Due: 3/10/2016
// By: Andrew L. Wright

// File: Prog2Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About and Exit items, an Insert menu with Patron and
// Book items, an Item menu with Check Out and Return items, and a
// Report menu with Patron List, Item List, and Checked Out Items items.
// Extra Credit - Check Out and Return only show relevant items

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibraryItems
{
    public partial class Prog3Form : Form
    {
        private Library lib; // The library

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test items and patrons
        //                are added to the library
        public Prog3Form()
        {
            InitializeComponent();

            lib = new Library(); // Create the library
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Program 3{0}By: Andrew L. Wright{0}" +
                "CIS 200-01/02{0}Spring 2016", System.Environment.NewLine), "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Report, Patron List menu item activated
        // Postcondition: The list of patrons is displayed in the reportTxt
        //                text box
        private void patronListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            List<LibraryPatron> patrons; // List of patrons

            patrons = lib.GetPatronsList();

            result.Append(String.Format("Patron List - {0} patrons", lib.GetPatronCount()));
            result.Append(System.Environment.NewLine); // Remember, \n doesn't always work in GUIs
            result.Append(System.Environment.NewLine);

            foreach (LibraryPatron p in patrons)
            {
                result.Append(p.ToString());
                result.Append(System.Environment.NewLine);
                result.Append(System.Environment.NewLine);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Report, Item List menu item activated
        // Postcondition: The list of items is displayed in the reportTxt
        //                text box
        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String

            List<LibraryItem> items;     // List of library items

            items = lib.GetItemsList();
            result.Append(String.Format("Item List - {0} items", lib.GetItemCount()));
            result.Append(System.Environment.NewLine); // Remember, \n doesn't always work in GUIs
            result.Append(System.Environment.NewLine);

            foreach (LibraryItem item in items)
            {
                result.Append(item.ToString());
                result.Append(System.Environment.NewLine);
                result.Append(System.Environment.NewLine);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Report, Checked Out Items menu item activated
        // Postcondition: The list of checked out items is displayed in the
        //                reportTxt text box
        private void checkedOutItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String

            List<LibraryItem> items;     // List of library items

            items = lib.GetItemsList();

            // LINQ: selects checked out items
            var checkedOutItems =
                from item in items
                where item.IsCheckedOut()
                select item;

            result.Append(String.Format("Checked Out Items - {0} items", checkedOutItems.Count()));
            result.Append(System.Environment.NewLine); // Remember, \n doesn't always work in GUIs
            result.Append(System.Environment.NewLine);

            foreach (LibraryItem item in checkedOutItems)
            {
                result.Append(item.ToString());
                result.Append(System.Environment.NewLine);
                result.Append(System.Environment.NewLine);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Insert, Patron menu item activated
        // Postcondition: The Patron dialog box is displayed. If data entered
        //                are OK, a LibraryPatron is created and added to the library
        private void patronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatronForm patronForm = new PatronForm(); // The patron dialog box form

            DialogResult result = patronForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                // Use form's properties to get patron info to send to library
                lib.AddPatron(patronForm.PatronName, patronForm.PatronID);
            }

            patronForm.Dispose(); // Good .NET practice - will get garbage collected anyway
        }

        // Precondition:  Insert, Book menu item activated
        // Postcondition: The Book dialog box is displayed. If data entered
        //                are OK, a LibraryBook is created and added to the library
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(); // The book dialog box form

            DialogResult result = bookForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    // Use form's properties to get book info to send to library
                    lib.AddLibraryBook(bookForm.ItemTitle, bookForm.ItemPublisher, int.Parse(bookForm.ItemCopyrightYear),
                        int.Parse(bookForm.ItemLoanPeriod), bookForm.ItemCallNumber, bookForm.BookAuthor);
                }

                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Book Validation!", "Validation Error");
                }
            }

            bookForm.Dispose(); // Good .NET practice - will get garbage collected anyway
        }

        // Precondition:  Item, Check Out menu item activated
        // Postcondition: The Checkout dialog box is displayed. If data entered
        //                are OK, an item is checked out from the library by a patron
        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Extra Credit - Only display items that aren't already checked out

            List<LibraryItem> notCheckedOutList; // List of items not checked out
            List<int> notCheckedOutIndices;      // List of index values of items not checked out
            List<LibraryItem> items;             // List of library items
            List<LibraryPatron> patrons;         // List of patrons

            items = lib.GetItemsList();
            patrons = lib.GetPatronsList();

            items = lib.GetItemsList();
            patrons = lib.GetPatronsList();
            notCheckedOutList = new List<LibraryItem>();
            notCheckedOutIndices = new List<int>();

            for (int i = 0; i < items.Count(); ++i)
                if (!items[i].IsCheckedOut()) // Not checked out
                {
                    notCheckedOutList.Add(items[i]);
                    notCheckedOutIndices.Add(i);
                }

            if ((notCheckedOutList.Count() == 0) || (patrons.Count() == 0)) // Must have items and patrons
                MessageBox.Show("Must have items and patrons to check out!", "Check Out Error");
            else
            {
                CheckoutForm checkoutForm = new CheckoutForm(notCheckedOutList, patrons); // The check out dialog box form

                DialogResult result = checkoutForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    try
                    {
                        int itemIndex; // Index of item from full list of items

                        itemIndex = notCheckedOutIndices[checkoutForm.ItemIndex]; // Look up index from full list
                        lib.CheckOut(itemIndex, checkoutForm.PatronIndex);
                    }
                    catch (ArgumentOutOfRangeException) // This should never happen
                    {
                        MessageBox.Show("Problem with Check Out Index!", "Check Out Error");
                    }
                }

                checkoutForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        // Precondition:  Item, Return menu item activated
        // Postcondition: The Return dialog box is displayed. If data entered
        //                are OK, an item is returned to the library
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Extra Credit - Only display items that are already checked out

            List<LibraryItem> checkedOutList; // List of items checked out
            List<int> checkedOutIndices;      // List of index values of items checked out
            List<LibraryItem> items;          // List of library items
            List<LibraryPatron> patrons;      // List of patrons

            items = lib.GetItemsList();
            patrons = lib.GetPatronsList();
            checkedOutList = new List<LibraryItem>();
            checkedOutIndices = new List<int>();
            
            for (int i = 0; i < items.Count(); ++i)
                if (items[i].IsCheckedOut()) // Checked out
                {
                    checkedOutList.Add(items[i]);
                    checkedOutIndices.Add(i);
                }

            if ((checkedOutList.Count() == 0)) // Must have checked out items
                MessageBox.Show("Must have checked out items to return!", "Return Error");
            else
            {
                ReturnForm returnForm = new ReturnForm(checkedOutList); // The return dialog box form

                DialogResult result = returnForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    try
                    {
                        int itemIndex; // Index of item from full list of items

                        itemIndex = checkedOutIndices[returnForm.ItemIndex]; // Look up index from full list
                        lib.ReturnToShelf(itemIndex);
                    }
                    catch (ArgumentOutOfRangeException) // This should never happen
                    {
                        MessageBox.Show("Problem with Return Index!", "Return Error");
                    }
                }
                returnForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        // Precondition:  File, Save Library menu item activated
        // Postcondition: The library is saved to the file specified by the user
        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter(); // Object for serializing library in binary format
            FileStream output = null;                          // Stream for writing to a file
            DialogResult result;                               // Result of file dialog box
            string fileName;                                   // Name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog()) // Create Save File Dialog
            {
                fileChooser.CheckFileExists = false; // let user create file

                // retrieve the result of the dialog box
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified file name
            } // end using

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {

                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // save file via FileStream if user specified valid file
                    try
                    {
                        // open file with write access, Create will overwrite existing file
                        output = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                        formatter.Serialize(output, lib); // Serialize entire library
                    } // end try
                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("Error Writing to File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    // notify user if error occurs in serialization
                    catch (SerializationException)
                    {
                        MessageBox.Show("Error Writing to File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    finally
                    {
                        if (output != null)
                            output.Close(); // close FileStream
                    }
                } // end else
            } // end if
        }

        // Precondition:  File, Open Library menu item activated
        // Postcondition: The library file specified by the user is opened
        //                replacing the contents of the current library's data
        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter reader = new BinaryFormatter(); // Object for deserializing library in binary format
            FileStream input = null;                        // Stream for reading from a file
            DialogResult result;                            // Result of file dialog box
            string fileName;                                // Name of file to save data
            Library tempLib;                                // Temporary holder of library data

            using (OpenFileDialog fileChooser = new OpenFileDialog()) // Create Open Dialog box
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified name
            } // end using

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // create FileStream to obtain read access to file
                    try
                    {

                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        // get library from file
                        tempLib = (Library)reader.Deserialize(input);

                        lib = tempLib; // Separated in case deserialization failed
                    } // end try

                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("Error Reading From File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch

                    catch (SerializationException)
                    {
                        MessageBox.Show("Error Reading From File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    finally
                    {
                        if (input != null)
                            input.Close(); // close FileStream
                    }
                } // end else
            } // end if
        }

        // Precondition:  Edit, Patron menu item activated
        // Postcondition: The patron selected from the library has been edited
        //                with the new information replacing the existing object's
        //                properties
        private void patronToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<LibraryPatron> patrons; // List of patrons

            patrons = lib.GetPatronsList();

            if ((patrons.Count() == 0)) // Must have checked out items
                MessageBox.Show("Must have patrons to edit!", "Edit Error");
            else
            {
                SelectPatronForm spForm = new SelectPatronForm(patrons); // The select patron dialog box form
                DialogResult result = spForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only edit if OK
                {
                    int editIndex; // Index of patron to edit

                    editIndex = spForm.PatronIndex;

                    if (editIndex >= 0) // -1 if didn't select item from combo box (should never happen!)
                    {
                        LibraryPatron editPatron = patrons[editIndex]; // The patron being edited

                        PatronForm patronForm = new PatronForm(); // The patron dialog box form

                        // Populate form fields from selected patron
                        patronForm.PatronName = editPatron.PatronName;
                        patronForm.PatronID = editPatron.PatronID;

                        DialogResult editResult = patronForm.ShowDialog(); // Show form as dialog and store result

                        if (editResult == DialogResult.OK) // Only update patron if OK
                        {
                            // Edit patron properties using form fields
                            editPatron.PatronName = patronForm.PatronName;
                            editPatron.PatronID = patronForm.PatronID;
                        }

                        patronForm.Dispose(); // Good .NET practice - will get garbage collected anyway
                    }
                }
                spForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        // Precondition:  Edit, Book menu item activated
        // Postcondition: The book selected from the library has been edited
        //                with the new information replacing the existing object's
        //                properties
        private void bookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<LibraryItem> bookItems; // List of items that are books
            List<LibraryItem> items;    // List of library items

            items = lib.GetItemsList();
            bookItems = new List<LibraryItem>();

            for (int i = 0; i < items.Count(); ++i)
                if (items[i] is LibraryBook) // Book?
                {
                    bookItems.Add(items[i]);
                }

            if ((bookItems.Count() == 0)) // Must have books to edit
                MessageBox.Show("Must have books to edit!", "Edit Error");
            else
            {
                ReturnForm siForm = new ReturnForm(bookItems); // The select item dialog box form
                                                               // Just reused ReturnForm, they are identical
                siForm.Text = "Edit Book"; // Change return form's title to match new purpose

                DialogResult result = siForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only edit if OK
                {
                    int selectedIndex; // Index of selected item

                    selectedIndex = siForm.ItemIndex;

                    if (selectedIndex >= 0) // -1 if didn't select item from combo box (should never happen!)
                    {

                        LibraryBook editBook = (LibraryBook)bookItems[selectedIndex]; // Book being edited
                                                                                      // Need downcast to get to Author
                        BookForm bookForm = new BookForm(); // The book dialog box form

                        // Populate form fields from selected book
                        bookForm.ItemTitle = editBook.Title;
                        bookForm.ItemPublisher = editBook.Publisher;
                        bookForm.ItemCallNumber = editBook.CallNumber;
                        bookForm.ItemCopyrightYear = editBook.CopyrightYear.ToString(); // ToString since property is String on form
                        bookForm.ItemLoanPeriod = editBook.LoanPeriod.ToString();       // ToString since property is String on form
                        bookForm.BookAuthor = editBook.Author;

                        DialogResult editResult = bookForm.ShowDialog(); // Show form as dialog and store result

                        if (editResult == DialogResult.OK) // Only update book if OK
                        {
                            // Edit book properties using form fields
                            try
                            {
                                editBook.Title = bookForm.ItemTitle;
                                editBook.Publisher = bookForm.ItemPublisher;
                                editBook.CallNumber = bookForm.ItemCallNumber;
                                editBook.Author = bookForm.BookAuthor;
                                editBook.CopyrightYear = int.Parse(bookForm.ItemCopyrightYear);
                                editBook.LoanPeriod = int.Parse(bookForm.ItemLoanPeriod);
                            }
                            catch (FormatException) // This should never happen if form validation works!
                            {
                                MessageBox.Show("Problem with Book Validation!", "Validation Error");
                            }
                        }
                        bookForm.Dispose(); // Good .NET practice - will get garbage collected anyway
                    }
                }
                siForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }
    }
}
