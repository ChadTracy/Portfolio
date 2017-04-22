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
    public partial class Form1 : Form
    {
        Library library = new Library();

        public Form1()
        {
            InitializeComponent();
        }

        private void FileBtn_Click(object sender, EventArgs e)
        {

        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            //Display name, program number, and due date on click
            MessageBox.Show("Chad Tracy\n Program 2\n Due: 3/10/2016");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //close program on click
            this.Close();
        }

        private void AddPatronBtn_Click(object sender, EventArgs e)
        {
            PatronForm patronform = new PatronForm();//patron form box
            DialogResult result; //result from dialog

            result = patronform.ShowDialog(); //shows dialog for the patron form


        }

        private void AddBookBtn_Click(object sender, EventArgs e)
        {
            BookForm bookform = new BookForm(); //book form
            DialogResult bookresult;

            bookresult = bookform.ShowDialog(); //displays book form
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckOutForm checkform = new CheckOutForm();
            DialogResult checkresult;

            checkresult = checkform.ShowDialog();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LibraryItem> items;

            items = library.GetItemsList();

            if ((items.Count() == 0)) //items must be present
            {
                MessageBox.Show("Items must be present to return", "error");
            }
            else
            {
                ReturnForm returnForm = new ReturnForm(items); //return form
                DialogResult result = returnForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    library.ReturnToShelf();
                }


            }

        }

        public void patronListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            public override string ToString()
        {

            StringBuilder report = new StringBuilder();

            report.Append("Library Report\n");

            report.Append(String.Format("Number of patrons stored:    {0,4:d}", library.GetPatronCount()));

            return report.ToString();
        }
    }


    public void itemListToolStripMenuItem_Click(object sender, EventArgs e)
    {
            public override string ToString()
    {
        StringBuilder itemreport = new StringBuilder();

        itemreport.Append(String.Format("Number of items stored:      {0,4:d}{1}", library.GetItemCount(), System.Environment.NewLine));

        return itemreport.ToString();
    }
}

    }
}



     
