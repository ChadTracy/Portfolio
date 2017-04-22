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
    public partial class PatronForm : Form
    {
        Library pform = new Library();

        public PatronForm()
        {
            InitializeComponent();
        }

        private void AddPatBtn_Validating(object sender, CancelEventArgs e)
        {         
            if (!PatNameTB.Text.All(char.IsLetter))
            {
                e.Cancel = true;// prevents further progress if there is an error

                errorProvider1.SetError(PatNameTB, "Please enter text.");// set error message

                PatNameTB.SelectAll();// selects all text to make it easier to fix
            }
            if (!PatIDTB.Text.All(char.IsLetter))
            {
                e.Cancel = true;

                errorProvider2.SetError(PatIDTB, "Please enter text.");// set error message

                PatIDTB.SelectAll();// selects all text to make it easier to fix
            }
            else
            {
                pform.AddPatron(PatNameTB.Text, PatIDTB.Text); //use 'AddPatron' method from Library class 

            }

            this.Close();




        }
        private void AddPatBtn_Validated(object sender, EventArgs e) //clears the error messages
        {
            errorProvider1.SetError(PatNameTB, "");
            errorProvider2.SetError(PatIDTB, ""); 
        }
    }
}
