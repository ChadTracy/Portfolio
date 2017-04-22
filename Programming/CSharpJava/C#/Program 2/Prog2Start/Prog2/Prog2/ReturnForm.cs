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
    public partial class ReturnForm: Form
    {
        private List<LibraryItem> items { get; set; }

        public ReturnForm()
        {
            InitializeComponent();
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            foreach (LibraryItem item in items)
            {
                comboBox1.Items.Add(item.Title + item.CallNumber);
            }
        }
    }
}
