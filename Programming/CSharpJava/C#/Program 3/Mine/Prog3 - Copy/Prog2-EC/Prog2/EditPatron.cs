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
    public partial class EditPatron: Form
    {
        private List<LibraryPatron> patrons;

        public EditPatron(List<LibraryPatron> patronList)
        {
            InitializeComponent();            
           
           patrons = patronList;
               
        }

        private void EditPatron_Load(object sender, EventArgs e)
        {

            foreach (LibraryPatron pat in patrons)
            {
                patBox.Items.Add(pat.PatronName + "," + pat.PatronID);
            }
        }

        internal int PatronIndex
        {
            get
            {
                return patBox.SelectedIndex;
            }
        }

        private void patBox_Validating(object sender, CancelEventArgs e)
        {
            if (patBox.SelectedIndex == -1) //make sure something is selected
            {
                e.Cancel = true;
                errorProvider1.SetError(patBox, "Must select a value to proceed");
            }
        }

        private void patBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(patBox, ""); //allows focus to change
        }

        private void patEnter_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.DialogResult = DialogResult.OK; //causes dialog result to return as OK
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //accidently double clicked this
        }

        public void patBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.patBox.GetItemText(this.patBox.SelectedItem);
            oldName.Text = selected;
        }
    }
}
