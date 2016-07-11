namespace Apothiki
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.διαχείρησηToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.εισαγωγήΣεΚουτίToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.εξαγωγήΑπόΚουτίToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.δημιουργίαToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.κουτίToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.προϊόνToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.διαγραφήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.κουτίToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.προϊόνToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.προβολήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.κουτιάToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.προϊόνταToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.σχέσειςToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(471, 421);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Αναζήτηση";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.διαχείρησηToolStripMenuItem,
            this.δημιουργίαToolStripMenuItem,
            this.διαγραφήToolStripMenuItem,
            this.προβολήToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(471, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // διαχείρησηToolStripMenuItem
            // 
            this.διαχείρησηToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.εισαγωγήΣεΚουτίToolStripMenuItem,
            this.εξαγωγήΑπόΚουτίToolStripMenuItem});
            this.διαχείρησηToolStripMenuItem.Name = "διαχείρησηToolStripMenuItem";
            this.διαχείρησηToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.διαχείρησηToolStripMenuItem.Text = "Διαχείρηση";
            // 
            // εισαγωγήΣεΚουτίToolStripMenuItem
            // 
            this.εισαγωγήΣεΚουτίToolStripMenuItem.Name = "εισαγωγήΣεΚουτίToolStripMenuItem";
            this.εισαγωγήΣεΚουτίToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.εισαγωγήΣεΚουτίToolStripMenuItem.Text = "Εισαγωγή σε Κουτί";
            this.εισαγωγήΣεΚουτίToolStripMenuItem.Click += new System.EventHandler(this.εισαγωγήΣεΚουτίToolStripMenuItem_Click);
            // 
            // εξαγωγήΑπόΚουτίToolStripMenuItem
            // 
            this.εξαγωγήΑπόΚουτίToolStripMenuItem.Name = "εξαγωγήΑπόΚουτίToolStripMenuItem";
            this.εξαγωγήΑπόΚουτίToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.εξαγωγήΑπόΚουτίToolStripMenuItem.Text = "Εξαγωγή από Κουτί";
            this.εξαγωγήΑπόΚουτίToolStripMenuItem.Click += new System.EventHandler(this.εξαγωγήΑπόΚουτίToolStripMenuItem_Click);
            // 
            // δημιουργίαToolStripMenuItem
            // 
            this.δημιουργίαToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.κουτίToolStripMenuItem,
            this.προϊόνToolStripMenuItem});
            this.δημιουργίαToolStripMenuItem.Name = "δημιουργίαToolStripMenuItem";
            this.δημιουργίαToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.δημιουργίαToolStripMenuItem.Text = "Δημιουργία";
            // 
            // κουτίToolStripMenuItem
            // 
            this.κουτίToolStripMenuItem.Name = "κουτίToolStripMenuItem";
            this.κουτίToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.κουτίToolStripMenuItem.Text = "Κουτί";
            this.κουτίToolStripMenuItem.Click += new System.EventHandler(this.κουτίToolStripMenuItem_Click);
            // 
            // προϊόνToolStripMenuItem
            // 
            this.προϊόνToolStripMenuItem.Name = "προϊόνToolStripMenuItem";
            this.προϊόνToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.προϊόνToolStripMenuItem.Text = "Προϊόν";
            this.προϊόνToolStripMenuItem.Click += new System.EventHandler(this.προϊόνToolStripMenuItem_Click);
            // 
            // διαγραφήToolStripMenuItem
            // 
            this.διαγραφήToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.κουτίToolStripMenuItem1,
            this.προϊόνToolStripMenuItem1});
            this.διαγραφήToolStripMenuItem.Name = "διαγραφήToolStripMenuItem";
            this.διαγραφήToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.διαγραφήToolStripMenuItem.Text = "Διαγραφή";
            // 
            // κουτίToolStripMenuItem1
            // 
            this.κουτίToolStripMenuItem1.Name = "κουτίToolStripMenuItem1";
            this.κουτίToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.κουτίToolStripMenuItem1.Text = "Κουτί";
            this.κουτίToolStripMenuItem1.Click += new System.EventHandler(this.κουτίToolStripMenuItem1_Click);
            // 
            // προϊόνToolStripMenuItem1
            // 
            this.προϊόνToolStripMenuItem1.Name = "προϊόνToolStripMenuItem1";
            this.προϊόνToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.προϊόνToolStripMenuItem1.Text = "Προϊόν";
            this.προϊόνToolStripMenuItem1.Click += new System.EventHandler(this.προϊόνToolStripMenuItem1_Click);
            // 
            // προβολήToolStripMenuItem
            // 
            this.προβολήToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.κουτιάToolStripMenuItem,
            this.προϊόνταToolStripMenuItem,
            this.σχέσειςToolStripMenuItem});
            this.προβολήToolStripMenuItem.Name = "προβολήToolStripMenuItem";
            this.προβολήToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.προβολήToolStripMenuItem.Text = "Προβολή";
            // 
            // κουτιάToolStripMenuItem
            // 
            this.κουτιάToolStripMenuItem.Name = "κουτιάToolStripMenuItem";
            this.κουτιάToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.κουτιάToolStripMenuItem.Text = "Κουτιά";
            this.κουτιάToolStripMenuItem.Click += new System.EventHandler(this.κουτιάToolStripMenuItem_Click);
            // 
            // προϊόνταToolStripMenuItem
            // 
            this.προϊόνταToolStripMenuItem.Name = "προϊόνταToolStripMenuItem";
            this.προϊόνταToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.προϊόνταToolStripMenuItem.Text = "Προϊόντα";
            this.προϊόνταToolStripMenuItem.Click += new System.EventHandler(this.προϊόνταToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(471, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // σχέσειςToolStripMenuItem
            // 
            this.σχέσειςToolStripMenuItem.Name = "σχέσειςToolStripMenuItem";
            this.σχέσειςToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.σχέσειςToolStripMenuItem.Text = "Σχέσεις";
            this.σχέσειςToolStripMenuItem.Click += new System.EventHandler(this.σχέσειςToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 421);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Αποθήκη";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem διαχείρησηToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem εισαγωγήΣεΚουτίToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem εξαγωγήΑπόΚουτίToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem δημιουργίαToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem κουτίToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem προϊόνToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem διαγραφήToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem κουτίToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem προϊόνToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem προβολήToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem κουτιάToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem προϊόνταToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem σχέσειςToolStripMenuItem;
    }
}

