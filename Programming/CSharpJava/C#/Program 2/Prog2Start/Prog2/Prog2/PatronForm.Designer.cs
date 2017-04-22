namespace LibraryItems
{
    partial class PatronForm
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
            this.PatNameTB = new System.Windows.Forms.TextBox();
            this.PatIDTB = new System.Windows.Forms.TextBox();
            this.PatNameLabel = new System.Windows.Forms.Label();
            this.PatIDLabel = new System.Windows.Forms.Label();
            this.AddPatBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // PatNameTB
            // 
            this.PatNameTB.Location = new System.Drawing.Point(232, 57);
            this.PatNameTB.Name = "PatNameTB";
            this.PatNameTB.Size = new System.Drawing.Size(100, 22);
            this.PatNameTB.TabIndex = 0;
            // 
            // PatIDTB
            // 
            this.PatIDTB.Location = new System.Drawing.Point(232, 114);
            this.PatIDTB.Name = "PatIDTB";
            this.PatIDTB.Size = new System.Drawing.Size(100, 22);
            this.PatIDTB.TabIndex = 1;
            // 
            // PatNameLabel
            // 
            this.PatNameLabel.AutoSize = true;
            this.PatNameLabel.Location = new System.Drawing.Point(50, 57);
            this.PatNameLabel.Name = "PatNameLabel";
            this.PatNameLabel.Size = new System.Drawing.Size(45, 17);
            this.PatNameLabel.TabIndex = 2;
            this.PatNameLabel.Text = "Name";
            // 
            // PatIDLabel
            // 
            this.PatIDLabel.AutoSize = true;
            this.PatIDLabel.Location = new System.Drawing.Point(50, 114);
            this.PatIDLabel.Name = "PatIDLabel";
            this.PatIDLabel.Size = new System.Drawing.Size(21, 17);
            this.PatIDLabel.TabIndex = 3;
            this.PatIDLabel.Text = "ID";
            // 
            // AddPatBtn
            // 
            this.AddPatBtn.Location = new System.Drawing.Point(107, 205);
            this.AddPatBtn.Name = "AddPatBtn";
            this.AddPatBtn.Size = new System.Drawing.Size(138, 29);
            this.AddPatBtn.TabIndex = 4;
            this.AddPatBtn.Text = "Add Patron";
            this.AddPatBtn.UseVisualStyleBackColor = true;
            this.AddPatBtn.Validating += new System.ComponentModel.CancelEventHandler(this.AddPatBtn_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // PatronForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 286);
            this.Controls.Add(this.AddPatBtn);
            this.Controls.Add(this.PatIDLabel);
            this.Controls.Add(this.PatNameLabel);
            this.Controls.Add(this.PatIDTB);
            this.Controls.Add(this.PatNameTB);
            this.Name = "PatronForm";
            this.Text = "PatronForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PatNameTB;
        private System.Windows.Forms.TextBox PatIDTB;
        private System.Windows.Forms.Label PatNameLabel;
        private System.Windows.Forms.Label PatIDLabel;
        private System.Windows.Forms.Button AddPatBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}