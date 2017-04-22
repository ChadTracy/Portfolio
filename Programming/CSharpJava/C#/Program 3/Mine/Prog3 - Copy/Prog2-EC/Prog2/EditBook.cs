using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryItems
{
    public partial class EditBook : Form
    {
        private List<LibraryBook> books;

        public EditBook(List<LibraryBook> bookList)
        {
            InitializeComponent();
            bookList = books;
        }

        private void EditBook_Load(object sender, EventArgs e)
        {
            foreach (LibraryBook book in books)
            {
                comboBox1.Items.Add(book.Title, "," + book.LoanPeriod, "," + book.CopyrightYear, "," + book.LoanPeriod, "," + book.Author, "," + book.CallNumber);
            }
        }

        internal int BookIndex
        {
            get
            {
                return comboBox1.SelectedIndex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
