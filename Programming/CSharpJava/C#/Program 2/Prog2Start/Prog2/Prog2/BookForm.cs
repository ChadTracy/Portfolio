using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryItems
{
    public partial class BookForm : Form
    {
        Library bform = new Library();

        public BookForm()
        {
            InitializeComponent();
        }

        private void AuthorTB_Validating(object sender, CancelEventArgs e)
        {
          //  if (!AuthorTB.Text.All(char.IsLetter))
           // {
               // e.Cancel = true;

              //  errorProvider6.SetError(AuthorTB, "Invalid Data");

               // AuthorTB.SelectAll();
                 
          //  }
        }

        private void AddBookBtn_Validating(object sender, CancelEventArgs e)
        {
            
            if (!TitleTB.Text.All(char.IsLetter))
            {
                e.Cancel = true;

                errorProvider1.SetError(TitleTB, "Invalid Data");

                TitleTB.SelectAll();
            }
            if (!PublisherTB.Text.All(char.IsLetter))
            {
                e.Cancel = true;

                errorProvider2.SetError(PublisherTB, "Invalid Data");

                PublisherTB.SelectAll();
            }
            if (!CopyrightTB.Text.All(char.IsDigit))
            {
                e.Cancel = true;

                errorProvider3.SetError(CopyrightTB, "Invalid Data");

                CopyrightTB.SelectAll();
            }
            if (!LoanTB.Text.All(char.IsLetter))
            {
                e.Cancel = true;

                errorProvider4.SetError(LoanTB, "Invalid Data");

                LoanTB.SelectAll();
            }
            if (!CallTB.Text.All(char.IsLetterOrDigit))
            {
                e.Cancel = true;

                errorProvider5.SetError(CallTB, "Invalid Data");

                CallTB.SelectAll();
            }
            if (!AuthorTB.Text.All(char.IsLetter))
            {
                e.Cancel = true;

                errorProvider6.SetError(AuthorTB, "Invalid Data");

                AuthorTB.SelectAll();
            }
            else
            {
                int CR;
                int Loan;

                CR = int.Parse(CopyrightTB.Text);
                Loan = int.Parse(LoanTB.Text);

                bform.AddLibraryBook(TitleTB.Text, PublisherTB.Text, CR, Loan, CallTB.Text, AuthorTB.Text);
            }
        }

        private void AddBookBtn_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TitleTB, "");
            errorProvider2.SetError(PublisherTB, "");
            errorProvider3.SetError(CopyrightTB, "");
            errorProvider4.SetError(LoanTB, "");
            errorProvider5.SetError(CallTB, "");
            errorProvider6.SetError(AuthorTB, "");
        }
    }
}
