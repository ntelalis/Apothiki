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
            this.searchSxeseisTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.διαχείρησηToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importProionToKouti = new System.Windows.Forms.ToolStripMenuItem();
            this.exportProionApoKouti = new System.Windows.Forms.ToolStripMenuItem();
            this.δημιουργίαToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newKouti = new System.Windows.Forms.ToolStripMenuItem();
            this.newProion = new System.Windows.Forms.ToolStripMenuItem();
            this.αλλαγήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeKouti = new System.Windows.Forms.ToolStripMenuItem();
            this.changeProion = new System.Windows.Forms.ToolStripMenuItem();
            this.διαγραφήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delKouti = new System.Windows.Forms.ToolStripMenuItem();
            this.delProion = new System.Windows.Forms.ToolStripMenuItem();
            this.προβολήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showKoutia = new System.Windows.Forms.ToolStripMenuItem();
            this.showProionta = new System.Windows.Forms.ToolStripMenuItem();
            this.showSxeseis = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.searchSxeseisTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView);
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
            // searchSxeseisTextBox
            // 
            this.searchSxeseisTextBox.Location = new System.Drawing.Point(81, 68);
            this.searchSxeseisTextBox.Name = "searchSxeseisTextBox";
            this.searchSxeseisTextBox.Size = new System.Drawing.Size(201, 20);
            this.searchSxeseisTextBox.TabIndex = 0;
            this.searchSxeseisTextBox.TextChanged += new System.EventHandler(this.searchSxeseisTextBox_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.διαχείρησηToolStripMenuItem,
            this.δημιουργίαToolStripMenuItem,
            this.αλλαγήToolStripMenuItem,
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
            this.importProionToKouti,
            this.exportProionApoKouti});
            this.διαχείρησηToolStripMenuItem.Name = "διαχείρησηToolStripMenuItem";
            this.διαχείρησηToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.διαχείρησηToolStripMenuItem.Text = "Διαχείρηση";
            // 
            // importProionToKouti
            // 
            this.importProionToKouti.Name = "importProionToKouti";
            this.importProionToKouti.Size = new System.Drawing.Size(180, 22);
            this.importProionToKouti.Text = "Εισαγωγή σε Κουτί";
            this.importProionToKouti.Click += new System.EventHandler(this.importProionToKouti_Click);
            // 
            // exportProionApoKouti
            // 
            this.exportProionApoKouti.Name = "exportProionApoKouti";
            this.exportProionApoKouti.Size = new System.Drawing.Size(180, 22);
            this.exportProionApoKouti.Text = "Εξαγωγή από Κουτί";
            this.exportProionApoKouti.Click += new System.EventHandler(this.exportProionApoKouti_Click);
            // 
            // δημιουργίαToolStripMenuItem
            // 
            this.δημιουργίαToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newKouti,
            this.newProion});
            this.δημιουργίαToolStripMenuItem.Name = "δημιουργίαToolStripMenuItem";
            this.δημιουργίαToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.δημιουργίαToolStripMenuItem.Text = "Δημιουργία";
            // 
            // newKouti
            // 
            this.newKouti.Name = "newKouti";
            this.newKouti.Size = new System.Drawing.Size(113, 22);
            this.newKouti.Text = "Κουτί";
            this.newKouti.Click += new System.EventHandler(this.newKouti_Click);
            // 
            // newProion
            // 
            this.newProion.Name = "newProion";
            this.newProion.Size = new System.Drawing.Size(113, 22);
            this.newProion.Text = "Προϊόν";
            this.newProion.Click += new System.EventHandler(this.newProion_Click);
            // 
            // αλλαγήToolStripMenuItem
            // 
            this.αλλαγήToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeKouti,
            this.changeProion});
            this.αλλαγήToolStripMenuItem.Name = "αλλαγήToolStripMenuItem";
            this.αλλαγήToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.αλλαγήToolStripMenuItem.Text = "Αλλαγή";
            this.αλλαγήToolStripMenuItem.Click += new System.EventHandler(this.αλλαγήToolStripMenuItem_Click);
            // 
            // changeKouti
            // 
            this.changeKouti.Name = "changeKouti";
            this.changeKouti.Size = new System.Drawing.Size(113, 22);
            this.changeKouti.Text = "Κουτί";
            this.changeKouti.Click += new System.EventHandler(this.changeKouti_Click);
            // 
            // changeProion
            // 
            this.changeProion.Name = "changeProion";
            this.changeProion.Size = new System.Drawing.Size(113, 22);
            this.changeProion.Text = "Προϊόν";
            this.changeProion.Click += new System.EventHandler(this.changeProion_Click);
            // 
            // διαγραφήToolStripMenuItem
            // 
            this.διαγραφήToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delKouti,
            this.delProion});
            this.διαγραφήToolStripMenuItem.Name = "διαγραφήToolStripMenuItem";
            this.διαγραφήToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.διαγραφήToolStripMenuItem.Text = "Διαγραφή";
            // 
            // delKouti
            // 
            this.delKouti.Name = "delKouti";
            this.delKouti.Size = new System.Drawing.Size(113, 22);
            this.delKouti.Text = "Κουτί";
            this.delKouti.Click += new System.EventHandler(this.delKouti_Click);
            // 
            // delProion
            // 
            this.delProion.Name = "delProion";
            this.delProion.Size = new System.Drawing.Size(113, 22);
            this.delProion.Text = "Προϊόν";
            this.delProion.Click += new System.EventHandler(this.delProion_Click);
            // 
            // προβολήToolStripMenuItem
            // 
            this.προβολήToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showKoutia,
            this.showProionta,
            this.showSxeseis});
            this.προβολήToolStripMenuItem.Name = "προβολήToolStripMenuItem";
            this.προβολήToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.προβολήToolStripMenuItem.Text = "Προβολή";
            // 
            // showKoutia
            // 
            this.showKoutia.Name = "showKoutia";
            this.showKoutia.Size = new System.Drawing.Size(126, 22);
            this.showKoutia.Text = "Κουτιά";
            this.showKoutia.Click += new System.EventHandler(this.showKoutia_Click);
            // 
            // showProionta
            // 
            this.showProionta.Name = "showProionta";
            this.showProionta.Size = new System.Drawing.Size(126, 22);
            this.showProionta.Text = "Προϊόντα";
            this.showProionta.Click += new System.EventHandler(this.showProionta_Click);
            // 
            // showSxeseis
            // 
            this.showSxeseis.Name = "showSxeseis";
            this.showSxeseis.Size = new System.Drawing.Size(126, 22);
            this.showSxeseis.Text = "Σχέσεις";
            this.showSxeseis.Click += new System.EventHandler(this.showSxeseis_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(471, 256);
            this.dataGridView.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchSxeseisTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem διαχείρησηToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importProionToKouti;
        private System.Windows.Forms.ToolStripMenuItem exportProionApoKouti;
        private System.Windows.Forms.ToolStripMenuItem δημιουργίαToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newKouti;
        private System.Windows.Forms.ToolStripMenuItem newProion;
        private System.Windows.Forms.ToolStripMenuItem διαγραφήToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delKouti;
        private System.Windows.Forms.ToolStripMenuItem delProion;
        private System.Windows.Forms.ToolStripMenuItem προβολήToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showKoutia;
        private System.Windows.Forms.ToolStripMenuItem showProionta;
        private System.Windows.Forms.ToolStripMenuItem showSxeseis;
        private System.Windows.Forms.ToolStripMenuItem αλλαγήToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeKouti;
        private System.Windows.Forms.ToolStripMenuItem changeProion;
    }
}

