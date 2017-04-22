namespace LibraryItems
{
    partial class EditPatron
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.patBox = new System.Windows.Forms.ComboBox();
            this.newName = new System.Windows.Forms.TextBox();
            this.newID = new System.Windows.Forms.TextBox();
            this.oldName = new System.Windows.Forms.TextBox();
            this.olddata = new System.Windows.Forms.Label();
            this.Newdata = new System.Windows.Forms.Label();
            this.patEnter = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // patBox
            // 
            this.patBox.FormattingEnabled = true;
            this.patBox.Location = new System.Drawing.Point(122, 34);
            this.patBox.Name = "patBox";
            this.patBox.Size = new System.Drawing.Size(189, 24);
            this.patBox.TabIndex = 0;
            this.patBox.SelectedIndexChanged += new System.EventHandler(this.patBox_SelectedIndexChanged);
            this.patBox.Validating += new System.ComponentModel.CancelEventHandler(this.patBox_Validating);
            this.patBox.Validated += new System.EventHandler(this.patBox_Validated);
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(286, 161);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(100, 22);
            this.newName.TabIndex = 1;
            // 
            // newID
            // 
            this.newID.Location = new System.Drawing.Point(286, 274);
            this.newID.Name = "newID";
            this.newID.Size = new System.Drawing.Size(100, 22);
            this.newID.TabIndex = 2;
            // 
            // oldName
            // 
            this.oldName.Location = new System.Drawing.Point(12, 205);
            this.oldName.Name = "oldName";
            this.oldName.ReadOnly = true;
            this.oldName.Size = new System.Drawing.Size(174, 22);
            this.oldName.TabIndex = 3;
            // 
            // olddata
            // 
            this.olddata.AutoSize = true;
            this.olddata.Location = new System.Drawing.Point(37, 112);
            this.olddata.Name = "olddata";
            this.olddata.Size = new System.Drawing.Size(129, 17);
            this.olddata.TabIndex = 5;
            this.olddata.Text = "Current Information";
            // 
            // Newdata
            // 
            this.Newdata.AutoSize = true;
            this.Newdata.Location = new System.Drawing.Point(267, 112);
            this.Newdata.Name = "Newdata";
            this.Newdata.Size = new System.Drawing.Size(147, 17);
            this.Newdata.TabIndex = 6;
            this.Newdata.Text = "Enter New Information";
            // 
            // patEnter
            // 
            this.patEnter.Location = new System.Drawing.Point(176, 347);
            this.patEnter.Name = "patEnter";
            this.patEnter.Size = new System.Drawing.Size(75, 33);
            this.patEnter.TabIndex = 7;
            this.patEnter.Text = "Enter";
            this.patEnter.UseVisualStyleBackColor = true;
            this.patEnter.Click += new System.EventHandler(this.patEnter_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "List of Patrons";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EditPatron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patEnter);
            this.Controls.Add(this.Newdata);
            this.Controls.Add(this.olddata);
            this.Controls.Add(this.oldName);
            this.Controls.Add(this.newID);
            this.Controls.Add(this.newName);
            this.Controls.Add(this.patBox);
            this.Name = "EditPatron";
            this.Text = "EditPatron";
            this.Load += new System.EventHandler(this.EditPatron_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox patBox;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.TextBox newID;
        private System.Windows.Forms.TextBox oldName;
        private System.Windows.Forms.Label olddata;
        private System.Windows.Forms.Label Newdata;
        private System.Windows.Forms.Button patEnter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
    }
}