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
    public partial class CheckOutForm : Form
    {
        private List<LibraryBook> pats { get; set; }

        public CheckOutForm()
        {
            InitializeComponent();
        }

        private void CheckOutForm_Load(object sender, EventArgs e)
        {
            
            foreach (LibraryBook pat in pats)
            {
                comboBox1.Items.Add(pat.Title + pat.CallNumber);
            }
        }
    }
}
